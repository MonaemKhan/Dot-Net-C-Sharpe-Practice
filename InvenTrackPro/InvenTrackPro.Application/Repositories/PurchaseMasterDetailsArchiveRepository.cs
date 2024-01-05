using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Persistence;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Repositories;

public class PurchaseMasterDetailsArchiveRepository : BaseRepository<PurchaseMasterDetailsArchives, VmPurchaseMasterDetailsArchive, long>, IPurchaseMasterDetailsArchiveRepository
{
    public PurchaseMasterDetailsArchiveRepository(IMapper mapper, InvenTrackProContext context) : base(mapper, context)
    {
    }
}
