using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperTest
{
    public class MyAutoMapperProfile : Profile
    {
        public MyAutoMapperProfile()
        {
            CreateMap<SourceClass, DestClass>();
            CreateMap<SourceClass, DestClass2>();
            CreateMap<SourceClass, DestClass3>();
            CreateMap<SourceClass, DestClass4>();
            CreateMap<SourceClass, DestClass5>();
        }
    }
}
