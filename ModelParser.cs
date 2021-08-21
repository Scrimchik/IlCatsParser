using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class ModelParser
    {
        public static async Task<List<CarModel>> ParseAsync(IHtmlDocument document)
        {
            Console.WriteLine("---------------------------------------------------");
            var lists = document.All.Where(t => t.ClassName == "List" && t.Children.Any(t => t.ClassName == "Header"));
            List<CarModel> carModels = new List<CarModel>();
            foreach (var item in lists)
            {
                
                string modelName = item.Children.FirstOrDefault(t => t.ClassName == "Header").Children.FirstOrDefault().TextContent;
                CarModel carModel = new CarModel { Name = modelName };
                List<CarSubmodel> carSubmodels = new List<CarSubmodel>();
                foreach (var list in item.Children.FirstOrDefault(t => t.ClassName == "List ").Children)
                {
                    CarSubmodel carSubmodel = new CarSubmodel()
                    {
                        ModelCode = long.Parse(list.Children.FirstOrDefault(t => t.ClassName == "id").Children.FirstOrDefault().TextContent),
                        Period = list.Children.FirstOrDefault(t => t.ClassName == "dateRange").TextContent,
                        Complectations = list.Children.FirstOrDefault(t => t.ClassName == "modelCode").TextContent
                    };
                    

                    var documentOfComplectation = await HtmlLoader.LoadAndParseHtmlAsync(list.Children.FirstOrDefault(t => t.ClassName == "id").Children.FirstOrDefault().GetAttribute("href"));
                    carSubmodel.ComplectationModels = await ComplectationParser.ParseAsync(documentOfComplectation);
                    carSubmodels.Add(carSubmodel);
                }
                carModel.CarSubmodels = carSubmodels;
                carModels.Add(carModel);
            }
            return carModels;
        }

        private static async Task AddCarModelsToDbAsync(List<CarModel> carModels)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.CarModels.AddRange(carModels);
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
