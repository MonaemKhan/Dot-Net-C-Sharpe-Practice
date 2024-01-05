using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetails.Command;

public record DeletePurchaseMasterDetails(long Id) : IRequest<CommandResult<VmPurchaseMasterDetails>>;

public class DeletePurchaseMasterDetailsHandeler(IPurchaseMasterDetailsRepository repository, 
    IValidator<DeletePurchaseMasterDetails> validator) : IRequestHandler<DeletePurchaseMasterDetails, CommandResult<VmPurchaseMasterDetails>>
{
    private readonly IPurchaseMasterDetailsRepository _Repository = repository;
    private readonly IValidator<DeletePurchaseMasterDetails> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterDetails>> Handle(DeletePurchaseMasterDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.DeleteAsync(request.Id);
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetails>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetails>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new NotImplementedException();
    }
}
public class DeletePurchaseMasterDetailsValidator : AbstractValidator<DeletePurchaseMasterDetails>
{
    public DeletePurchaseMasterDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
    }
}