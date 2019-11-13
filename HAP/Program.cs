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
using Util;
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
            Console.WriteLine("Analysising...");
            var files = helper.GetDownPageUrls(startUrls);
            //helper.GetFileUrl(ref files);
            if (helper.Export(files))
                Console.WriteLine("Export Successful!");
            Console.WriteLine("Processing...");
            files.AsParallel().ForAll(a => a.Down());
            //helper.Down(files);
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
                    var nodes = htmlDoc.DocumentNode.SelectNodes(GlobalParas.divList);
                    foreach (HtmlNode secondNode in nodes)
                    {
                        var sNodes = secondNode.SelectNodes("./div/a");
                        foreach (HtmlNode node in sNodes)
                        {
                            var title = node.Attributes["title"].Value;
                            title = FileHelper.FilenameFilter(title);
                            var href = node.Attributes["href"].Value.Replace("/Article", "");
                            var downurl = $"{GlobalParas.KekeWebsite}/mp3{href}";

                            FileClass file = new FileClass(downurl);
                            file.Title = title;
                            file.LocalFullPath = Path.Combine(
                                GlobalParas.DownPath, subjectTitle, $"{title}.mp3");
                            files.Add(file);
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
        
        public bool Export(List<FileClass> files)
        {
            try
            {
                var pathes = new List<string>();
                files.ForEach(a => pathes.Add(Path.GetDirectoryName(a.LocalFullPath)));
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
        
    }

    public class FileClass
    {
        public string DownPage { get; set; }
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public string LocalFullPath { get; set; }
        public List<string> Errors { get; set; }

        public FileClass(string downpage)
        {
            DownPage = downpage;
            Errors = new List<string>();
            GetFileUrl();
            //Thread th = new Thread(GetFileUrl);
            //th.Start();
        }

        private void GetFileUrl()
        {
            try
            {
                HtmlWeb htmlWeb = new HtmlWeb();
                var htmlDoc = htmlWeb.Load(DownPage);
                var trNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='list_box_2']/ul/table/tr");
                foreach (HtmlNode tr in trNodes)
                {
                    if (tr.InnerText.Contains(GlobalParas.Down))
                    {
                        var aNode = tr.SelectSingleNode("./td/a");
                        FileUrl = aNode.Attributes["href"].Value;
                    }
                }
            }
            catch (Exception e)
            {
                Errors.Add($"GetFileUrl Fail:{e.ToString()}");
                FileUrl = null;
            }
        }


        public bool Down()
        {
            if (string.IsNullOrWhiteSpace(FileUrl))
            {
                Errors.Add($"FileUrl is null or empty : {Title}");
                return false;
            }
            try
            {
                using (WebClient wc = new WebClient())
                {
                    if (!File.Exists(LocalFullPath))
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(LocalFullPath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(LocalFullPath));
                        wc.DownloadFile(FileUrl, LocalFullPath);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Errors.Add($"{Title}--{FileUrl}:{e.ToString()}");
                return false;
            }
        }
    }
}
