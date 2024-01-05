using AutoMapper;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Query;

public record GetPurchaseMasterDetailsArchivesList(int PageIndex, int PageSize, string SearchText) : IRequest<QueryResult<Paging<VmPurchaseMasterDetailsArchive>>>;
public class GetPurchaseMasterDetailsArchivesListHandler(IPurchaseMasterDetailsArchiveRepository Repository,
    IMapper mapper) : IRequestHandler<GetPurchaseMasterDetailsArchivesList, QueryResult<Paging<VmPurchaseMasterDetailsArchive>>>
{
    private readonly IPurchaseMasterDetailsArchiveRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;

    public async Task<QueryResult<Paging<VmPurchaseMasterDetailsArchive>>> Handle(GetPurchaseMasterDetailsArchivesList request, CancellationToken cancellationToken)
    {
        var data = await _Repository.GetPageAsync(request.PageIndex, request.PageSize,
            p => (string.IsNullOrEmpty(request.SearchText) || p.QunIt.Contains(request.SearchText)),
            o => o.OrderBy(x => x.Id),
            se => se);
        var result = data.ToPagingModel<PurchaseMasterDetailsArchives, VmPurchaseMasterDetailsArchive>(_mapper);
        return result switch
        {
            null => new QueryResult<Paging<VmPurchaseMasterDetailsArchive>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Paging<VmPurchaseMasterDetailsArchive>>(result, QueryResultTypeEnum.Success)
        };
    }
}