using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetails.Command;

public record CreatePurchaseMasterDetails(VmPurchaseMasterDetails VmPurchaseMasterDetails) : IRequest<CommandResult<VmPurchaseMasterDetails>>;

public class CreatePurchaseMasterDetailsHandler(IMapper mapper, IValidator<CreatePurchaseMasterDetails> validator,
    IPurchaseMasterDetailsRepository Repository) : IRequestHandler<CreatePurchaseMasterDetails, CommandResult<VmPurchaseMasterDetails>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreatePurchaseMasterDetails> _validator = validator;
    private readonly IPurchaseMasterDetailsRepository _Repository = Repository;

    public async Task<CommandResult<VmPurchaseMasterDetails>> Handle(CreatePurchaseMasterDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.InsertAsync(_mapper.Map<PurchaseMasterDetailss>(request.VmPurchaseMasterDetails));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetails>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetails>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreatePurchaseMasterDetailsValidator : AbstractValidator<CreatePurchaseMasterDetails>
{
    public CreatePurchaseMasterDetailsValidator()
    {
        RuleFor(x => x.VmPurchaseMasterDetails.Id).Empty();
        RuleFor(x => x.VmPurchaseMasterDetails.TransactionId).NotEmpty().WithMessage("Transaction Id is Required");
    }
}