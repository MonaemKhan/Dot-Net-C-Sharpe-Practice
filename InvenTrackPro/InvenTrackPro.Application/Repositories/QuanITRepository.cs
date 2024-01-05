using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Persistence;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Repositories;

public class QuanITRepository : BaseRepository<QuanITs, VmQuanIT, long>, IQuanITRepository
{
    public QuanITRepository(IMapper mapper, InvenTrackProContext context) : base(mapper, context)
    {
    }
}
