using AutoMapper;
using Common.Dto_s;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MappingProfileService: Profile
    {
        public MappingProfileService()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Hmo, HmoDto>().ReverseMap();
            CreateMap<FatherAndChild, FatherAndChildDto>().ReverseMap();
        }
    }
}
