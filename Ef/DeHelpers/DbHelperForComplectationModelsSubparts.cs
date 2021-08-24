using ilcatsParser.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Ef.DbHelpers
{
    static class DbHelperForComplectationModelsSubparts
    {
        public static async Task MakeRelationsASync(List<Subpart> subparts, int complectationId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<string> subpartCodes = FillTheSubpartCodes(subparts);
                List<Subpart> subpartsFromDb = await db.Subparts.Where(t => subpartCodes.Contains(t.Code)).ToListAsync();
                ComplectationModel complectation = await db.ComplectationModels.FindAsync(complectationId);

                foreach (var subpart in subpartsFromDb)
                    subpart.ComplectationModels.Add(complectation);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    //needed to catch an exception when adding existing data  
                }

            }
        }

        private static List<string> FillTheSubpartCodes(List<Subpart> subparts)
        {
            List<string> result = new List<string>();

            foreach (var part in subparts)
            {
                result.Add(part.Code);
            }

            return result;
        }
    }
}
