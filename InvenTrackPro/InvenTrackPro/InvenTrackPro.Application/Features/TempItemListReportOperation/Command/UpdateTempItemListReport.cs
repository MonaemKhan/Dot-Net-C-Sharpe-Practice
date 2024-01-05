using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Command;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Features.TempItemListReportOperation.Command;

public record UpdateTempItemListReport(long Id, VmTempItemListReport VmTempItemListReport) : IRequest<CommandResult<VmTempItemListReport>>;

public class UpdateTempItemListReportHandler(ITempItemListReportRepository tempItemListReportRepository,
	IMapper mapper, IValidator<UpdateTempItemListReport> tempItemListReportValidator) : IRequestHandler<UpdateTempItemListReport, CommandResult<VmTempItemListReport>>
{
	private readonly ITempItemListReportRepository _tempItemListReportRepository = tempItemListReportRepository;
	private readonly IMapper _mapper = mapper;
	private readonly IValidator<UpdateTempItemListReport> _tempItemListReportValidator = tempItemListReportValidator;

	public async Task<CommandResult<VmTempItemListReport>> Handle(UpdateTempItemListReport request, CancellationToken cancellationToken)
	{
		var validationResult = await _tempItemListReportValidator.ValidateAsync(request, cancellationToken);
		if (validationResult.IsValid)
		{
			var result = await _tempItemListReportRepository.UpdateAsync(request.Id, _mapper.Map<SharedKernel.Entities.TempItemListReport>(request.VmTempItemListReport));
			return result switch
			{
				not null => new CommandResult<VmTempItemListReport>(result, CommandResultTypeEnum.Success),
				_ => new CommandResult<VmTempItemListReport>(null, CommandResultTypeEnum.UnprocessableEntity)
			};
		}
		throw new ValidationException(validationResult.Errors);
	}
}


public class UpdateTempItemListReportValidator : AbstractValidator<UpdateTempItemListReport>
{
    public UpdateTempItemListReportValidator()
    {
        RuleFor(x => x.VmTempItemListReport.Id).NotEmpty();
    }
}