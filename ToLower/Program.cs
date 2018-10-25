using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLower
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string lower;
                do
                {
                    Console.WriteLine("Input:");
                    lower = Console.ReadLine().ToLower();
                    if (lower == "quit")
                        break;
                    Console.WriteLine("Result:\r\n" + lower);
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
