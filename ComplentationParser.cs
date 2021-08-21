using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ilcatsParser.Ef.Models;

namespace ilcatsParser
{
    class ComplectationParser
    {
        public static async Task ParseAsync(IHtmlDocument document) 
        {
            var listTr = document.QuerySelector("tbody").Children;
            Console.WriteLine("    Комплектация машины                    ");
            List<string> values = AddFields(listTr.FirstOrDefault().Children);
            int countOfComplectations = listTr.Length - 1;
            ComplectationModel[] complectationModels = new ComplectationModel[countOfComplectations];

            for (int i = 0; i < complectationModels.Length; i++)
                complectationModels[i] = new ComplectationModel();

            for (int i = 0; i < values.Count; i++)
            {
                DetectionFieldsAndAddValues(values[i], i, complectationModels, listTr);
            }
            foreach (var model in complectationModels)
            {
                Console.WriteLine("    Комплектация: {0}", model.Complectation);
                Console.WriteLine("    Комплектация: {0}", model.Date);
                Console.WriteLine("    Комплектация: {0}", model.Engine);
                Console.WriteLine("    Комплектация: {0}", model.Body);
                Console.WriteLine("    Комплектация: {0}", model.Grade);
                Console.WriteLine("    Комплектация: {0}", model.ATMOrMTM);
                Console.WriteLine("    Комплектация: {0}", model.GearShiftType);
                Console.WriteLine("    Комплектация: {0}", model.DriversPosition);
                Console.WriteLine("    Комплектация: {0}", model.NoOfDoors);
                Console.WriteLine("    Комплектация: {0}", model.Destination);
                var documentOfGroups = await HtmlLoader.LoadAndParseHtmlAsync(model.GroupUrl);
                await GroupParser.ParseAsync(documentOfGroups);
                Console.WriteLine("--------------------------------------------");
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
                        models[i].Engine = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "BODY":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Body = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "GRADE":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Grade = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "ATM,MTM":
                    for (int i = 0; i < models.Length; i++)
                        models[i].ATMOrMTM = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "GEAR SHIFT TYPE":
                    for (int i = 0; i < models.Length; i++)
                        models[i].GearShiftType = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "DRIVER'S POSITION":
                    for (int i = 0; i < models.Length; i++)
                        models[i].DriversPosition = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "NO.OF DOORS":
                    for (int i = 0; i < models.Length; i++)
                        models[i].NoOfDoors = FillTheFields(indexOfTdElement, trElements)[i];
                    break;
                case "DESTINATION 1":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Destination = FillTheFields(indexOfTdElement, trElements)[i];
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
