using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.RepairService.Command;
public record CreateRepairService(VmRepairService VmRepairService) : IRequest<CommandResult<VmRepairService>>;

public class CreateRepairServiceHandler(IMapper mapper, IValidator<CreateRepairService> validator,
    IRepairServiceRepository Repository) : IRequestHandler<CreateRepairService, CommandResult<VmRepairService>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateRepairService> _validator = validator;
    private readonly IRepairServiceRepository _Repository = Repository;

    public async Task<CommandResult<VmRepairService>> Handle(CreateRepairService request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.InsertAsync(_mapper.Map<RepairServices>(request.VmRepairService));
            return result switch
            {
                not null => new CommandResult<VmRepairService>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmRepairService>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreateRepairServiceValidator : AbstractValidator<CreateRepairService>
{
    public CreateRepairServiceValidator()
    {
        RuleFor(x => x.VmRepairService.Id).Empty();
        RuleFor(x => x.VmRepairService.RepairId).NotEmpty().WithMessage("Repair Id Is Required");
        RuleFor(x => x.VmRepairService.PartyId).NotEmpty().WithMessage("Party Id Is Required");
        RuleFor(x => x.VmRepairService.VNo).NotEmpty().WithMessage("VNo Is Required");
        RuleFor(x => x.VmRepairService.VType).NotEmpty().WithMessage("VType Is Required");
        RuleFor(x => x.VmRepairService.BRId).NotEmpty().WithMessage("BR Id Is Required");
        RuleFor(x => x.VmRepairService.YearId).NotEmpty().WithMessage("Year Id Is Required");
    }
}