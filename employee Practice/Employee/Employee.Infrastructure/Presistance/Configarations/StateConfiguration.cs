using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Presistance.Configarations;

public class StateConfiguration : IEntityTypeConfiguration<States>
{
    public void Configure(EntityTypeBuilder<States> builder)
    {
        builder.ToTable("State", schema: "Emp");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.StateName);
        builder.HasOne(x=>x.Country).WithMany(x => x.State).HasForeignKey(x => x.CountryId);
        builder.HasData(new
        {
            Id = 1,
            StateName = "Dhaka",
            CountryId = 1,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new
        {
            Id = 2,
            StateName = "Rajshahi",
            CountryId = 2,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
