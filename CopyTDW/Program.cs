using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyTDW
{
    class Program
    {
        private static readonly string ERROR_PATH = @"C:\copyErrors.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Input TIF root Dir:");
            string rootDir = Console.ReadLine();
            Console.WriteLine("Input TFW Dir:");
            string tfwDir = Console.ReadLine();

            int allTifs = 0;
            int tifWithOutTfw = 0;
            int success = 0;

            string[] dirs = Directory.GetDirectories(rootDir, "*", SearchOption.TopDirectoryOnly);
            foreach (string dir in dirs)
            {
                string[] tifs = Directory.GetFiles(dir, "*.tif", SearchOption.AllDirectories);
                if (tifs.Length > 0)
                {
                    allTifs += tifs.Length;
                    foreach (string tif in tifs)
                    {
                        string tfwName = Path.GetFileName(tif).Replace(".tif", ".tfw");
                        string tfwPath = Path.Combine(tfwDir, tfwName);
                        string tfwPathNew = Path.Combine(Path.GetDirectoryName(tif), tfwName);
                        if (File.Exists(tfwPath) && !File.Exists(tfwPathNew))
                        {
                            tifWithOutTfw++;
                            try
                            {
                                File.Copy(tfwPath, tfwPathNew, false);
                                Console.WriteLine(tfwName + "成功！");
                                success++;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(tfwName + "拷贝失败！");
                                try
                                {
                                    File.AppendAllText(ERROR_PATH, tfwPathNew + "：" + e.ToString() + "\r\n");
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine("错误日志写入出错：" + exception);
                                    Console.ReadKey();
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            string result = $"共{allTifs}个tif文件，其中{tifWithOutTfw}个没有tfw，成功拷贝了{success}个tfw！";
            Console.WriteLine(result);
            try
            {
                File.AppendAllText(ERROR_PATH, result);
            }
            catch (Exception e)
            {
                Console.WriteLine("错误日志写入出错：" + e);
            }
            Console.ReadKey();
        }
    }
}
