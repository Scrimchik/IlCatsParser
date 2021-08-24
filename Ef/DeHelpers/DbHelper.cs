using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilcatsParser.Ef.DbHelpers
{
    static class DbHelper
    {
        public static bool IsFirstLoading { get; set; }

        public static async Task AddAsync<T>(List<T> elements)
        {
            if (IsFirstLoading)
                await AddToDbCollectionAsync(elements);
            else
                await AddToDbOneByOneElementsAsync(elements);
        }

        private static async Task AddToDbCollectionAsync<T>(List<T> elements)
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var element in elements)
                    db.Entry(element).State = EntityState.Added;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    //needed to catch an exception when adding existing data
                }

            }
        }

        private static async Task AddToDbOneByOneElementsAsync<T>(List<T> elements)
        {
            foreach (var element in elements)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(element).State = EntityState.Added;
                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        //needed to catch an exception when adding existing data
                    }
                }
            }
        }
    }
}
