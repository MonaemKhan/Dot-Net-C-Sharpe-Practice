using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.RepairService.Command;
public record DeleteRepairService(long Id) : IRequest<CommandResult<VmRepairService>>;

public class DeleteRepairServiceHandeler(IRepairServiceRepository repository,
    IValidator<DeleteRepairService> validator) : IRequestHandler<DeleteRepairService, CommandResult<VmRepairService>>
{
    private readonly IRepairServiceRepository _Repository = repository;
    private readonly IValidator<DeleteRepairService> _validator = validator;

    public async Task<CommandResult<VmRepairService>> Handle(DeleteRepairService request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.DeleteAsync(request.Id);
            return result switch
            {
                not null => new CommandResult<VmRepairService>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmRepairService>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new NotImplementedException();
    }
}
public class DeleteRepairServiceValidator : AbstractValidator<DeleteRepairService>
{
    public DeleteRepairServiceValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
    }
}