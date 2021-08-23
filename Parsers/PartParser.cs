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
                var subpartElements = document.QuerySelectorAll("tr").Where(t => t.GetAttribute("data-id") == partCode && t.ChildElementCount > 1);

                Part part = new Part
                {
                    Code = partCode,
                    Name = partName,
                    SubgroupId = subgroupId,
                    SubpartElements = subpartElements
                };

                parts.Add(part);
            }

            await DbHelper.AddAsync(parts);
            await DbHelperForComplectationModelsParts.MakeRelationsASync(parts, complectationId);
            await LoadSubgroupsAsync(parts, complectationId);
        }

        private static async Task LoadSubgroupsAsync(List<Part> parts, int complectationId)
        {
            foreach (var part in parts)
            {
                int partId = part.Id == 0 ? await GetPartIdASync(part.Code) : part.Id;
                await SubPartsParser.ParseAndSaveASync(part.SubpartElements, partId, complectationId);
            }
        }

        private static async Task<int> GetPartIdASync(string partCode)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.Parts.Where(t => t.Code == partCode).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
