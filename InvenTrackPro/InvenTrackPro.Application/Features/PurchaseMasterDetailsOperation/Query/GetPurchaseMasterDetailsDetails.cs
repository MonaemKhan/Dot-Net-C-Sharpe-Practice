using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetails.Query;

public record GetPurchaseMasterDetailsDetails(long Id) : IRequest<QueryResult<VmPurchaseMasterDetails>>;
public class GetPurchaseMasterDetailsDetailsHandler(IValidator<GetPurchaseMasterDetailsDetails> validator, 
    IPurchaseMasterDetailsRepository Repository) : IRequestHandler<GetPurchaseMasterDetailsDetails, QueryResult<VmPurchaseMasterDetails>>
{
    private readonly IValidator<GetPurchaseMasterDetailsDetails> _validator = validator;
    private readonly IPurchaseMasterDetailsRepository _Repository = Repository;

    public async Task<QueryResult<VmPurchaseMasterDetails>> Handle(GetPurchaseMasterDetailsDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result switch
            {
                not null => new QueryResult<VmPurchaseMasterDetails>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmPurchaseMasterDetails>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetCompanyInfoDetailsValidator : AbstractValidator<GetPurchaseMasterDetailsDetails>
{
    public GetCompanyInfoDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}