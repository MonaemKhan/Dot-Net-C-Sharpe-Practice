using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterArchive.Query;

public record GetPurchaseMasterArchiveDetails(long Id) : IRequest<QueryResult<VmPurchaseMasterArchive>>;
public class GetCompanyInfoDetailsHandler(IValidator<GetPurchaseMasterArchiveDetails> validator, IPurchaseMasterArchiveRepository Repository) : IRequestHandler<GetPurchaseMasterArchiveDetails, QueryResult<VmPurchaseMasterArchive>>
{
    private readonly IValidator<GetPurchaseMasterArchiveDetails> _validator = validator;
    private readonly IPurchaseMasterArchiveRepository _Repository = Repository;

    public async Task<QueryResult<VmPurchaseMasterArchive>> Handle(GetPurchaseMasterArchiveDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result switch
            {
                not null => new QueryResult<VmPurchaseMasterArchive>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmPurchaseMasterArchive>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetCompanyInfoDetailsValidator : AbstractValidator<GetPurchaseMasterArchiveDetails>
{
    public GetCompanyInfoDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}
