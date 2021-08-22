using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilcatsParser.Ef
{
    static class DbHelper
    {
        public static async Task AddListAsync<T>(List<T> elements)
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var element in elements)
                    db.Entry(element).State = EntityState.Added;

                await db.SaveChangesAsync();
            }
        }
    }
}
