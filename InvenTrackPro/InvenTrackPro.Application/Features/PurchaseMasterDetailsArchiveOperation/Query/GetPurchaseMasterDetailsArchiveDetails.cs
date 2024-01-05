using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Query;

public record GetPurchaseMasterDetailsArchiveDetails(long Id) : IRequest<QueryResult<VmPurchaseMasterDetailsArchive>>;
public class GetPurchaseMasterDetailsArchiveDetailsHandler(IValidator<GetPurchaseMasterDetailsArchiveDetails> validator,
    IPurchaseMasterDetailsArchiveRepository Repository) : IRequestHandler<GetPurchaseMasterDetailsArchiveDetails, QueryResult<VmPurchaseMasterDetailsArchive>>
{
    private readonly IValidator<GetPurchaseMasterDetailsArchiveDetails> _validator = validator;
    private readonly IPurchaseMasterDetailsArchiveRepository _Repository = Repository;

    public async Task<QueryResult<VmPurchaseMasterDetailsArchive>> Handle(GetPurchaseMasterDetailsArchiveDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result switch
            {
                not null => new QueryResult<VmPurchaseMasterDetailsArchive>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmPurchaseMasterDetailsArchive>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetPurchaseMasterDetailsArchiveDetailsValidator : AbstractValidator<GetPurchaseMasterDetailsArchiveDetails>
{
    public GetPurchaseMasterDetailsArchiveDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}