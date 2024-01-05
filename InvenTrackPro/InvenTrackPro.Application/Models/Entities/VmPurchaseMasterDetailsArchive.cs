﻿using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.Application.Models.Entities;

public class VmPurchaseMasterDetailsArchive:IEntityVM
{
    public long Id { get; set; }
    public int TransactionId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public double Rate { get; set; }
    public int TransactionType { get; set; }
    public string QunIt { get; set; }
    public string RunIt { get; set; }
    public string MSLNo { get; set; }
    public int BRID { get; set; }
    public int YearId { get; set; }
    public int TrackId { get; set; }
}
