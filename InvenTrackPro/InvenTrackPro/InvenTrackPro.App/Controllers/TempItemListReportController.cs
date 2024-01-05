using InvenTrackPro.App.Controllers.Base;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Command;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
using InvenTrackPro.Application.Features.TempItemListReportOperation.Command;
using InvenTrackPro.Application.Features.TempItemListReportOperation.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackPro.App.Controllers;

[AllowAnonymous]
// TODO: Need to remove AllowAnonymous
public class TempItemListReportController : ApiControllerBase
{
	[HttpGet]
	public Task<ActionResult> GetTempItemListReportList(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
	{
		return HandelQueryAsync(new GetTempItemListReportList(pageIndex, pageSize, searchText));
	}
	//[HttpGet("Dropdown")]
	//public Task<ActionResult> GetDropdownAsync(string searchText, int size = CommonVariables.DropdownSize)
	//{
	//	return HandelQueryAsync(new GetCompanyInfoDropdown(searchText, size));
	//}

	[HttpGet("Id")]
	public Task<ActionResult> GetTempItemListReportDetails(long Id)
	{
		return HandelQueryAsync(new GetTempItemListReportDetails(Id));
	}

	[HttpPost]
	public Task<ActionResult> InsertTempItemListReport(VmTempItemListReport vmTempItemListReport)
	{
		return HandelCommandAsync(new CreateTempItemListReport(vmTempItemListReport));
	}
	[HttpDelete("{Id:long}")]
	public Task<ActionResult> DeleteTempItemListReport(long Id)
	{
		return HandelCommandAsync(new DeleteTempItemListReport(Id));
	}
	[HttpPut("{Id:long}")]
	public async Task<ActionResult<VmTempItemListReport>> UpdateProduct(long Id, VmTempItemListReport data)
	{
		return await HandelCommandAsync(new UpdateTempItemListReport(Id, data));
	}

	
}
