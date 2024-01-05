using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations
{
    public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.ToTable(nameof(CompanyInfo));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompanyName).HasMaxLength(50).IsRequired(false).IsUnicode(true);
            builder.Property(x => x.BranchName).HasMaxLength(50).IsUnicode(true);
            builder.Property(x => x.Address).HasMaxLength(250).IsUnicode(true);
            builder.Property(x => x.Phone).HasMaxLength(20).IsUnicode(true);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(x=>x.WebSite).HasMaxLength(20).IsUnicode(true);
            builder.Property(x=>x.ContactPerson).HasMaxLength(50).IsUnicode(true);
            builder.Property(x=>x.Fax).HasMaxLength(20).IsUnicode(true);
            builder.HasData(new CompanyInfo
            {
                Id = 1,
                CompanyName="XYZ",
                BranchName="abc",
                Address="",
                Email="xyz@gmail.com",
                Phone="123",
                WebSite="www.xyz.com",
                ContactPerson="Abc",
                Fax="1212"
            });
        }
    }
}
