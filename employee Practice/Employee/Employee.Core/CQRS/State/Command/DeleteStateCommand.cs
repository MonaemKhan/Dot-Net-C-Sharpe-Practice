using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.State.Command;

public record DeleteStateCommand(int id):IRequest<CommandResult<StateVM>>;

public class DeleteStateCommandHandler:IRequestHandler<DeleteStateCommand, CommandResult<StateVM>>
{
    private readonly IStateRepository _repository;

    public DeleteStateCommandHandler(IStateRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResult<StateVM>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
    {
        var data = await _repository.DeleteAsync(request.id);
        return data switch
        {
            null => new CommandResult<StateVM>(null,CommandResultTypeEnum.NotFound),
            _=> new CommandResult<StateVM>(data,CommandResultTypeEnum.Success)
        };
    }
}
