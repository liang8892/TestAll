using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
    /// <summary>
    /// 与源类完全一致
    /// </summary>
    class DestClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
    }

    /// <summary>
    /// 比源类属性多
    /// </summary>
    class DestClass2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }

        public string School { get; set; }
    }

    /// <summary>
    /// 比源类属性少
    /// </summary>
    class DestClass3
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
    }

    /// <summary>
    /// 属性名与源类部分不一致
    /// </summary>
    class DestClass4
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
    }

    /// <summary>
    /// 属性名与源类完全不一致
    /// </summary>
    class DestClass5
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserAddress { get; set; }
        public string UserCompany { get; set; }
    }
}
