using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Command;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Features.TempItemListReportOperation.Command;

public record CreateTempItemListReport(VmTempItemListReport vmTempItemListReport) : IRequest<CommandResult<VmTempItemListReport>>;

public class CreateTempItemListReportHandler : IRequestHandler<CreateTempItemListReport, CommandResult<VmTempItemListReport>>
{
	private readonly IMapper _mapper;
	private readonly IValidator<CreateTempItemListReport> _validator;
	private readonly ITempItemListReportRepository _tempItemListReportRepository;

	public CreateTempItemListReportHandler(IMapper mapper, IValidator<CreateTempItemListReport> validator, ITempItemListReportRepository tempItemListReportRepository)
	{
		_mapper = mapper;
		_validator = validator;
		_tempItemListReportRepository = tempItemListReportRepository;
	}

	public async Task<CommandResult<VmTempItemListReport>> Handle(CreateTempItemListReport request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request, cancellationToken);
		if (validationResult.IsValid)
		{
			var result = await _tempItemListReportRepository.InsertAsync(_mapper.Map<TempItemListReport>(request.vmTempItemListReport));
			return result switch
			{
				not null => new CommandResult<VmTempItemListReport>(result, CommandResultTypeEnum.Success),
				_ => new CommandResult<VmTempItemListReport>(null, CommandResultTypeEnum.UnprocessableEntity)
			};
		}
		throw new ValidationException(validationResult.Errors);
	}
}

public class CreateTempItemListReportValidator : AbstractValidator<CreateTempItemListReport>
{
	public CreateTempItemListReportValidator()
	{
		RuleFor(x => x.vmTempItemListReport.Id).Empty();
		//RuleFor(x => x.VmCompanyInfo.CompanyName).NotEmpty().WithMessage("Company Name is required.");
		//RuleFor(x => x.VmCompanyInfo.Email).NotEmpty().EmailAddress().WithMessage("Company Name is required.");
	}
}