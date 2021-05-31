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
    /// Логика взаимодействия для ArticlePage.xaml
    /// </summary>
    public partial class ArticlePage : Page
    {
        string Link;
        public ArticlePage(string Name, string Text, string Link)
        {
            InitializeComponent();
            this.Link = Link;
            ArticleHeader.Text = Name;
            ArticleText.Text = Text;
        }

        private void ReadArticle(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Link);
        }
    }
}
