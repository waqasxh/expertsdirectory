using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertsDirectory.API.Utility
{
    public class WebScrapper
    {
        public async Task<List<string> >RetrieveHeaders(string websiteUrl)
        {
            var headers = new List<string>();

            var htmlWeb = new HtmlWeb();
            var htmlDocument = await htmlWeb.LoadFromWebAsync(websiteUrl);

            var h1s = htmlDocument.DocumentNode.Descendants("h1").Select(x => x.InnerText).ToList();
            var h2s = htmlDocument.DocumentNode.Descendants("h2").Select(x => x.InnerText).ToList();
            var h3s = htmlDocument.DocumentNode.Descendants("h3").Select(x => x.InnerText).ToList();

            headers.AddRange(h1s);
            headers.AddRange(h2s);
            headers.AddRange(h3s);

            return headers;
        }
    }
}
