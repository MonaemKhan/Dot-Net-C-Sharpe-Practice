﻿using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employee.Infrastructure.Presistance.Configarations;

public class EmployeeConfigaration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable("Employee",schema: "Emp");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.FirstName);
        builder.HasOne(x => x.Country).WithMany(x => x.Employee).HasForeignKey(x => x.CountryId);
        builder.HasOne(x => x.State).WithMany(x => x.Employee).HasForeignKey(x => x.StateId);
        builder.HasData(new
        {
            Id = 1,
            FirstName = "M.A. Monaem",
            LastName = "Khan",
            Address = "Dhaka",
            Age = 26,
            PhoneNumber = "01303271849",
            CountryId = 1,
            StateId = 1,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        }, new {
            Id = 2,
            FirstName = "M.A.",
            LastName = "Khan",
            Address = "Dhaka",
            Age = 26,
            PhoneNumber = "013",
            CountryId = 2,
            StateId = 2,
            CreatedBy = "1",
            Created = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }
}
