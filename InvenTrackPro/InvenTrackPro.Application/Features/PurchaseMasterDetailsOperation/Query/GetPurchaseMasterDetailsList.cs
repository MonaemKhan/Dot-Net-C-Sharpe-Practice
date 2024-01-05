using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetails.Query;

public record GetPurchaseMasterDetailsList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmPurchaseMasterDetails>>>;
public class GetPurchaseMasterDetailsListHandler(IPurchaseMasterDetailsRepository Repository, IMapper mapper) : IRequestHandler<GetPurchaseMasterDetailsList, QueryResult<Paging<VmPurchaseMasterDetails>>>
{
    private readonly IPurchaseMasterDetailsRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;

    public async Task<QueryResult<Paging<VmPurchaseMasterDetails>>> Handle(GetPurchaseMasterDetailsList request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.QunIt.Contains(request.SearchText)),
            o => o.OrderBy(x => x.TransactionId),
            se => se);
        var result = data.ToPagingModel<PurchaseMasterDetailss, VmPurchaseMasterDetails>(_mapper);
        return result switch
        {
            null => new QueryResult<Paging<VmPurchaseMasterDetails>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Paging<VmPurchaseMasterDetails>>(result, QueryResultTypeEnum.Success)
        };
    }
}