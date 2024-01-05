using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces.BaseRepo;
using InvenTrackPro.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Repositories;

public interface ITempItemListReportRepository:IBaseRepository<TempItemListReport,VmTempItemListReport,long> 
{
}
