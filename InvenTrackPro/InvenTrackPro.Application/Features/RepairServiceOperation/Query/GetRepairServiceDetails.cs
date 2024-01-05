using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.RepairService.Query;

public record GetRepairServiceDetails(long Id) : IRequest<QueryResult<VmRepairService>>;
public class GetRepairServiceDetailsHandler(IValidator<GetRepairServiceDetails> validator,
    IRepairServiceRepository Repository) : IRequestHandler<GetRepairServiceDetails, QueryResult<VmRepairService>>
{
    private readonly IValidator<GetRepairServiceDetails> _validator = validator;
    private readonly IRepairServiceRepository _Repository = Repository;

    public async Task<QueryResult<VmRepairService>> Handle(GetRepairServiceDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result switch
            {
                not null => new QueryResult<VmRepairService>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmRepairService>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetRepairServiceDetailsValidator : AbstractValidator<GetRepairServiceDetails>
{
    public GetRepairServiceDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}