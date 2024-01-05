using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.CompanyInfoOperation.Query;

public record GetCompanyInfoDetails(long Id):IRequest<QueryResult<VmCompanyInfo>>;
public class GetCompanyInfoDetailsHandler(IValidator<GetCompanyInfoDetails> validator, ICompanyInfoRepository companyInfoRepository) : IRequestHandler<GetCompanyInfoDetails, QueryResult<VmCompanyInfo>>
{
    private readonly IValidator<GetCompanyInfoDetails> _validator = validator;
    private readonly ICompanyInfoRepository _companyInfoRepository = companyInfoRepository;

    public async Task<QueryResult<VmCompanyInfo>> Handle(GetCompanyInfoDetails request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _companyInfoRepository.FirstOrDefaultAsync(x=>x.Id== request.Id);
            return result switch
            {
                not null => new QueryResult<VmCompanyInfo>(result, QueryResultTypeEnum.Success),
                _ => new QueryResult<VmCompanyInfo>(null, QueryResultTypeEnum.NotFound)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class GetCompanyInfoDetailsValidator : AbstractValidator<GetCompanyInfoDetails>
{
    public GetCompanyInfoDetailsValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}