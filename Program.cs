using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var document = await HtmlLoader.LoadAndParseHtmlAsync("/toyota/?function=getModels&market=EU");

            List<CarModel> carmodels = await ModelParser.ParseAsync(document); 

            using(AppDbContext db = new AppDbContext())
            {
                db.CarModels.AddRange(carmodels);
                await db.SaveChangesAsync();
            }
              
        }
    }
}
