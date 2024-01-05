using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.CompanyInfoOperation.Command;

public record CreateCompanyInfo(VmCompanyInfo VmCompanyInfo):IRequest<CommandResult<VmCompanyInfo>>;

public class CreateCompanyInfoHandler : IRequestHandler<CreateCompanyInfo, CommandResult<VmCompanyInfo>>
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCompanyInfo> _validator;
    private readonly ICompanyInfoRepository _companyInfoRepository;

    public CreateCompanyInfoHandler(IMapper mapper, IValidator<CreateCompanyInfo> validator, ICompanyInfoRepository companyInfoRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _companyInfoRepository = companyInfoRepository;
    }

    public async Task<CommandResult<VmCompanyInfo>> Handle(CreateCompanyInfo request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if(validationResult.IsValid)
        {
            var result = await _companyInfoRepository.InsertAsync(_mapper.Map<CompanyInfo>(request.VmCompanyInfo));
            return result switch
            {
                not null => new CommandResult<VmCompanyInfo>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmCompanyInfo>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreateCompanyInfoValidator : AbstractValidator<CreateCompanyInfo>
{
    public CreateCompanyInfoValidator()
    {
        RuleFor(x=>x.VmCompanyInfo.Id).Empty();
        RuleFor(x=>x.VmCompanyInfo.CompanyName).NotEmpty().WithMessage("Company Name is required.");
        RuleFor(x=>x.VmCompanyInfo.Email).NotEmpty().EmailAddress().WithMessage("Company Name is required.");
    }
}