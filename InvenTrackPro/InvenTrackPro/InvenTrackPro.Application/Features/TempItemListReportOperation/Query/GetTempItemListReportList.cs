using AutoMapper;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Features.TempItemListReportOperation.Query;

public record GetTempItemListReportList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmTempItemListReport>>>;

public class GetTempItemListReportListHandler : IRequestHandler<GetTempItemListReportList, QueryResult<Paging<VmTempItemListReport>>>
{
	private readonly ITempItemListReportRepository _tempItemListReportRepository;
	private readonly IMapper _mapper;

	public GetTempItemListReportListHandler(ITempItemListReportRepository tempItemListReportRepository, IMapper mapper)
	{
		_tempItemListReportRepository = tempItemListReportRepository;
		_mapper = mapper;
	}

	public async Task<QueryResult<Paging<VmTempItemListReport>>> Handle(GetTempItemListReportList request, CancellationToken cancellationToken)
	{
		var data = await _tempItemListReportRepository.GetPageAsync(request.PageIndex, request.PageSize,
		   p => (string.IsNullOrEmpty(request.SearchText) || p.ItemName.Contains(request.SearchText)),
		   o => o.OrderBy(ob => ob.ItemName),
		   se => se);

		var result = data.ToPagingModel<TempItemListReport, VmTempItemListReport>(_mapper);

		if (result is null)
		{
			return new QueryResult<Paging<VmTempItemListReport>>(null, QueryResultTypeEnum.NotFound);
		}
		return new QueryResult<Paging<VmTempItemListReport>>(result, QueryResultTypeEnum.Success);
	}
}
