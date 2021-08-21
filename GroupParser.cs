using AngleSharp.Html.Dom;
using ilcatsParser.Ef.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class GroupParser
    {

        public static async Task ParseAsync(IHtmlDocument document)
        {
            var groupNames = document.All.Where(t => t.ClassName == "name");
            List<Group> groups = new List<Group>();
            foreach (var g in groupNames)
            {
                string groupName = g.FirstElementChild.TextContent;
                groups.Add(new Group { Name = groupName });
                string subroupUrl = g.FirstElementChild.GetAttribute("href");
                var documentOfSubgroup = await HtmlLoader.LoadAndParseHtmlAsync(subroupUrl);
                await SubgroupParser.ParseAsync(documentOfSubgroup);
            }
        }
    }
}
