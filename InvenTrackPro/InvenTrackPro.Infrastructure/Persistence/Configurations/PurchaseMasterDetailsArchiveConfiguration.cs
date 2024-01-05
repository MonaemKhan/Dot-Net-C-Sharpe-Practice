﻿using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations;

public class PurchaseMasterDetailsArchiveConfiguration : IEntityTypeConfiguration<PurchaseMasterDetailsArchives>
{
    public void Configure(EntityTypeBuilder<PurchaseMasterDetailsArchives> builder)
    {
        builder.ToTable("PurchaseMasterDetailsArchive");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QunIt).IsRequired(false).HasMaxLength(15).IsUnicode(true);
        builder.Property(x => x.RunIt).IsRequired(false).HasMaxLength(10).IsUnicode(true);
        builder.Property(x => x.MSLNo).IsRequired(false).HasMaxLength(500).IsUnicode(true);
        builder.HasData(new PurchaseMasterDetailsArchives
        {
            Id = 1,
            TransactionId = 1,
            ItemId = 1,
            Quantity = 10,
            Rate = 10.10,
            TransactionType = 1,
            QunIt = "xyz",
            RunIt = "abc",
            MSLNo = "abc123",
            BRID = 1,
            YearId = 1,
            TrackId = 1
        });
    }
}
