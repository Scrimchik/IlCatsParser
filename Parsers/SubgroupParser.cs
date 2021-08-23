using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    class SubgroupParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document, int groupId)
        {
            Console.WriteLine("    ---------------------------------------------------");
            var subroupElements = document.All.Where(t => t.ClassName == "name");
            List<Subgroup> subgroups = new List<Subgroup>();

            foreach (var subgroup in subroupElements)
                subgroups.Add(new Subgroup { Name = subgroup.TextContent, GroupId = groupId });

            await DbHelper.AddAsync(subgroups);
        }
    }
}
