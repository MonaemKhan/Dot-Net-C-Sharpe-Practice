using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Query;

public record GetAllState:IRequest<QueryResult<IEnumerable<StateVM>>>;

public class GetAllStateHandler : IRequestHandler<GetAllState, QueryResult<IEnumerable<StateVM>>>
{
    private readonly IStateRepository _repository;
    public GetAllStateHandler(IStateRepository repository)
    {
        _repository = repository;
    }
    public async Task<QueryResult<IEnumerable<StateVM>>> Handle(GetAllState request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync(x => x.Country);
        return data switch
        {
            null => new QueryResult<IEnumerable<StateVM>>(null,QueryResultTypeEnum.NotFound),
            _=>new QueryResult<IEnumerable<StateVM>>(data, QueryResultTypeEnum.Success),
        };
    }
}
