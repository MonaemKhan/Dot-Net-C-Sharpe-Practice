using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterArchive.Query;

public record GetPurchaseMasterArchiveList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmPurchaseMasterArchive>>>;
public class GetPurchaseMasterArchiveListHandler(IPurchaseMasterArchiveRepository Repository, IMapper mapper) : IRequestHandler<GetPurchaseMasterArchiveList, QueryResult<Paging<VmPurchaseMasterArchive>>>
{
    private readonly IPurchaseMasterArchiveRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;

    public async Task<QueryResult<Paging<VmPurchaseMasterArchive>>> Handle(GetPurchaseMasterArchiveList request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.TransactionCode.Contains(request.SearchText)),
            o => o.OrderBy(x => x.TransactionId),
            se => se);
        var result = data.ToPagingModel<PurchaseMasterArchives, VmPurchaseMasterArchive>(_mapper);
        return result switch
        {
            null => new QueryResult<Paging<VmPurchaseMasterArchive>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Paging<VmPurchaseMasterArchive>>(result, QueryResultTypeEnum.Success)
        };
    }
}
