using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для NewsListPage.xaml
    /// </summary>
    public partial class NewsListPage : Page
    {
        public NewsListPage()
        {
            InitializeComponent();

            Articles.Children.Clear();
            foreach (Article art in MainWindow.articlesList)
            {
                Button tb = new Button();
                tb.Click += ReadArticle;
                tb.Content = art.Name;
                Articles.Children.Add(tb);
            }
        }

        private void ReadArticle(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                foreach (Article art in MainWindow.articlesList)
                {
                    if (btn.Content.ToString() == art.Name)
                    {
                        MainWindow.frame.Content = new ArticlePage(art.Name, art.Text, art.Link);
                        break;
                    }
                }
            }
        }
    }
}
