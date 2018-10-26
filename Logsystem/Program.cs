using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace Logsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BUser buser = new BUser();
            buser.DbHelper = new SQLServerHelper();
            List<string> users = buser.GetAllUser();
            Console.WriteLine("All UserName:\r\n"+string.Join("，", users));

            Console.WriteLine("quit...");
            Console.ReadKey();
        }
    }
}
