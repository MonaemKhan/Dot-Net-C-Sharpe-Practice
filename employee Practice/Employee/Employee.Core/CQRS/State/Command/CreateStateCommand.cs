using AutoMapper;
using Employee.Model;
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

public record CreateStateCommand(StateVM _data):IRequest<CommandResult<StateVM>>;

public class CreateStateCommandHandeler : IRequestHandler<CreateStateCommand, CommandResult<StateVM>>
{
    private readonly IStateRepository _repository;
    private readonly IMapper _mapper;

    public CreateStateCommandHandeler(IStateRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CommandResult<StateVM>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
    {
        var data = await _repository.InsertAsync(_mapper.Map<States>(request._data));
        return data switch
        {
            null => new CommandResult<StateVM>(null,CommandResultTypeEnum.NotFound),
            _=> new CommandResult<StateVM>(data,CommandResultTypeEnum.Created)
        };
    }
}
