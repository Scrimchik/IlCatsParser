using ilcatsParser.Ef.DbHelpers;
using ilcatsParser.Parsers;
using System;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteInitialMessage();

            var document = await HtmlLoader.LoadAndParseHtmlAsync("/toyota/?function=getModels&market=EU");

            Console.Clear();
            Console.WriteLine("Parsing started...");
            await CarModelsParser.ParseAndSaveAsync(document);
            Console.WriteLine("Parsing ended");
        }

        static void WriteInitialMessage()
        {
            Console.WriteLine("Choose a method for parsing data:");
            Console.WriteLine("1. The first one is needed for the first parsing. (not save new data (fastest))");
            Console.WriteLine("2. The second option is needed to update the data, with this option, the new data will be save. (will save new data (slowest))");
            Console.WriteLine("select by writing 1 or 2 ...");
            string choice = Console.ReadLine();
            if (choice == "1")
                DbHelper.IsFirstLoading = true;
            else
                DbHelper.IsFirstLoading = false;
        }


    }
}
