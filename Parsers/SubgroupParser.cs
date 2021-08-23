using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    class SubgroupParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document, int groupId, int complectationId)
        {
            Console.WriteLine("    -----------------------------------------------");
            var subgroupElements = document.All.Where(t => t.ClassName == "name");
            List<Subgroup> subgroups = new List<Subgroup>();

            foreach (var subgroup in subgroupElements) 
            {
                string partsUrl = subgroup.FirstElementChild.GetAttribute("href");
                subgroups.Add(new Subgroup { Name = subgroup.TextContent, GroupId = groupId, PartsUrl = partsUrl });
            }

            await DbHelper.AddAsync(subgroups);
            await LoadPartsAsync(subgroups, complectationId);
        }

        private static async Task LoadPartsAsync(List<Subgroup> subgroups, int complectationId)
        {
            foreach (var subgroup in subgroups)
            {
                string partsUrl = subgroup.PartsUrl;
                var documentOfParts = await HtmlLoader.LoadAndParseHtmlAsync(partsUrl);
                int subgroupId = subgroup.Id == 0 ? await GetSubgroupIdAsync(subgroup.Name) : subgroup.Id;
                await PartParser.ParseAndSaveAsync(documentOfParts, subgroupId, complectationId);
            }
        }

        private static async Task<int> GetSubgroupIdAsync(string subgroupName)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.Subgroups.Where(t => t.Name == subgroupName).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
