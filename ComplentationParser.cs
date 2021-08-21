using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ilcatsParser.Ef.Models;
using ilcatsParser.Ef.Models.ComplectationFields;
using ilcatsParser.Ef;

namespace ilcatsParser
{
    class ComplectationParser
    {
        public static async Task<List<ComplectationModel>> ParseAsync(IHtmlDocument document) 
        {
            Console.WriteLine(" ---------------------------------------------------");
            var listTr = document.QuerySelector("tbody").Children;

            List<string> values = AddFields(listTr.FirstOrDefault().Children);

            int countOfComplectations = listTr.Length - 1;
            ComplectationModel[] complectationModels = new ComplectationModel[countOfComplectations];

            for (int i = 0; i < complectationModels.Length; i++)
                complectationModels[i] = new ComplectationModel();

            for (int i = 0; i < values.Count; i++)
                DetectionFieldsAndAddValues(values[i], i, complectationModels, listTr);

            foreach (var model in complectationModels)
            {
                var documentOfGroups = await HtmlLoader.LoadAndParseHtmlAsync(model.GroupUrl);
                model.Groups = await GroupParser.ParseAsync(documentOfGroups);
            }

            await AddComplentationsToDbAsync(complectationModels.ToList());
            return complectationModels.ToList();
        }

        private static async Task AddComplentationsToDbAsync(List<ComplectationModel> complectations)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.ComplectationModels.AddRange(complectations);
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

        private static List<string> AddFields(IHtmlCollection<IElement> thElements)
        {
            List<string> values = new List<string>();
            foreach (var thValue in thElements)
            {
                values.Add(thValue.TextContent);
            }
            return values;
        }

        private static void DetectionFieldsAndAddValues(string field, int indexOfTdElement, 
            ComplectationModel[] models, IHtmlCollection<IElement> trElements)
        {
            switch (field)
            {
                case "Complectation":
                    for (int i = 0; i < models.Length; i++) {
                        models[i].Complectation = FillTheFields(indexOfTdElement, trElements)[i];
                        models[i].GroupUrl = GetGroupsUrl(trElements)[i];
                    }
                    break;
                case "Date":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Date = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "ENGINE 1":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Engine = new Engine { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "BODY":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Body = new Body { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "GRADE":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Grade = new Grade { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "ATM,MTM":
                    for (int i = 0; i < models.Length; i++)
                        models[i].ATMOrMTM = new ATMOrMTM { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "GEAR SHIFT TYPE":
                    for (int i = 0; i < models.Length; i++)
                        models[i].GearShiftType = new GearShiftType { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "DRIVER'S POSITION":
                    for (int i = 0; i < models.Length; i++)
                        models[i].DriversPosition = new DriversPosition { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "NO.OF DOORS":
                    for (int i = 0; i < models.Length; i++)
                        models[i].NoOfDoors = new NoOfDoors { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
                case "DESTINATION 1":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Destination = new Destination { Value = FillTheFields(indexOfTdElement, trElements)[i] };
                    break;
            }
        }

        private static List<string> FillTheFields(int indexOfTdElement, IHtmlCollection<IElement> trElements)
        {
            List<string> result = new List<string>();
            foreach (var complectation in trElements)
            {
                if (complectation != trElements.FirstOrDefault())
                    result.Add(complectation.Children[indexOfTdElement].TextContent);    
            }
            return result;
        }

        private static List<string> GetGroupsUrl(IHtmlCollection<IElement> trElements)
        {
            List<string> result = new List<string>();
            foreach(var complectation in trElements)
            {
                if (complectation != trElements.FirstOrDefault())
                    result.Add(complectation.FirstElementChild.FirstElementChild.FirstElementChild.GetAttribute("href"));
            }
            return result;
        }
    }
}
