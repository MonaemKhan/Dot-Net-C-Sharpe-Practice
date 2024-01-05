using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.Application.Models.Entities;

public class VmRepairService:IEntityVM
{
    public long Id { get; set; } //named as 'Serial' in Database File
    public int RepairId { get; set; }
    public int PartyId { get; set; }
    public string VNo { get; set; }
    public int VType { get; set; }
    public DateTimeOffset ReceiveDate { get; set; }
    public string Particulars { get; set; }
    public string GSXNO { get; set; }
    public string SRNO { get; set; }
    public double PartsAmount { get; set; }
    public double ServiceAmount { get; set; }
    public double TotalAmount { get; set; }
    public double DollerAmount { get; set; }
    public double DollerFract { get; set; }
    public double DollerExchangeRate { get; set; }
    public int BRId { get; set; }
    public int YearId { get; set; }
    public string UserName { get; set; }
}
