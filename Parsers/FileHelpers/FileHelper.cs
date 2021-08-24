using System;
using System.Net;

namespace ilcatsParser.Parsers.FileHelpers
{
    static class FileHelper
    {
        public static string LoadAndSaveImage(string imageUrl, string imageName)
        {
            string path = @"C:\Users\user\source\repos\ilcatsParser\ilcatsParser\images\" + imageName + ".png";

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(new Uri(imageUrl), path);
            }
            string photoWay = @"\images\" + imageName + ".jpg";
            return photoWay;
        }
    }
}
