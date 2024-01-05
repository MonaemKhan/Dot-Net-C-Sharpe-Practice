using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterArchive.Command;

public record DeletePurchaseMasterArchive(long Id):IRequest<CommandResult<VmPurchaseMasterArchive>>;

public class DeletePurchaseMasterArchiveHandeler(IPurchaseMasterArchiveRepository repository, IValidator<DeletePurchaseMasterArchive> validator) : IRequestHandler<DeletePurchaseMasterArchive, CommandResult<VmPurchaseMasterArchive>>
{
    private readonly IPurchaseMasterArchiveRepository _Repository = repository;
    private readonly IValidator<DeletePurchaseMasterArchive> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterArchive>> Handle(DeletePurchaseMasterArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.DeleteAsync(request.Id);
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new NotImplementedException();
    }
}
public class DeletePurchaseMasterArchiveValidator : AbstractValidator<DeletePurchaseMasterArchive>
{
    public DeletePurchaseMasterArchiveValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Requried");
    }
}