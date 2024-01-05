using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetails.Command;

public record UpdatePurchaseMasterDetails(long Id, VmPurchaseMasterDetails VmPurchaseMasterDetails) : IRequest<CommandResult<VmPurchaseMasterDetails>>;

public class UpdatePurchaseMasterDetailsHandler(IPurchaseMasterDetailsRepository Repository, 
    IMapper mapper, IValidator<UpdatePurchaseMasterDetails> validator) : IRequestHandler<UpdatePurchaseMasterDetails, CommandResult<VmPurchaseMasterDetails>>
{
    private readonly IPurchaseMasterDetailsRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdatePurchaseMasterDetails> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterDetails>> Handle(UpdatePurchaseMasterDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.UpdateAsync(request.Id, _mapper.Map<PurchaseMasterDetailss>(request.VmPurchaseMasterDetails));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetails>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetails>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UpdatePurchaseMasterArchiveValidator : AbstractValidator<UpdatePurchaseMasterDetails>
{
    public UpdatePurchaseMasterArchiveValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmPurchaseMasterDetails.Id).NotEmpty().WithMessage("Id is Required");
        RuleFor(x => x.VmPurchaseMasterDetails.Id).Equal(x => x.Id).WithMessage("Used Id and Given Id Is Mismatch");
        RuleFor(x => x.VmPurchaseMasterDetails.TransactionId).NotEmpty().WithMessage("Transaction Id is Required");
    }
}