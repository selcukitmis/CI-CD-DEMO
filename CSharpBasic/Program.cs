using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var pg = GetPageCount();
            Console.WriteLine(pg);
            Console.ReadLine();
        }

        private static string GetContent(string urlAddress)
        {
            Uri url = new Uri(urlAddress);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string html = client.DownloadString(url);
            return html;
        }

        private static int GetPageCount()
        {
            Uri url = new Uri("https://www.w3schools.com/");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            // Adresten istek yapı html kodlarını indiriyoruz.     

            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            // İndirdiğimiz html kodlarını bir HtmlDocment nesnesine yüklüyoruz.     
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//a[@class='w3-bar-item w3-button']");
            // Html dökümanı içndeki h2 etiketlerinden class'ı  tutheader olanları liste halinde alıyoruzç    
            return basliklar.Count;
        }
    }
}
