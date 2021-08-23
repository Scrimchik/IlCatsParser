using ilcatsParser.Ef;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var document = await HtmlLoader.LoadAndParseHtmlAsync("/toyota/?function=getModels&market=EU");
            DbHelper.IsFirstLoading = false;
            await CarModelParser.ParseAndSaveAsync(document);
            
            await DbHelper.AddAsync(new List<string>());
        }
    }
}
