using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.PurchaseMasterArchive.Command;
using InvenTrackPro.Application.Features.PurchaseMasterArchive.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class PurchaseMasterArchiveController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetPurchaseMasterArchiveList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetPurchaseMasterArchiveList(pageIndex, pageSize, searchText));
    }

    [HttpGet("GetDetails")]
    public Task<ActionResult> GetPurchaseMasterArchiveDetails(long Id)
    {
        return HandelQueryAsync(new GetPurchaseMasterArchiveDetails(Id));
    }

    [HttpPost]
    public Task<ActionResult> CreatePurchaseMasterArchive(VmPurchaseMasterArchive vmPurchaseMasterArchive)
    {
        return HandelCommandAsync(new CreatePurchaseMasterArchive(vmPurchaseMasterArchive));
    }

    [HttpPut]
    public Task<ActionResult> UpdatePurchaseMasterArchive(long Id,VmPurchaseMasterArchive vmPurchaseMasterArchive)
    {
        return HandelCommandAsync(new UpdatePurchaseMasterArchive(Id , vmPurchaseMasterArchive));
    }

    [HttpDelete]
    public Task<ActionResult> DeletePurchaseMasterArchive(long Id)
    {
        return HandelCommandAsync(new DeletePurchaseMasterArchive(Id));
    }
}
