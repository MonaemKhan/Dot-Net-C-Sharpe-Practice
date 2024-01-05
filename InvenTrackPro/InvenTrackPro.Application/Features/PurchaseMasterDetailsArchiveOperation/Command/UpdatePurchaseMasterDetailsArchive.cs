using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Command;

public record UpdatePurchaseMasterDetailsArchive(long Id, VmPurchaseMasterDetailsArchive VmPurchaseMasterDetailsArchive) : IRequest<CommandResult<VmPurchaseMasterDetailsArchive>>;

public class UpdatePurchaseMasterDetailsArchiveHandler(IPurchaseMasterDetailsArchiveRepository Repository,
    IMapper mapper, IValidator<UpdatePurchaseMasterDetailsArchive> validator) : IRequestHandler<UpdatePurchaseMasterDetailsArchive, CommandResult<VmPurchaseMasterDetailsArchive>>
{
    private readonly IPurchaseMasterDetailsArchiveRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdatePurchaseMasterDetailsArchive> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterDetailsArchive>> Handle(UpdatePurchaseMasterDetailsArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.UpdateAsync(request.Id, _mapper.Map<PurchaseMasterDetailsArchives>(request.VmPurchaseMasterDetailsArchive));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetailsArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetailsArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UpdatePurchaseMasterDetailsArchiveValidator : AbstractValidator<UpdatePurchaseMasterDetailsArchive>
{
    public UpdatePurchaseMasterDetailsArchiveValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmPurchaseMasterDetailsArchive.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmPurchaseMasterDetailsArchive.Id).Equal(x => x.Id).WithMessage("Used Id and Given Id Is Mismatch");
    }
}