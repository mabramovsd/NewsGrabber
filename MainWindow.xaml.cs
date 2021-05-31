using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using HtmlAgilityPack;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public static List<Article> articlesList = new List<Article>();
        public static Frame frame;

        public MainWindow()
        {
            InitializeComponent();

            frame = Fr;

            PanoramaLoad(null, null);
            ChukotkaLoad(null, null);
        }

        private async System.Threading.Tasks.Task PanoramaLoad(object sender, RoutedEventArgs e)
        {
            string site = "https://panorama.pub";
            WebRequest NewsListRequest = WebRequest.Create(site);
            using WebResponse NewsListResponse = await NewsListRequest.GetResponseAsync();
            using Stream stream = NewsListResponse.GetResponseStream();
            HtmlDocument document = new HtmlDocument();
            document.Load(stream);

            var NewsNodes = document.DocumentNode.SelectNodes("//a[contains(@class, 'entry big')]");

            for (int i = 0; i < NewsNodes.Count; i++)
            {
                Article article = new PanoramaArticle();
                article.FillParams(site, NewsNodes[i]);
                articlesList.Add(article);
            }

            Fr.Content = new NewsListPage();
        }
        private async System.Threading.Tasks.Task ChukotkaLoad(object sender, RoutedEventArgs e)
        {
            string site = "https://old.prochukotku.ru";
            WebRequest NewsListRequest = WebRequest.Create(site + "/news/main/");
            using WebResponse NewsListResponse = await NewsListRequest.GetResponseAsync();
            using Stream stream = NewsListResponse.GetResponseStream();
            HtmlDocument document = new HtmlDocument();
            document.Load(stream);

            var NewsBlockNodes = document.DocumentNode.SelectNodes(".//div[contains(@class, 'item nuclear')]");
            for (int i = 0; i < 10; i++)
            {
                Article article = new ChukotkaArticle();
                var NewsNodes = NewsBlockNodes[i].SelectNodes(".//a");
                article.FillParams(site, NewsNodes[0]);
                articlesList.Add(article);
            }
            Fr.Content = new NewsListPage();
        }
    }
}
