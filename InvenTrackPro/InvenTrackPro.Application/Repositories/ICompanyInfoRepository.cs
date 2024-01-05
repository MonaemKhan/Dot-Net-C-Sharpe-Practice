using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces.BaseRepo;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Infrastructure.Interfaces;

public interface ICompanyInfoRepository:IBaseRepository<CompanyInfo, VmCompanyInfo, long>
{
}
