using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DateTimeTest
{
    class Program
    {
        private static readonly string ERROR_PATH = @"C:\copyErrors.txt";

        static void Main(string[] args)
        {
            var PMstart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0);
            var AMend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 30, 0);

            DateTime PMst = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 12:30:00");
            DateTime AMe = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 11:30:00");

            int i = 0;
            while (i<5)
            {
                if (PMst == PMstart && AMe == AMend)
                {
                    Console.WriteLine("相等。");
                }
                else
                {
                    Console.WriteLine("不相等。");
                }
                i++;
                
            }
            Console.ReadKey();
        }
    }
}
