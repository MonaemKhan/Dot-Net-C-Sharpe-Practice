using FluentValidation;
using InvenTrackPro.Application.Features.CompanyInfoOperation.Query;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenTrackPro.Application.Features.TempItemListReportOperation.Query;

public record GetTempItemListReportDetails(long Id) : IRequest<QueryResult<VmTempItemListReport>>;
public class GetTempItemListReportDetailsHandler(IValidator<GetTempItemListReportDetails> validator, ITempItemListReportRepository tempItemListReportRepository) : IRequestHandler<GetTempItemListReportDetails, QueryResult<VmTempItemListReport>>
{
	private readonly IValidator<GetTempItemListReportDetails> _validator = validator;
	private readonly ITempItemListReportRepository _tempItemListReportRepository = tempItemListReportRepository;

	public async Task<QueryResult<VmTempItemListReport>> Handle(GetTempItemListReportDetails request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request, cancellationToken);
		if (validationResult.IsValid)
		{
			var result = await _tempItemListReportRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
			return result switch
			{
				not null => new QueryResult<VmTempItemListReport>(result, QueryResultTypeEnum.Success),
				_ => new QueryResult<VmTempItemListReport>(null, QueryResultTypeEnum.NotFound)
			};
		}
		throw new ValidationException(validationResult.Errors);
	}
}
public class GetTempItemListReportDetailsValidator : AbstractValidator<GetTempItemListReportDetails>
{
	public GetTempItemListReportDetailsValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
	}
}