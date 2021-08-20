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
            //Console.WriteLine("                        Комплентация машины                    ");
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
                Console.WriteLine(model.Complectation);
                Console.WriteLine(model.Date);
                Console.WriteLine(model.Engine);
                Console.WriteLine(model.Body);
                Console.WriteLine("--------------------------------------------");
            }
            //foreach (var tr in listTr)
            //{
            //    List<string> values = new List<string>();
            //    foreach (var value in tr.FirstElementChild.Children)
            //    {
            //        values.Add(value.TextContent);
            //        Console.WriteLine(value.TextContent);
            //    }
            //}
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
                    for (int i = 0; i < models.Length; i++)
                        models[i].Complectation = FillTheFields(indexOfTdElement, trElements)[i] ?? " ";
                    break;
                case "Date":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Date = FillTheFields(indexOfTdElement, trElements)[i] ?? " ";
                    break;
                case "ENGINE 1":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Engine = FillTheFields(indexOfTdElement, trElements)[i] ?? " ";
                    break;
                case "BODY":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Body = FillTheFields(indexOfTdElement, trElements)[i] ?? " ";
                    break;
                case "GRADE":
                    for (int i = 0; i < models.Length; i++)
                        models[i].Grade = FillTheFields(indexOfTdElement, trElements)[i] ?? " ";
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
    }
}
