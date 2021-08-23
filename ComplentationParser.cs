using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class ComplectationParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document, int carSubmodelId)
        {
            Console.WriteLine("  -----------------------------------------------");
            var complectationElements = document.QuerySelector("tbody").Children;
            var fieldsElements = complectationElements.FirstOrDefault().Children;
            List<string> fileds = GetFields(fieldsElements);

            ComplectationModel[] complectationModels = new ComplectationModel[complectationElements.Length - 1];

            for (int i = 0; i < complectationModels.Length; i++)
                complectationModels[i] = new ComplectationModel() { CarSubmodelId = carSubmodelId };

            for (int i = 0; i < fileds.Count; i++)
                await FillComplentationHelper.FillComplectationAsync(fileds[i], i, complectationModels, complectationElements);

            await DbHelper.AddAsync(complectationModels.ToList());
            //await LoadGroupAsync(complectationModels);
        }

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
                await GroupParser.ParseAndSaveAsync(documentOfGroups);
            }
        }
    }
}
