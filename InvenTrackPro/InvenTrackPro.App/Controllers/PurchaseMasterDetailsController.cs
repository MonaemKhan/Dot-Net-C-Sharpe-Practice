using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.PurchaseMasterArchive.Command;
using InvenTrackPro.Application.Features.PurchaseMasterArchive.Query;
using InvenTrackPro.Application.Features.PurchaseMasterDetails.Command;
using InvenTrackPro.Application.Features.PurchaseMasterDetails.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class PurchaseMasterDetailsController : ApiControllerBase
{
    [HttpGet]
    public Task<ActionResult> GetPurchaseMasterDetailsList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return HandelQueryAsync(new GetPurchaseMasterDetailsList(pageIndex, pageSize, searchText));
    }

    [HttpGet("GetDetails")]
    public Task<ActionResult> GetPurchaseMasterDetailsDetails(long Id)
    {
        return HandelQueryAsync(new GetPurchaseMasterDetailsDetails(Id));
    }

    [HttpPost]
    public Task<ActionResult> CreatePurchaseMasterDetails(VmPurchaseMasterDetails vmPurchaseMasterDetails)
    {
        return HandelCommandAsync(new CreatePurchaseMasterDetails(vmPurchaseMasterDetails));
    }

    [HttpPut]
    public Task<ActionResult> UpdatePurchaseMasterDetails(long Id, VmPurchaseMasterDetails vmPurchaseMasterDetails)
    {
        return HandelCommandAsync(new UpdatePurchaseMasterDetails(Id, vmPurchaseMasterDetails));
    }

    [HttpDelete]
    public Task<ActionResult> DeletePurchaseMasterDetails(long Id)
    {
        return HandelCommandAsync(new DeletePurchaseMasterDetails(Id));
    }
}
