using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
using InvenTrackPro.Application.Features.QuanIT.Command;
using InvenTrackPro.Application.Features.QuanIT.Query;
using InvenTrackPro.Application.Features.RepairService.Command;
using InvenTrackPro.Application.Features.RepairService.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class QuanITController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetQuanITList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetQuanITList(pageIndex, pageSize, searchText));
    }

    [HttpGet("GetDetails")]
    public Task<ActionResult> GetQuanITDetails(long Id)
    {
        return HandelQueryAsync(new GetQuanITDetails(Id));
    }

    [HttpGet("Dropdown")]
    public Task<ActionResult> GetQuanITDropdoen(string searchText, int size = CommonVariables.DropdownSize)
    {
        return HandelQueryAsync(new GetQuanITDropdown(searchText, size));
    }

    [HttpPost]
    public Task<ActionResult> CreateQuanIT(VmQuanIT vmQuanIT)
    {
        return HandelCommandAsync(new CreateQuanIT(vmQuanIT));
    }

    [HttpPut]
    public Task<ActionResult> UpdateQuanIT(long Id, VmQuanIT vmQuanIT)
    {
        return HandelCommandAsync(new UpdateQuanIT(Id, vmQuanIT));
    }

    [HttpDelete]
    public Task<ActionResult> DeleteQuanIT(long Id)
    {
        return HandelCommandAsync(new DeleteQuanIT(Id));
    }
}
