using InvenTrackPro.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Models.Entities;

public class VmTempItemListReport:IEntityVM
{
	public long Id { get; set; }
	public int? ItemId { get; set; }
	public string ItemCode { get; set; }
	public string ItemName { get; set; }
	public int? Parent { get; set; }
	public int? TopParent { get; set; }
	public string LR { get; set; }
	public int? Depth { get; set; }
	public DateTimeOffset? CreateDate { get; set; }
	public string QUnit { get; set; }
	public string RUnit { get; set; }
	public string PartsNo { get; set; }
	public int? ItemOrder { get; set; }
	public string SalesUnit { get; set; }
	public string UserId { get; set; }
	public float? OpenQty { get; set; }
	public float? PurRate { get; set; }
	public float? SaleRate { get; set; }
	public float? ReOrderQty { get; set; }
	public int? CompyearId { get; set; }
	public int? CompId { get; set; }
}
