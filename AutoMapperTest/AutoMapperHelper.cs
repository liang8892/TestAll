using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperTest
{
    public static class AutoMapperHelper
    {
        private static AutoMapper.MapperConfiguration _config;
        private static IMapper _mapper;

        //初始化
        public static void Initialization()
        {
            _config = new MapperConfiguration(a => a.AddProfile(new MyAutoMapperProfile()));
            _mapper = _config.CreateMapper();
        }

        //映射
        public static TDest MapTo<TSource, TDest>(TSource source) where TDest : class
        {
            return _mapper.Map<TSource, TDest>(source);
        }
    }
}
