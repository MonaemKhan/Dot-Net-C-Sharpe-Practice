﻿// <auto-generated />
using System;
using Employee.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee.Model.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Courencies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryName");

                    b.ToTable("Country", "Emp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "BanglaDesh",
                            Courencies = "Taka",
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 240, DateTimeKind.Unspecified).AddTicks(8192), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CountryName = "India",
                            Courencies = "Rupi",
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 240, DateTimeKind.Unspecified).AddTicks(8361), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("FirstName");

                    b.HasIndex("StateId");

                    b.ToTable("Employee", "Emp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Dhaka",
                            Age = 26,
                            CountryId = 1,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(3004), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            FirstName = "M.A. Monaem",
                            LastName = "Khan",
                            PhoneNumber = "01303271849",
                            StateId = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Dhaka",
                            Age = 26,
                            CountryId = 2,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(3019), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            FirstName = "M.A.",
                            LastName = "Khan",
                            PhoneNumber = "013",
                            StateId = 2,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.States", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateName");

                    b.ToTable("State", "Emp");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(7986), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            StateName = "Dhaka",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Created = new DateTimeOffset(new DateTime(2023, 9, 29, 2, 17, 38, 247, DateTimeKind.Unspecified).AddTicks(7999), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            StateName = "Rajshahi",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.Employees", b =>
                {
                    b.HasOne("Employee.Model.Countries", "Country")
                        .WithMany("Employee")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee.Model.States", "State")
                        .WithMany("Employee")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Employee.Model.States", b =>
                {
                    b.HasOne("Employee.Model.Countries", "Country")
                        .WithMany("State")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Employee.Model.Countries", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Employee.Model.States", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
