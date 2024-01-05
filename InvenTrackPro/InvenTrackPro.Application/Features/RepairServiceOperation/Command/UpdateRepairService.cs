using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.RepairService.Command;
public record UpdateRepairService(long Id, VmRepairService VmRepairService) : IRequest<CommandResult<VmRepairService>>;

public class UpdateRepairServiceHandler(IRepairServiceRepository Repository,
    IMapper mapper, IValidator<UpdateRepairService> validator) : IRequestHandler<UpdateRepairService, CommandResult<VmRepairService>>
{
    private readonly IRepairServiceRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdateRepairService> _validator = validator;

    public async Task<CommandResult<VmRepairService>> Handle(UpdateRepairService request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.UpdateAsync(request.Id, _mapper.Map<RepairServices>(request.VmRepairService));
            return result switch
            {
                not null => new CommandResult<VmRepairService>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmRepairService>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UpdateRepairServiceValidator : AbstractValidator<UpdateRepairService>
{
    public UpdateRepairServiceValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmRepairService.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmRepairService.Id).Equal(x => x.Id).WithMessage("Used Id and Given Id Is Mismatch");
        RuleFor(x => x.VmRepairService.RepairId).NotEmpty().WithMessage("Repair Id Is Required");
        RuleFor(x => x.VmRepairService.PartyId).NotEmpty().WithMessage("Party Id Is Required");
        RuleFor(x => x.VmRepairService.VNo).NotEmpty().WithMessage("VNo Is Required");
        RuleFor(x => x.VmRepairService.VType).NotEmpty().WithMessage("VType Is Required");
        RuleFor(x => x.VmRepairService.BRId).NotEmpty().WithMessage("BR Id Is Required");
        RuleFor(x => x.VmRepairService.YearId).NotEmpty().WithMessage("Year Id Is Required");
    }
}