using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class SubgroupParser
    {
        public static async Task<List<Subgroup>> ParseAsync(IHtmlDocument document)
        {
            Console.WriteLine("   ---------------------------------------------------");
            var subroupNames = document.All.Where(t => t.ClassName == "name");
            List<Subgroup> subgroups = new List<Subgroup>();

            foreach (var name in subroupNames)
                subgroups.Add(new Subgroup { Name = name.TextContent });

            await AddSubgroupsToDbAsync(subgroups);
            return subgroups;
        }

        private static async Task AddSubgroupsToDbAsync(List<Subgroup> subgroups)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Subgroups.AddRange(subgroups);
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
    }
}
