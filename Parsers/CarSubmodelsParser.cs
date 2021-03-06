using AngleSharp.Dom;
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
    static class CarSubmodelsParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="carSubmodelsElement">Html element, with the List html class, which contains collections of car submodels data</param>
        /// <param name="carModelId">Id of CarModel line for establish a connection</param>
        /// <returns></returns>
        public static async Task ParseAndSaveAsync(IElement carSubmodelsElement, int carModelId)
        {
            List<CarSubmodel> carSubmodels = new List<CarSubmodel>();

            //Go in html List html element, which contains car submodel data
            foreach (var carSubmodelElement in carSubmodelsElement.Children)
            {
                CarSubmodel carSubmodel = new CarSubmodel()
                {
                    ModelCode = carSubmodelElement.Children.FirstOrDefault(t => t.ClassName == "id").TextContent,
                    ComplentationsUrl = carSubmodelElement.Children.FirstOrDefault(t => t.ClassName == "id").FirstElementChild.GetAttribute("href"),
                    Period = carSubmodelElement.Children.FirstOrDefault(t => t.ClassName == "dateRange").TextContent,
                    Complectations = carSubmodelElement.Children.FirstOrDefault(t => t.ClassName == "modelCode").TextContent,
                    CarModelId = carModelId
                };

                carSubmodels.Add(carSubmodel);
            }

            await DbHelper.AddAsync(carSubmodels);
            await LoadComplentationsAsync(carSubmodels);
        }

        private static async Task LoadComplentationsAsync(List<CarSubmodel> carSubmodels)
        {
            foreach (var carSubmodel in carSubmodels)
            {
                string pageOfComplentationsUrl = carSubmodel.ComplentationsUrl;
                var documentOfComplentations = await HtmlLoader.LoadAndParseHtmlAsync(pageOfComplentationsUrl);
                int carSubmodelId = carSubmodel.Id == 0 ? await GetCarSubmodelIdASync(carSubmodel.ModelCode) : carSubmodel.Id;
                await ComplectationsParser.ParseAndSaveAsync(documentOfComplentations, carSubmodelId);
            }
        }

        private static async Task<int> GetCarSubmodelIdASync(string carSubmodelCode)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return await db.CarSubmodels.Where(t => t.ModelCode == carSubmodelCode).Select(t => t.Id).FirstOrDefaultAsync();
            }
        }
    }
}
