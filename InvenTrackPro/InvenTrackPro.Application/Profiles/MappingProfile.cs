using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<VmCompanyInfo, CompanyInfo>().ReverseMap();
        CreateMap<VmPurchaseMasterArchive, PurchaseMasterArchives>().ReverseMap();   
        CreateMap<VmPurchaseMasterDetails, PurchaseMasterDetailss>().ReverseMap();   
        CreateMap<VmPurchaseMasterDetailsArchive, PurchaseMasterDetailsArchives>().ReverseMap();   
        CreateMap<VmRepairService, RepairServices>().ReverseMap();   
        CreateMap<VmQuanIT, QuanITs>().ReverseMap();   
    }
}
