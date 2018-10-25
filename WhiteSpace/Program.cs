using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"D:\Lvxl\01_Test\2018\TestAll\test test";
            string path2 = @"D:\Lvxl\01_Test\2018\TestAll\test";

            var files1 = Directory.GetFiles(path1);
            var files2 = Directory.GetFiles(path2);

            Console.WriteLine(path1);
            Console.WriteLine(string.Join("\r\n", files1));
            Console.WriteLine(path2);
            Console.WriteLine(string.Join("\r\n", files2));

            Console.ReadKey();
        }
    }
}
