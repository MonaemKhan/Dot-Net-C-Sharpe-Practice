using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Command;

public record DeletePurchaseMasterDetailsArchive(long Id) : IRequest<CommandResult<VmPurchaseMasterDetailsArchive>>;

public class DeletePurchaseMasterDetailsArchiveHandeler(IPurchaseMasterDetailsArchiveRepository repository,
    IValidator<DeletePurchaseMasterDetailsArchive> validator) : IRequestHandler<DeletePurchaseMasterDetailsArchive, CommandResult<VmPurchaseMasterDetailsArchive>>
{
    private readonly IPurchaseMasterDetailsArchiveRepository _Repository = repository;
    private readonly IValidator<DeletePurchaseMasterDetailsArchive> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterDetailsArchive>> Handle(DeletePurchaseMasterDetailsArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.DeleteAsync(request.Id);
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetailsArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetailsArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new NotImplementedException();
    }
}
public class DeletePurchaseMasterDetailsArchiveValidator : AbstractValidator<DeletePurchaseMasterDetailsArchive>
{
    public DeletePurchaseMasterDetailsArchiveValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Requried");
    }
}