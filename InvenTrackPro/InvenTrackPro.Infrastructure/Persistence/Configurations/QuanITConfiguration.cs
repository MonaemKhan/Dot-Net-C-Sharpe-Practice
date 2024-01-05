using InvenTrackPro.SharedKernel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations;

public class QuanITConfiguration : IEntityTypeConfiguration<QuanITs>
{
    public void Configure(EntityTypeBuilder<QuanITs> builder)
    {
        builder.ToTable("QuanIT");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.QunITName).IsRequired(false).HasMaxLength(30).IsUnicode(true);
        builder.HasData(new QuanITs
        {
            Id = 1,
            QunITName = "xyz",
        });
    }
}
