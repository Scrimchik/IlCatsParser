using AngleSharp.Html.Dom;
using ilcatsParser.Ef;
using ilcatsParser.Ef.DbHelpers;
using ilcatsParser.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser.Parsers
{
    static class CarModelsParser
    {
        public static async Task ParseAndSaveAsync(IHtmlDocument document) 
        {
            var carModelElements = document.All.Where(t => t.ClassName == "List" && t.Children.Any(t => t.ClassName == "Header"));
            List<CarModel> carModels = new List<CarModel>();

            foreach (var carModelElement in carModelElements)
            {
                string carModelName = carModelElement.Children.FirstOrDefault(t => t.ClassName == "Header").TextContent;
                var carSubmodelElement = carModelElement.Children.FirstOrDefault(t => t.ClassName == "List ");

                carModels.Add(new CarModel { Name = carModelName, CarSubmodelsElement = carSubmodelElement });
            }

            await DbHelper.AddAsync(carModels);
            await LoadCarSubModelsAsync(carModels);
        }

        private static async Task LoadCarSubModelsAsync(List<CarModel> carModels)
        {
            foreach (var carModel in carModels)
            {
                int carModelId = carModel.Id == 0 ? await GetCarModelIdAsync(carModel.Name) : carModel.Id;
                await CarSubmodelsParser.ParseAndSaveAsync(carModel.CarSubmodelsElement, carModelId);
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
