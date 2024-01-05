using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.PurchaseMasterDetails.Command;
using InvenTrackPro.Application.Features.PurchaseMasterDetails.Query;
using InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Command;
using InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class PurchaseMasterDetailsArchiveController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetPurchaseMasterDetailsArchiveList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetPurchaseMasterDetailsArchivesList(pageIndex, pageSize, searchText));
    }

    [HttpGet("GetDetails")]
    public Task<ActionResult> GetPurchaseMasterDetailsArchiveDetails(long Id)
    {
        return HandelQueryAsync(new GetPurchaseMasterDetailsArchiveDetails(Id));
    }

    [HttpPost]
    public Task<ActionResult> CreatePurchaseMasterDetailsArchive(VmPurchaseMasterDetailsArchive vmPurchaseMasterDetailsArchive)
    {
        return HandelCommandAsync(new CreatePurchaseMasterDetailsArchive(vmPurchaseMasterDetailsArchive));
    }

    [HttpPut]
    public Task<ActionResult> UpdatePurchaseMasterDetailsArchive(long Id, VmPurchaseMasterDetailsArchive vmPurchaseMasterDetailsArchive)
    {
        return HandelCommandAsync(new UpdatePurchaseMasterDetailsArchive(Id, vmPurchaseMasterDetailsArchive));
    }

    [HttpDelete]
    public Task<ActionResult> DeletePurchaseMasterDetailsArchive(long Id)
    {
        return HandelCommandAsync(new DeletePurchaseMasterDetailsArchive(Id));
    }
}
