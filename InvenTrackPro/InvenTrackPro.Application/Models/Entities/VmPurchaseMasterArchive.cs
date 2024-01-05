using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.Application.Models.Entities;

public class VmPurchaseMasterArchive : IEntityVM
{
    public long Id { get; set; }
    public int TransactionId { get; set; }
    public string TransactionCode { get; set; }
    public DateTimeOffset TransactionDate { get; set; }
    public int TransactionType { get; set; }
    public int supplierCode { get; set; }
    public int PurchaseCode { get; set; }
    public int PurchaseType { get; set; }
    public string Warranty { get; set; }
    public string Attn { get; set; }
    public string UserId { get; set; }
    public int BRID { get; set; }
    public int YearId { get; set; }
    public string LCNo { get; set; }
    public DateTimeOffset LCDate { get; set; }
    public string PONo { get; set; }
    public string Remarks { get; set; }
    public int TransactionCodePreTurnNo { get; set; }
    public int TrackId { get; set; }
    public DateTimeOffset ChangeDate { get; set; }
    public string ChangeUser { get; set; }
    public string EdEvents { get; set; }
}

