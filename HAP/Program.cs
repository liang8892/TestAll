using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Url:");
            var startUrl = Console.ReadLine();
            var helper = new Helper();
            var downPageUrls = helper.GetDownPageUrls(startUrl);
            Console.WriteLine("Analysising...");
            var fileUrls = helper.GetFileUrl(downPageUrls);
            if (helper.Export(fileUrls))
                Console.WriteLine("Export Successful!");
            Console.WriteLine("Processing...");
            helper.Down(fileUrls);
            Console.WriteLine("Complete!");
            Console.ReadKey();
        }
    }

    public class Helper
    {
        private object locker = new object();

        public Dictionary<string, string> GetDownPageUrls(string startUrl)
        {
            var downPageUrls = new Dictionary<string, string>();
            HtmlWeb htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load(startUrl);
            var node = htmlDoc.DocumentNode.SelectSingleNode(GlobalParas.divList);

            foreach (HtmlNode secondNode in node.ChildNodes)
            {
                if (secondNode.Name == "div")
                {
                    foreach (HtmlNode thirdNode in secondNode.ChildNodes)
                    {
                        foreach (HtmlNode n in thirdNode.ChildNodes)
                        {
                            if (n.Name == "a")
                            {
                                var title = n.Attributes["title"].Value;
                                title = Util.FileHelper.FilenameFilter(title);
                                var href = n.Attributes["href"].Value;
                                href = href.Replace("/Article", "");
                                var downurl = $"{GlobalParas.KekeWebsite}/mp3{href}";
                                if (!downPageUrls.Keys.Contains(title))
                                    downPageUrls.Add(title, downurl);
                            }
                        }
                    }
                }
            }
            return downPageUrls;
        }


        public Dictionary<string, string> GetFileUrl(Dictionary<string, string> downPageUrls)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            downPageUrls.Keys.AsParallel().ForAll(key =>
            {
                downPageUrls.TryGetValue(key, out string value);
                HtmlWeb htmlWeb = new HtmlWeb();
                var htmlDoc = htmlWeb.Load(value);
                var trNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='list_box_2']/ul/table/tr");
                foreach (HtmlNode tr in trNodes)
                {
                    if (tr.InnerText.Contains(GlobalParas.Down))
                    {
                        var aNode = tr.SelectSingleNode("./td/a");
                        var href = aNode.Attributes["href"].Value;
                        lock (locker)
                        {
                            if (!result.Keys.Contains(key))
                                result.Add(key, href);
                        }
                    }
                }
            });
            return result;
        }


        public bool Export(Dictionary<string, string> fileUrls)
        {
            try
            {
                foreach (KeyValuePair<string, string> item in fileUrls)
                    File.AppendAllText(@"d:\down\add.txt", $"{item.Key}:{item.Value}\r\n");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool Down(Dictionary<string, string> fileUrls)
        {
            List<string> errors = new List<string>();
            if (fileUrls != null)
            {
                fileUrls.Keys.AsParallel().ForAll(key =>
                {
                    using (WebClient wc = new WebClient())
                    {
                        fileUrls.TryGetValue(key, out string value);
                        try
                        {
                            if (!File.Exists(key))
                                wc.DownloadFile(value, $"d:\\down\\{key}.mp3");
                        }
                        catch (Exception e)
                        {
                            lock (locker)
                            {
                                errors.Add($"{key}——{value}：{e.Message}");
                            }
                        }
                    }
                });
            }
            else
            {
                errors.Add("fileUrls为null。");
            }

            if (errors.Count > 0)
            {
                var export = new List<string>();
                export.Add($"{DateTime.Now:yyyy-MM-dd hh:mm:ss}\r\n");
                export.AddRange(errors);
                export.Add("---------------------------------------------------\r\n\r\n");
                File.AppendAllLines($"d:\\down\\errors.txt", export);
            }
            return errors.Count > 0;

        }
    }
}
