using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CsvHelper;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.IO;
using System.Globalization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            generate_button();
        }

        public void generate_button() {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://lowcygier.pl/darmowe/");
            var Headers = doc.DocumentNode.CssSelect("h2.post-title > a");
            var Headers2 = doc.DocumentNode.CssSelect("div.nc-main > div.nc-meta > ul");
            int i = 0;
            foreach (var item in Headers)
            {
                if (Headers2.ElementAt(i).InnerText.Contains("PC"))
                {
                    item.CssSelectAncestors("div.nc-main > div.nc-meta > ul");
                    Button btn = new Button();
                    btn.Tag = item.Attributes["href"].Value;
                    btn.Content = item.InnerText;
                    btn.Click += new RoutedEventHandler(Button_Click);
                    lbResult.Children.Add(btn);
                }
                i++;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string myValue = btn.Tag.ToString();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                Process.Start("xdg-open", myValue);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                Process.Start("open", myValue);
            }
            else { 
                Process.Start("cmd", "/c start " + myValue);
            } 
        }
    }
}
