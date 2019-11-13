using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAP
{
    public static class GlobalParas
    {
        public const string divList = "//div[@id='List1']/div[@class='pic']";
        public const string KekeWebsite = "http://www.kekenet.com";
        public const string Down = "下载地址";
        public const string DownPath = @"d:\down";
        /// <summary>
        /// 不能用于Windows系统中文件名的字符
        /// </summary>
        public static Char[] IllegalCharInFilename => new[] { '\\', '/', ':', '*', '?', '"', '<', '>' };
    }
}
