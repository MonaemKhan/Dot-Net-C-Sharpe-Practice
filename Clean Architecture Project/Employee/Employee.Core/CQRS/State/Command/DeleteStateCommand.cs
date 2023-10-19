using Employee.Repository.Interface;
using Employee.Service.Model;
using Employee.Shared.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public record DeleteStateCommand(int Id) : IRequest<CommandResult<VMState>>;

public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, CommandResult<VMState>>
{
    private readonly IStateRepository _countryRepository;

    public DeleteStateCommandHandler(IStateRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<CommandResult<VMState>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.DeleteAsync(request.Id);
        return result switch
        {
            null => new CommandResult<VMState>(null, CommandResultTypeEnum.NotFound),
            _ => new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
        };
    }
}