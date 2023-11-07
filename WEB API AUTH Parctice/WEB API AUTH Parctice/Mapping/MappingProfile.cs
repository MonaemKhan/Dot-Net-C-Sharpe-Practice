using AutoMapper;
using WEB_API_AUTH_Parctice.Model;
using WEB_API_AUTH_Parctice.Model.DTO;

namespace WEB_API_AUTH_Parctice.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<VmStudent, Student>().ReverseMap();
    }
}
