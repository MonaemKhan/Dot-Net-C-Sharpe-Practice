using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations;

public class PurchaseMasterArchiveConfiguration : IEntityTypeConfiguration<PurchaseMasterArchives>
{
    public void Configure(EntityTypeBuilder<PurchaseMasterArchives> builder)
    {
        builder.ToTable("PurchaseMasterArchive");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TransactionCode).IsRequired(false).HasMaxLength(15).IsUnicode(true);
        builder.Property(x=>x.Warranty).IsRequired(false).HasMaxLength(100).IsUnicode(true);
        builder.Property(x=>x.Attn).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.UserId).IsRequired(false).HasMaxLength(15).IsUnicode(true);
        builder.Property(x=>x.LCNo).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.PONo).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.Remarks).IsRequired(false).HasMaxLength(250).IsUnicode(true);
        builder.Property(x=>x.ChangeUser).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.EdEvents).IsRequired(false).HasMaxLength(10).IsUnicode(false);

        builder.HasData(new PurchaseMasterArchives
        {
            Id = 1,
            TransactionId = 1,
            TransactionCode = "MO121",
            TransactionDate = Convert.ToDateTime("2023/10/23"),
            TransactionType = 1,
            supplierCode = 1,
            PurchaseCode = 1,
            PurchaseType = 1,
            Warranty = "2 years",
            Attn = "ABC",
            UserId = "USer 01",
            BRID = 1,
            YearId = 1,
            LCNo = "LC 01",
            LCDate = Convert.ToDateTime("2023/10/23"),
            PONo = "PO 01",
            Remarks = "Very Good",
            TransactionCodePreTurnNo = 1,
            TrackId = 1,
            ChangeDate = Convert.ToDateTime("2023/10/23"),
            ChangeUser = "CNG USER 01",
            EdEvents = "EVT 01"
        });
    }
}
