﻿using System.Threading.Tasks;

namespace ilcatsParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var document = await HtmlLoader.LoadAndParseHtmlAsync("/toyota/?function=getModels&market=EU");

            await ModelParser.ParseAsync(document); 
              
        }
    }
}