﻿// <auto-generated />
using System;
using API_Practice_01.DbCon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Practice_01.Migrations
{
    [DbContext(typeof(DbConnetionContext))]
    [Migration("20230718184210_CreateTableInDatabase")]
    partial class CreateTableInDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_Practice_01.Model.Student", b =>
                {
                    b.Property<string>("StudentRegNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StudentPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StudentRegNo");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("API_Practice_01.Model.Teacher", b =>
                {
                    b.Property<string>("TecherRegNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TeacherEmail")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TeacherPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TecherName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TecherRegNo");

                    b.ToTable("TeacherDetails");
                });

            modelBuilder.Entity("API_Practice_01.Model.Thesis", b =>
                {
                    b.Property<string>("ThesisId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StudentRegNo")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Student_RegNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TeacherTecherRegNo")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Teacher_RegNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ThesisId");

                    b.HasIndex("StudentRegNo");

                    b.HasIndex("TeacherTecherRegNo");

                    b.ToTable("ThesisDetails");
                });

            modelBuilder.Entity("API_Practice_01.Model.Thesis", b =>
                {
                    b.HasOne("API_Practice_01.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentRegNo");

                    b.HasOne("API_Practice_01.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherTecherRegNo");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
