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

public record GetStateById(int id):IRequest<QueryResult<StateVM>>;

public class GetStateByIdHandler : IRequestHandler<GetStateById, QueryResult<StateVM>>
{
    private readonly IStateRepository _repository;

    public GetStateByIdHandler(IStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<QueryResult<StateVM>> Handle(GetStateById request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(x => x.Id == request.id, x => x.Country);
        return data switch
        {
            null => new QueryResult<StateVM>(null, QueryResultTypeEnum.NotFound),
            _ => new QueryResult<StateVM>(data, QueryResultTypeEnum.Success),
        };
    }
}
