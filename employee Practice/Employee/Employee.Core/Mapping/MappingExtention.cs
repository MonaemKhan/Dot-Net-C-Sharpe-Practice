using AutoMapper;
using Employee.Model;
using Employee.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Mapping;

public class MappingExtention:Profile
{
    public MappingExtention()
    {
        CreateMap<VMEmployee, Employees>().ReverseMap()
            .ForMember(x => x.CountryName, x => x.MapFrom(x => x.Country != null ? x.Country.CountryName : " "))
            .ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null? x.State.StateName:" ")) ;
        CreateMap<StateVM, States>().ReverseMap()
            .ForMember(x => x.CountryName, x=>x.MapFrom(x=>x.Country !=null ? x.Country.CountryName:" "));
        CreateMap<VMCountries, Countries>().ReverseMap();
    }

}
