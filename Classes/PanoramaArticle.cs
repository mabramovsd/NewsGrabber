using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WpfApp2
{
    public class PanoramaArticle : Article
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public async void FillParams(string site, HtmlNode Node)
        {
            Link = site + Node.GetAttributeValue("href", "");
            var NewsHeaderNode = Node.SelectSingleNode(".//div[contains(@class, 'wrapper')]");
            Name = NewsHeaderNode.SelectSingleNode(".//h3").InnerHtml;


            WebRequest request = WebRequest.Create(Link);
            using WebResponse response = await request.GetResponseAsync();
            using Stream stream1 = response.GetResponseStream();
            HtmlDocument NewsDocument = new HtmlDocument();
            NewsDocument.Load(stream1);

            var NewsTextNode = NewsDocument.DocumentNode.SelectSingleNode(".//div[contains(@class, 'entry-contents')]");
            Text = NewsTextNode.InnerText;
        }
    }
}
