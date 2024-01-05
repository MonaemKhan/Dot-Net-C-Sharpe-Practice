using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Command;
public record DeleteQuanIT(long Id) : IRequest<CommandResult<VmQuanIT>>;

public class DeleteQuanITHandeler(IQuanITRepository repository,
    IValidator<DeleteQuanIT> validator) : IRequestHandler<DeleteQuanIT, CommandResult<VmQuanIT>>
{
    private readonly IQuanITRepository _Repository = repository;
    private readonly IValidator<DeleteQuanIT> _validator = validator;

    public async Task<CommandResult<VmQuanIT>> Handle(DeleteQuanIT request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.DeleteAsync(request.Id);
            return result switch
            {
                not null => new CommandResult<VmQuanIT>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmQuanIT>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new NotImplementedException();
    }
}
public class DeleteQuanITValidator : AbstractValidator<DeleteQuanIT>
{
    public DeleteQuanITValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Requried");
    }
}