using AngleSharp.Html.Dom;
using System.Linq;
using System.Threading.Tasks;

namespace ilcatsParser
{
    class SubgroupParser
    {

        public static async Task ParseAsync(IHtmlDocument document)
        {
            var subroupNames = document.All.Where(t => t.ClassName == "name");
            foreach (var name in subroupNames)
            {
                System.Console.WriteLine("Название подгруппы: {0}", name.TextContent);
            }
        }
    }
}
