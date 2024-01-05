using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.Infrastructure.Persistence;
using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvenTrackPro.Application.Repositories;

public class CompanyInfoRepository : BaseRepository<CompanyInfo, VmCompanyInfo, long>, ICompanyInfoRepository
{
    public CompanyInfoRepository(IMapper mapper, InvenTrackProContext context) : base(mapper, context)
    {
    }

}
