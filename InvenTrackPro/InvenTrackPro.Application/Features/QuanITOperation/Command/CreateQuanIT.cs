using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Command;
public record CreateQuanIT(VmQuanIT VmQuanIT) : IRequest<CommandResult<VmQuanIT>>;

public class CreateQuanITHandler(IMapper mapper, IValidator<CreateQuanIT> validator,
    IQuanITRepository Repository) : IRequestHandler<CreateQuanIT, CommandResult<VmQuanIT>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateQuanIT> _validator = validator;
    private readonly IQuanITRepository _Repository = Repository;

    public async Task<CommandResult<VmQuanIT>> Handle(CreateQuanIT request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.InsertAsync(_mapper.Map<QuanITs>(request.VmQuanIT));
            return result switch
            {
                not null => new CommandResult<VmQuanIT>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmQuanIT>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreateQuanITValidator : AbstractValidator<CreateQuanIT>
{
    public CreateQuanITValidator()
    {
        RuleFor(x => x.VmQuanIT.Id).Empty();
    }
}