using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.DbHelpers;
using ilcatsParser.Ef.Models;
using ilcatsParser.Parsers.ParserHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    static class ComplectationsParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document, int carSubmodelId)
        {
            var complectationElements = document.QuerySelector("tbody").Children;

            //get first <tr> element, which contains data of fields
            var fieldsElements = complectationElements.FirstOrDefault().Children;
            List<string> fileds = GetFields(fieldsElements);

            ComplectationModel[] complectationModels = new ComplectationModel[complectationElements.Length - 1];

            for (int i = 0; i < complectationModels.Length; i++)
                complectationModels[i] = new ComplectationModel() { CarSubmodelId = carSubmodelId };

            for (int i = 0; i < fileds.Count; i++)
                await FillComplentationHelper.FillComplectationAsync(fileds[i], i, complectationModels, complectationElements);

            await DbHelper.AddAsync(complectationModels.ToList());
            await LoadGroupAsync(complectationModels);
        }

        /// <summary>
        /// Get the fields data, to be know what kind of data contains complectation
        /// </summary>
        /// <param name="thElements"></param>
        /// <returns></returns>
        private static List<string> GetFields(IHtmlCollection<IElement> thElements)
        {
            List<string> values = new List<string>();
            foreach (var thValue in thElements)
            {
                values.Add(thValue.TextContent);
            }
            return values;
        }

        private static async Task LoadGroupAsync(IEnumerable<ComplectationModel> complectationModels)
        {
            foreach (var complectationModel in complectationModels)
            {
                string pageOfGroupsUrl = complectationModel.GroupUrl;
                var documentOfGroups = await HtmlLoader.LoadAndParseHtmlAsync(pageOfGroupsUrl);
                int complectationId = complectationModel.Id == 0 ? await GetComplectationIdAsync(complectationModel.Complectation) : complectationModel.Id;
                await GroupsParser.ParseAndSaveAsync(documentOfGroups, complectationId);
            }
        }

        private static async Task<int> GetComplectationIdAsync(string complectation)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.ComplectationModels.Where(t => t.Complectation == complectation).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
