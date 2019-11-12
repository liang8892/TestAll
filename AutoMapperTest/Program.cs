using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoMapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化
            AutoMapperHelper.Initialization();


            //映射
            var source = new SourceClass()
            {
                Address = "qhd",
                Age = 25,
                Company = "fugro",
                ID = 110,
                Name = "Tom"
            };

            //var dest = AutoMapperHelper.MapTo<SourceClass, DestClass>(source);
            //WriteLines("完全一致", dest);

            //var dest = AutoMapperHelper.MapTo<SourceClass, DestClass2>(source);
            //WriteLines("比源类属性多", dest);

            //var dest = AutoMapperHelper.MapTo<SourceClass, DestClass3>(source);
            //WriteLines("比源类属性少", dest);

            //var dest = AutoMapperHelper.MapTo<SourceClass, DestClass4>(source);
            //WriteLines("属性名与源类部分不一致", dest);

            var dest = AutoMapperHelper.MapTo<SourceClass, DestClass5>(source);
            WriteLines("属性名与源类部分不一致", dest);

            Console.ReadKey();
        }


        private static void WriteLines(string describe, DestClass5 dest)
        {
            Console.WriteLine(describe);
            Console.WriteLine(dest.UserName);
            Console.WriteLine(dest.UserID);
            Console.WriteLine(dest.UserAge);
            Console.WriteLine(dest.UserAddress);
            Console.WriteLine(dest.UserCompany);
        }
    }
}
