using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.RepairService.Command;
using InvenTrackPro.Application.Features.RepairService.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class RepairServiceController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetRepairServiceList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetRepairServiceList(pageIndex, pageSize, searchText));
    }

    [HttpGet("GetDetails")]
    public Task<ActionResult> GetRepairServiceDetails(long Id)
    {
        return HandelQueryAsync(new GetRepairServiceDetails(Id));
    }

    [HttpPost]
    public Task<ActionResult> CreateRepairService(VmRepairService vmRepairService)
    {
        return HandelCommandAsync(new CreateRepairService(vmRepairService));
    }

    [HttpPut]
    public Task<ActionResult> UpdateRepairService(long Id, VmRepairService vmRepairService)
    {
        return HandelCommandAsync(new UpdateRepairService(Id, vmRepairService));
    }

    [HttpDelete]
    public Task<ActionResult> DeleteRepairService(long Id)
    {
        return HandelCommandAsync(new DeleteRepairService(Id));
    }
}
