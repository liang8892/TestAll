using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneObjectTwoList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestClass> list1 = new List<TestClass>();
            List<TestClass> list2 = new List<TestClass>();

            TestClass test = new TestClass {ID = 9527};

            list1.Add(test);
            list2.Add(test);
            
            Console.WriteLine(list1[0].Equals(list2[0]) ?"相同" :"不同");

            list2[0].ID = 5566;

            Console.WriteLine(list1[0].ID);

            Console.ReadKey();



        }
    }

    class TestClass
    {
        public int ID { get; set; }
    }
}
