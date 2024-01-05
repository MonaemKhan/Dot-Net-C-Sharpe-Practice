using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.Application.Models.Entities;

public class VmQuanIT:IEntityVM
{
    public long Id { get; set; } // named as 'QunITId' in database file
    public string QunITName { get; set; }
}
