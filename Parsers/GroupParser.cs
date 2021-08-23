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
    class GroupParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document)
        {
            Console.WriteLine("   ---------------------------------------------------");
            var groupElements = document.All.Where(t => t.ClassName == "name");
            List<Group> groups = new List<Group>();

            foreach (var g in groupElements)
            {
                string subroupsUrl = g.FirstElementChild.GetAttribute("href");
                string groupName = g.FirstElementChild.TextContent;
                Group group = new Group { Name = groupName, SubgroupsUrl = subroupsUrl };

                groups.Add(group);
            }

            await DbHelper.AddAsync(groups);
            await LoadSubgroupsAsync(groups);
        }

        private static async Task LoadSubgroupsAsync(List<Group> groups)
        {
            foreach (var group in groups)
            {
                string subgroupsUrl = group.SubgroupsUrl;
                var documentOfSubroups = await HtmlLoader.LoadAndParseHtmlAsync(subgroupsUrl);
                int groupId = group.Id == 0 ? await GetGroupIdAsync(group.Name) : group.Id;
                await SubgroupParser.ParseAndSaveAsync(documentOfSubroups, groupId);
            }
        }

        private static async Task<int> GetGroupIdAsync(string groupName)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.Groups.Where(t => t.Name == groupName).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
