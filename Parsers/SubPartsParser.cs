using AngleSharp.Dom;
using ilcatsParser.Ef.DbHelpers;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    static class SubPartsParser
    {
        public static async Task ParseAndSaveASync(IEnumerable<IElement> subpartElements, int partId, int complectationId)
        {
            List<Subpart> subparts = new List<Subpart>();

            foreach (var subpartElement in subpartElements)
            {
                int count = 0;
                try
                {
                    count = int.Parse(subpartElement.QuerySelector("div.count").TextContent);
                }
                catch (Exception)
                {

                    //need because some of count fields may be cross
                }

                Subpart subpart = new Subpart
                {
                    Code = subpartElement.QuerySelector("div.number").TextContent,
                    Count = count,
                    Date = subpartElement.QuerySelector("div.dateRange").TextContent,
                    Info = subpartElement.QuerySelector("div.usage").TextContent,
                    PartId = partId
                };

                subparts.Add(subpart);
            }

            await DbHelper.AddAsync(subparts);
            await DbHelperForComplectationModelsSubparts.MakeRelationsASync(subparts, complectationId);
        }
    }
}
