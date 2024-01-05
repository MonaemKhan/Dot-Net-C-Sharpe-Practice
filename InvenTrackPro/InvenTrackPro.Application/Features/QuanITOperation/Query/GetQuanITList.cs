using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Query;
public record GetQuanITList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmQuanIT>>>;
public class GetQuanITListHandler(IQuanITRepository Repository,
    IMapper mapper) : IRequestHandler<GetQuanITList, QueryResult<Paging<VmQuanIT>>>
{
    private readonly IQuanITRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;

    public async Task<QueryResult<Paging<VmQuanIT>>> Handle(GetQuanITList request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.QunITName.Contains(request.SearchText)),
            o => o.OrderBy(x => x.Id),
            se => se);
        var result = data.ToPagingModel<QuanITs, VmQuanIT>(_mapper);
        return result switch
        {
            null => new QueryResult<Paging<VmQuanIT>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Paging<VmQuanIT>>(result, QueryResultTypeEnum.Success)
        };
    }
}