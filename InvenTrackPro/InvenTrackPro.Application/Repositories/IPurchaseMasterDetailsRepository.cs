using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces.BaseRepo;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Repositories;

public interface IPurchaseMasterDetailsRepository:IBaseRepository<PurchaseMasterDetailss,VmPurchaseMasterDetails,long>
{
}
