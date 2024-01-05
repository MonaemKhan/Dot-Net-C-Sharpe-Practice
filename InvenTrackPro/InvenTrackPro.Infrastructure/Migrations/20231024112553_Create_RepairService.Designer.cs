﻿// <auto-generated />
using System;
using InvenTrackPro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvenTrackPro.Infrastructure.Migrations
{
    [DbContext(typeof(InvenTrackProContext))]
    [Migration("20231024112553_Create_RepairService")]
    partial class Create_RepairService
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.CompanyInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("BranchName")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fax")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("WebSite")
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("CompanyInfo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "",
                            BranchName = "abc",
                            CompanyName = "XYZ",
                            ContactPerson = "Abc",
                            CreatedBy = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 598, DateTimeKind.Unspecified).AddTicks(8928), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "xyz@gmail.com",
                            Fax = "1212",
                            IsActive = true,
                            IsDelete = false,
                            Phone = "123",
                            WebSite = "www.xyz.com"
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = 0L,
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR",
                            StatusId = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = 0L,
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "User",
                            NormalizedName = "USER",
                            StatusId = 0
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TramsAndConditions")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6469e51e-3ffc-4a29-9fd2-13607646a7b8",
                            CreatedBy = 0L,
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHUCxDH8dkz1X48/BF8fTBvXAaWbRcRtOBuhEGYeotl4BFNXPjNZCqI8PbjGulXpjw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c17ecb8a-a87f-4856-ab36-5f0043a260ae",
                            TramsAndConditions = true,
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = 2L,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "949cf875-a2f9-435a-b654-4f4f2ecc12de",
                            CreatedBy = 0L,
                            CreatedDate = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEG/HPPEJblbV0oMS5U5auY6NMCBrL2tEfDxAHKbI+8cEZhBsOh/Vuc783qaG8JrRkw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "39800db5-1418-4727-84cf-04b7ac88dc05",
                            TramsAndConditions = true,
                            TwoFactorEnabled = false,
                            UserName = "user@localhost.com"
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            RoleId = 1L
                        },
                        new
                        {
                            UserId = 2L,
                            RoleId = 2L
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserToken", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.PurchaseMasterArchives", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Attn")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BRID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ChangeDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ChangeUser")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EdEvents")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LCDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LCNo")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PONo")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PurchaseCode")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseType")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionCode")
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TransactionCodePreTurnNo")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("TransactionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Warranty")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.Property<int>("supplierCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurchaseMasterArchive", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Attn = "ABC",
                            BRID = 1,
                            ChangeDate = new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)),
                            ChangeUser = "CNG USER 01",
                            CreatedBy = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 608, DateTimeKind.Unspecified).AddTicks(5944), new TimeSpan(0, 0, 0, 0, 0)),
                            EdEvents = "EVT 01",
                            IsActive = true,
                            IsDelete = false,
                            LCDate = new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)),
                            LCNo = "LC 01",
                            PONo = "PO 01",
                            PurchaseCode = 1,
                            PurchaseType = 1,
                            Remarks = "Very Good",
                            TrackId = 1,
                            TransactionCode = "MO121",
                            TransactionCodePreTurnNo = 1,
                            TransactionDate = new DateTimeOffset(new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)),
                            TransactionId = 1,
                            TransactionType = 1,
                            UserId = "USer 01",
                            Warranty = "2 years",
                            YearId = 1,
                            supplierCode = 1
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.PurchaseMasterDetailsArchives", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BRID")
                        .HasColumnType("int");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("MSLNo")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("QunIt")
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("RunIt")
                        .HasMaxLength(10)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurchaseMasterDetailsArchive", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BRID = 1,
                            CreatedBy = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 612, DateTimeKind.Unspecified).AddTicks(6606), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            IsDelete = false,
                            ItemId = 1,
                            MSLNo = "abc123",
                            Quantity = 10,
                            QunIt = "xyz",
                            Rate = 10.1,
                            RunIt = "abc",
                            TrackId = 1,
                            TransactionId = 1,
                            TransactionType = 1,
                            YearId = 1
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.PurchaseMasterDetailss", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BRID")
                        .HasColumnType("int");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("MSLNo")
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("QunIt")
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("RunIt")
                        .HasMaxLength(10)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurchaseMasterDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BRID = 1,
                            CreatedBy = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 616, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 0, 0, 0, 0)),
                            IsActive = true,
                            IsDelete = false,
                            ItemId = 1,
                            MSLNo = "abc123",
                            Quantity = 10,
                            QunIt = "xyz",
                            Rate = 10.1,
                            RunIt = "abc",
                            TransactionId = 1,
                            TransactionType = 1,
                            YearId = 1
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.RepairServices", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("BRId")
                        .HasColumnType("int");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("DollerAmount")
                        .HasColumnType("float");

                    b.Property<double>("DollerExchangeRate")
                        .HasColumnType("float");

                    b.Property<double>("DollerFract")
                        .HasColumnType("float");

                    b.Property<string>("GSXNO")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Particulars")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("PartsAmount")
                        .HasColumnType("float");

                    b.Property<int>("PartyId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ReceiveDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RepairId")
                        .HasColumnType("int");

                    b.Property<string>("SRNO")
                        .HasMaxLength(40)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("ServiceAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VType")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RepairService", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BRId = 1,
                            CreatedBy = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 10, 24, 11, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3279), new TimeSpan(0, 0, 0, 0, 0)),
                            DollerAmount = 10.0,
                            DollerExchangeRate = 100.0,
                            DollerFract = 5.0,
                            GSXNO = "abc",
                            IsActive = true,
                            IsDelete = false,
                            Particulars = "abc",
                            PartsAmount = 10.300000000000001,
                            PartyId = 1,
                            ReceiveDate = new DateTimeOffset(new DateTime(2023, 10, 24, 17, 25, 52, 620, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 6, 0, 0, 0)),
                            RepairId = 1,
                            SRNO = "abc",
                            ServiceAmount = 1000.001,
                            TotalAmount = 1100.3009999999999,
                            UserName = "Monaem",
                            VNo = "xyz123",
                            VType = 1,
                            YearId = 1
                        });
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+RoleClaim", b =>
                {
                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserClaim", b =>
                {
                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserLogin", b =>
                {
                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserRole", b =>
                {
                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+UserToken", b =>
                {
                    b.HasOne("InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel+User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
