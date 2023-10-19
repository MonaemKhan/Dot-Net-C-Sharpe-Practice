using AutoMapper;
using Employee.Model;
using Employee.Service.Model;

namespace Employee.Core.Mapping;

public class MappingExtention:Profile
{
    public MappingExtention()
    {
        CreateMap<VMEmployee, Employees>().ReverseMap()
            .ForMember(x=>x.StateName,x=>x.MapFrom(m=>m.States != null ? m.States.StateName:""))
            .ForMember(x=>x.CountryName,x=>x.MapFrom(m=>m.Countries != null? m.Countries.CountryName:""));
        CreateMap<VMCountries, Countries>().ReverseMap();
        CreateMap<VMState,States>().ReverseMap()
            .ForMember(x => x.CountryName, x => x.MapFrom(m => m.Countries != null ? m.Countries.CountryName : ""));
    }
}
