using InvenTrackPro.SharedKernel.Common.BaseEntities;

namespace InvenTrackPro.SharedKernel.Entities;

public class CompanyInfo:AuditableEntity
{
    public string CompanyName { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string WebSite { get; set; }
    public string ContactPerson { get; set; }
}
