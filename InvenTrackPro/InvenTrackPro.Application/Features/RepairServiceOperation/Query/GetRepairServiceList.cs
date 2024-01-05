using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.RepairService.Query;

public record GetRepairServiceList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmRepairService>>>;
public class GetRepairServiceListHandler(IRepairServiceRepository Repository,
    IMapper mapper) : IRequestHandler<GetRepairServiceList, QueryResult<Paging<VmRepairService>>>
{
    private readonly IRepairServiceRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;

    public async Task<QueryResult<Paging<VmRepairService>>> Handle(GetRepairServiceList request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.UserName.Contains(request.SearchText)),
            o => o.OrderBy(x => x.Id),
            se => se);
        var result = data.ToPagingModel<RepairServices, VmRepairService>(_mapper);
        return result switch
        {
            null => new QueryResult<Paging<VmRepairService>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Paging<VmRepairService>>(result, QueryResultTypeEnum.Success)
        };
    }
}