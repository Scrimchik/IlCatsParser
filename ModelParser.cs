using AngleSharp.Html.Dom;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class ModelParser
    {
        public static async Task ParseCarModelAsync(IHtmlDocument document)
        {
            var lists = document.All.Where(t => t.ClassName == "List" && t.Children.Any(t => t.ClassName == "Header"));
            foreach (var item in lists)
            {
                //Console.WriteLine("Название модели: {0}", item.Children.FirstOrDefault(t => t.ClassName == "Header").Children.FirstOrDefault().TextContent);
                foreach (var list in item.Children.FirstOrDefault(t => t.ClassName == "List ").Children)
                {
                    //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    //Console.WriteLine("Код модели: {0}", list.Children.FirstOrDefault(t => t.ClassName == "id").Children.FirstOrDefault().TextContent); 
                    //Console.WriteLine("Период: {0}", list.Children.FirstOrDefault(t => t.ClassName == "dateRange").TextContent);
                    //Console.WriteLine("Комплентация: {0}", list.Children.FirstOrDefault(t => t.ClassName == "modelCode").TextContent);
                    //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    var documentOfComplectation = await HtmlLoader.LoadAndParseHtmlAsync(list.Children.FirstOrDefault(t => t.ClassName == "id").Children.FirstOrDefault().GetAttribute("href"));
                    await ComplectationParser.ParseAsync(documentOfComplectation);
                }
                //Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
