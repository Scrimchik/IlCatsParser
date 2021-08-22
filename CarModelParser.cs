using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class CarModelParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document) 
        {
            Console.WriteLine("-----------------------------------------------");
            var carModelElements = document.All.Where(t => t.ClassName == "List" && t.Children.Any(t => t.ClassName == "Header"));
            List<CarModel> carModels = new List<CarModel>();

            foreach (var carModelElement in carModelElements)
            {
                string carModelName = carModelElement.Children.FirstOrDefault(t => t.ClassName == "Header").TextContent;
                IElement carSubmodelElement = carModelElement.Children.FirstOrDefault(t => t.ClassName == "List ");
                carModels.Add(new CarModel { Name = carModelName, CarSubmodelsElement = carSubmodelElement });
            }

            await AddCarModelsToDbAsync(carModels);
            await LoadCarSubModelsAsync(carModels);
        }

        private static async Task AddCarModelsToDbAsync(List<CarModel> carModels)
        {
            using(AppDbContext db = new AppDbContext())
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

        private static async Task LoadCarSubModelsAsync(List<CarModel> carModels)
        {
            foreach (var carModel in carModels)
            {
                int carModelId = carModel.Id == 0 ? await GetCarModelIdAsync(carModel.Name) : carModel.Id;
                await CarSubmodelParser.ParseAndSaveAsync(carModel.CarSubmodelsElement, carModelId);
            }
        }

        private static async Task<int> GetCarModelIdAsync(string carModelName)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.CarModels.Where(t => t.Name == carModelName).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
