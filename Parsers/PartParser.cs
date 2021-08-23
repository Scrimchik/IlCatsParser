using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    class PartParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document, int subgroupId, int complectationId)
        {
            Console.WriteLine("     -----------------------------------------------");
            var partElements = document.QuerySelectorAll("th").Where(t => t.ParentElement.HasAttribute("data-id"));
            List<Part> parts = new List<Part>();

            foreach (var partElement in partElements)
            {
                //InnerHtml because partElement contains &nbsp
                List<string> partData = partElement.InnerHtml.Split("&nbsp;").ToList();
                string partCode = partData[0];
                string partName = partData[1];

                Part part = new Part
                {
                    Code = partCode,
                    Name = partName,
                    SubgroupId = subgroupId
                };

                parts.Add(part);
            }

            await DbHelper.AddAsync(parts);
            await DbHelperForComplectationModelsParts.MakeRelationsASync(parts, complectationId);
        }
    }
}
