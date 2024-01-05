using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<VmCompanyInfo, CompanyInfo>().ReverseMap();
        CreateMap<VmTempItemListReport, TempItemListReport>().ReverseMap();
    }
}
