using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net.Http;
using System.Threading.Tasks;

namespace ilcatsParser
{
    static class HtmlLoader
    {
        private const string baseUrl = "https://www.ilcats.ru/";

        /// <summary>
        /// Go to page, and load htmlDocument, then parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Parsed document</returns>
        public static async Task<IHtmlDocument> LoadAndParseHtmlAsync(string url)
        {
            string source;

            using(HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(baseUrl + url + "&language=en"))
                {
                    source = await response.Content.ReadAsStringAsync();
                }
            }

            var parser = BrowsingContext.New(Configuration.Default).GetService<IHtmlParser>();
            var document = await parser.ParseDocumentAsync(source);
            return document;
        }
    }
}
