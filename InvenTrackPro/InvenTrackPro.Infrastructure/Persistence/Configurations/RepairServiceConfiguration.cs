using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations;

public class RepairServiceConfiguration : IEntityTypeConfiguration<RepairServices>
{
    public void Configure(EntityTypeBuilder<RepairServices> builder)
    {
        builder.ToTable("RepairService");
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.VNo).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.Particulars).IsRequired(false).HasMaxLength(100).IsUnicode(true);
        builder.Property(x=>x.GSXNO).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x=>x.SRNO).IsRequired(false).HasMaxLength(40).IsUnicode(true);
        builder.Property(x=>x.UserName).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.HasData(new RepairServices
        {
            Id = 1,
            RepairId = 1,
            PartyId = 1,
            VNo = "xyz123",
            VType = 1,
            ReceiveDate = DateTime.Now,
            Particulars = "abc",
            GSXNO = "abc",
            SRNO = "abc",
            PartsAmount = 10.30,
            ServiceAmount = 1000.001,
            TotalAmount = 1100.301,
            DollerAmount = 10,
            DollerFract = 5,
            DollerExchangeRate = 100,
            BRId = 1,
            YearId = 1,
            UserName = "Monaem",
        });

    }
}
