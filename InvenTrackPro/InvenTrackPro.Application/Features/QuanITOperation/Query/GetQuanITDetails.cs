using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.QuanIT.Query;
public record GetQuanITDetails(long Id) : IRequest<QueryResult<VmQuanIT>>;
public class GetQuanITDetailsHandler(IValidator<GetQuanITDetails> validator,
    IQuanITRepository Repository) : IRequestHandler<GetQuanITDetails, QueryResult<VmQuanIT>>
{
    private readonly IValidator<GetQuanITDetails> _validator = validator;
    private readonly IQuanITRepository _Repository = Repository;

    public async Task<QueryResult<VmQuanIT>> Handle(GetQuanITDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.FirstOrDefaultAsync(x => x.Id == request.Id);
            return result switch
            {
                not null => new QueryResult<VmQuanIT>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmQuanIT>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetQuanITDetailsValidator : AbstractValidator<GetQuanITDetails>
{
    public GetQuanITDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}