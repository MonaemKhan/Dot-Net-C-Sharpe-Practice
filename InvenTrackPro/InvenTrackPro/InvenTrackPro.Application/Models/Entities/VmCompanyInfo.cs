using AutoMapper;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Interfaces;

namespace InvenTrackPro.Application.Models.Entities;

public class VmCompanyInfo : IEntityVM
{
    public long Id { get; set; }
    public string CompanyName { get; set; }
    public string BranchName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string WebSite { get; set; }
    public string ContactPerson { get; set; }

}
