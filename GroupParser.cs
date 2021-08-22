using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
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
                string subroupUrl = g.FirstElementChild.GetAttribute("href");
                //var documentOfSubgroup = await HtmlLoader.LoadAndParseHtmlAsync(subroupUrl);

                string groupName = g.FirstElementChild.TextContent;
                Group group = new Group { Name = groupName };

                //group.Subgroups = await SubgroupParser.ParseAsync(documentOfSubgroup);

                groups.Add(group);
            }
            await AddGroupsToDb(groups);
            await LoadSubgroupsAsync(groups);
        }

        private static async Task AddGroupsToDb(List<Group> groups)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Groups.AddRange(groups);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    //try catch needet to catch errors about added duplicate info
                }
            }
        }

        private static async Task LoadSubgroupsAsync(List<Group> groups)
        {
            foreach (var group in groups)
            {
                string subgroupsUrl = group.SubgroupsUrl;
                var documentOfSubroups = await HtmlLoader.LoadAndParseHtmlAsync(subgroupsUrl);
                await SubgroupParser.ParseAndSaveAsync(documentOfSubroups);
            }
        }
    }
}
