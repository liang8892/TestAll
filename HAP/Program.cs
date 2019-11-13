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
using Console = System.Console;

namespace HAP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Urls:");
            var startfile = Console.ReadLine();
            if (!File.Exists(startfile))
            {
                Console.WriteLine("Wrong filepath.");
                Console.ReadKey();
                return;
            }

            var startUrls = File.ReadAllLines(startfile).ToList();
            var helper = new Helper();
            var files = helper.GetDownPageUrls(startUrls);
            Console.WriteLine("Analysising...");
            helper.GetFileUrl(ref files);
            if (helper.Export(files))
                Console.WriteLine("Export Successful!");
            Console.WriteLine("Processing...");
            helper.Down(files);
            Console.WriteLine("Complete!");
            Console.ReadKey();
        }
    }

    public class Helper
    {
        private object locker = new object();

        public List<FileClass> GetDownPageUrls(List<string> startUrls)
        {
            List<FileClass> files = new List<FileClass>();
            startUrls.AsParallel().ForAll(a =>
            {
                try
                {
                    var tmp = a.Split(',');
                    var startUrl = tmp[0];
                    var subjectTitle = tmp[1];
                    //var downPageUrls = new Dictionary<string, string>();
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

                                        FileClass file = new FileClass();
                                        file.DownPage = downurl;
                                        file.Title = title;
                                        file.LocalFullPath = Path.Combine(
                                            GlobalParas.DownPath, subjectTitle, $"{title}.mp3");
                                        files.Add(file);
                                        //if (!downPageUrls.Keys.Contains(title))
                                        //    downPageUrls.Add(title, downurl);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            return files;
        }


        public void GetFileUrl(ref List<FileClass> files)
        {
            files.AsParallel().ForAll(file =>
            {
                try
                {
                    HtmlWeb htmlWeb = new HtmlWeb();
                    var htmlDoc = htmlWeb.Load(file.DownPage);
                    var trNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='list_box_2']/ul/table/tr");
                    foreach (HtmlNode tr in trNodes)
                    {
                        if (tr.InnerText.Contains(GlobalParas.Down))
                        {
                            var aNode = tr.SelectSingleNode("./td/a");
                            file.FileUrl = aNode.Attributes["href"].Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }


        public bool Export(List<FileClass> files)
        {
            try
            {
                var pathes = new List<string>();
                files.ForEach(a=>pathes.Add(Path.GetDirectoryName(a.LocalFullPath)));
                pathes = pathes.Distinct().ToList();
                pathes.ForEach(path =>
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    List<string> export = new List<string>();
                    files.ForEach(file =>
                    {
                        if (Path.GetDirectoryName(file.LocalFullPath) == path)
                            export.Add($"{file.Title},{file.FileUrl}");
                    });
                    File.WriteAllLines($"{path}\\add.txt", export);
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool Down(List<FileClass> files)
        {
            List<string> errors = new List<string>();
            if (files != null)
            {
                files.AsParallel().ForAll(file =>
                {
                    using (WebClient wc = new WebClient())
                    {
                        try
                        {
                            if (!File.Exists(file.LocalFullPath))
                            {
                                if (!Directory.Exists(Path.GetDirectoryName(file.LocalFullPath)))
                                    Directory.CreateDirectory(Path.GetDirectoryName(file.LocalFullPath));
                                wc.DownloadFile(file.FileUrl, file.LocalFullPath);
                            }
                        }
                        catch (Exception e)
                        {
                            lock (locker)
                            {
                                errors.Add($"{file.Title}——{file.FileUrl}：{e.Message}");
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

    public class FileClass
    {
        public string DownPage { get; set; }
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public string LocalFullPath { get; set; }
    }
}
