using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2
{
    public interface Article
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }

        public abstract void FillParams(string site, HtmlNode Node);
    }
}
