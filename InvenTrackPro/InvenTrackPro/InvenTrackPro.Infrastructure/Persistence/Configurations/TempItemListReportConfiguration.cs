using InvenTrackPro.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Infrastructure.Persistence.Configurations
{
	public class TempItemListReportConfiguration : IEntityTypeConfiguration<TempItemListReport>
	{
		public void Configure(EntityTypeBuilder<TempItemListReport> builder)
		{
			builder.ToTable(nameof(TempItemListReport));
			builder.HasKey(x => x.Id);
			builder.Property(x => x.ItemId).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.ItemCode).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.ItemName).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.Parent).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.TopParent).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.LR).HasMaxLength(1).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.Depth).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.CreateDate).HasMaxLength(20).HasColumnType("datetimeoffset").HasDefaultValueSql("(getdate())");
			builder.Property(x => x.QUnit).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.RUnit).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.PartsNo).HasMaxLength(150).IsRequired(false).IsUnicode(true); 
			builder.Property(x => x.ItemOrder).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.SalesUnit).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.UserId).HasMaxLength(50).IsRequired(false).IsUnicode(true);
			builder.Property(x => x.OpenQty).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.PurRate).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.SaleRate).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.ReOrderQty).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.CompyearId).HasMaxLength(20).IsRequired(false);
			builder.Property(x => x.CompId).HasMaxLength(20).IsRequired(false);
			
			builder.HasData(new TempItemListReport
			{
				Id = 1,
				ItemId = 1234,
				ItemCode = "",
				ItemName = "12",
				TopParent = 1234,
				Parent = 1234,
				LR="1",
				Depth=12,
				CreateDate = DateTimeOffset.Now,
				QUnit = "",
				RUnit = "1234",
				PartsNo = "1234",
				ItemOrder =123,
				SalesUnit = "1234",
				UserId = "1234",
				OpenQty = 3,
				PurRate = 1234,
				SaleRate = 1234,
				ReOrderQty = 1234,
				CompyearId =1,
				CompId =1

			});
		}
	}
}
