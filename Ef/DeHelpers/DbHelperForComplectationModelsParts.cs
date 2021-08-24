using ilcatsParser.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Ef.DbHelpers
{
    static class DbHelperForComplectationModelsParts
    {
        public static async Task MakeRelationsASync(List<Part> parts, int complectationId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<string> partCodes = FillThePartCodes(parts);
                List<Part> partsFromDb = await db.Parts.Where(t => partCodes.Contains(t.Code)).ToListAsync();
                ComplectationModel complectation = await db.ComplectationModels.FindAsync(complectationId);

                foreach (var part in partsFromDb)
                    part.ComplectationModels.Add(complectation);

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

        private static List<string> FillThePartCodes(List<Part> parts)
        {
            List<string> result = new List<string>();

            foreach (var part in parts)
            {
                result.Add(part.Code);
            }

            return result;
        }
    }
}
