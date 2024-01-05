﻿using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Persistence;
using InvenTrackPro.SharedKernel.Entities;

namespace InvenTrackPro.Application.Repositories;

public class PurchaseMasterArchiveRepository : BaseRepository<PurchaseMasterArchives, VmPurchaseMasterArchive, long>, IPurchaseMasterArchiveRepository
{
    public PurchaseMasterArchiveRepository(IMapper mapper, InvenTrackProContext context) : base(mapper, context)
    {
    }
}
