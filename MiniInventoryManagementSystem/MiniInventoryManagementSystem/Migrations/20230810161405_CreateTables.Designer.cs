﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniInventoryManagementSystem.DbCon;

#nullable disable

namespace MiniInventoryManagementSystem.Migrations
{
    [DbContext(typeof(DbConnectionContext))]
    [Migration("20230810161405_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MiniInventoryManagementSystem.Models.Catagory", b =>
                {
                    b.Property<int>("CatagoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatagoryId"), 1L, 1);

                    b.Property<string>("CatagoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CatagoryId");

                    b.ToTable("CatagoryTable");
                });

            modelBuilder.Entity("MiniInventoryManagementSystem.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerTable");
                });

            modelBuilder.Entity("MiniInventoryManagementSystem.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_CatagoryId")
                        .HasColumnType("int")
                        .HasColumnName("CatagoryId");

                    b.HasKey("ProductId");

                    b.HasIndex("Product_CatagoryId");

                    b.ToTable("ProductTable");
                });

            modelBuilder.Entity("MiniInventoryManagementSystem.Models.Product", b =>
                {
                    b.HasOne("MiniInventoryManagementSystem.Models.Catagory", "Product_Catagory")
                        .WithMany("Products")
                        .HasForeignKey("Product_CatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_Catagory");
                });

            modelBuilder.Entity("MiniInventoryManagementSystem.Models.Catagory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}