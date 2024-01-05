using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Common.Collection;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Query;
public record GetQuanITDropdown(string SearchText, int Size) : IRequest<QueryResult<Dropdown<VmQuanIT>>>;
public class GetQuanITDropdownHandler(IQuanITRepository Repository) : IRequestHandler<GetQuanITDropdown, QueryResult<Dropdown<VmQuanIT>>>
{
    private readonly IQuanITRepository _Repository = Repository;

    public async Task<QueryResult<Dropdown<VmQuanIT>>> Handle(GetQuanITDropdown request, CancellationToken cancellationToken)
    {
        var result = await _Repository.GetDropdownAsync(
            p => (string.IsNullOrEmpty(request.SearchText) | p.QunITName.Contains(request.SearchText)),
            o => o.OrderBy(ob => ob.Id),
            se => new VmQuanIT { Id = se.Id, QunITName = se.QunITName },
            request.Size);

        return result switch
        {
            null => new QueryResult<Dropdown<VmQuanIT>>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<Dropdown<VmQuanIT>>(result, QueryResultTypeEnum.Success)
        };
    }
}