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

public record DeleteTempItemListReport(long Id) : IRequest<CommandResult<VmTempItemListReport>>;

public class DeleteTempItemListReportHandler : IRequestHandler<DeleteTempItemListReport, CommandResult<VmTempItemListReport>>
{
	private readonly ITempItemListReportRepository  _tempItemListReportRepository;

	public DeleteTempItemListReportHandler(ITempItemListReportRepository tempItemListReportRepository)
	{
		_tempItemListReportRepository = tempItemListReportRepository;
	}

	public async Task<CommandResult<VmTempItemListReport>> Handle(DeleteTempItemListReport request, CancellationToken cancellationToken)
	{
		var result = await _tempItemListReportRepository.DeleteAsync(request.Id);
		return result switch
		{
			null => new CommandResult<VmTempItemListReport>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VmTempItemListReport>(result, CommandResultTypeEnum.Success)
		};
	}
}
