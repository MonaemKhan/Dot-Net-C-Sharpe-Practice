using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Command;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous

public class CompanyInfoController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetCompanyInfoList(int pageIndex = CommonVariables.pageIndex ,int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetCompanyInfoList(pageIndex, pageSize, searchText));
    }
    [HttpGet("Dropdown")]
    public Task<ActionResult> GetDropdownAsync(string searchText, int size = CommonVariables.DropdownSize)
    {
        return HandelQueryAsync(new GetCompanyInfoDropdown(searchText, size));
    }

    [HttpGet("id")]
    public Task<ActionResult> GetCompanyInfoDetails(long id)
    {
        return HandelQueryAsync(new GetCompanyInfoDetails(id));
    }

    [HttpPost]
    public Task<ActionResult> InsertCompanyInfo(VmCompanyInfo vmCompanyInfo)
    {
        return HandelCommandAsync(new CreateCompanyInfo(vmCompanyInfo));
    }
}
