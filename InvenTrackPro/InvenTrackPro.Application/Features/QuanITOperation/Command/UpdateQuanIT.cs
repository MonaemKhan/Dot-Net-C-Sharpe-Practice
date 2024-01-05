using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Command;
public record UpdateQuanIT(long Id, VmQuanIT VmQuanIT) : IRequest<CommandResult<VmQuanIT>>;

public class UpdateQuanITHandler(IQuanITRepository Repository,
    IMapper mapper, IValidator<UpdateQuanIT> validator) : IRequestHandler<UpdateQuanIT, CommandResult<VmQuanIT>>
{
    private readonly IQuanITRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdateQuanIT> _validator = validator;

    public async Task<CommandResult<VmQuanIT>> Handle(UpdateQuanIT request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.UpdateAsync(request.Id, _mapper.Map<QuanITs>(request.VmQuanIT));
            return result switch
            {
                not null => new CommandResult<VmQuanIT>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmQuanIT>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UpdateQuanITValidator : AbstractValidator<UpdateQuanIT>
{
    public UpdateQuanITValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmQuanIT.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmQuanIT.Id).Equal(x => x.Id).WithMessage("Used Id and Given Id Is Mismatch");
    }
}