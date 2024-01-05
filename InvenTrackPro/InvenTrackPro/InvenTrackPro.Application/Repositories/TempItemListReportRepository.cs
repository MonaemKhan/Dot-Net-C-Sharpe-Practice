using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Persistence;
using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Repositories;

public class TempItemListReportRepository : BaseRepository<TempItemListReport, VmTempItemListReport, long>, ITempItemListReportRepository
{
	public TempItemListReportRepository(IMapper mapper, InvenTrackProContext context) : base(mapper, context)
	{
	}
}
