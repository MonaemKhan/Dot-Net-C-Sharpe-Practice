using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterArchive.Command;

public record UpdatePurchaseMasterArchive(long Id,VmPurchaseMasterArchive VmPurchaseMasterArchive) :IRequest<CommandResult<VmPurchaseMasterArchive>>;

public class UpdatePurchaseMasterArchiveHandler(IPurchaseMasterArchiveRepository Repository,IMapper mapper, IValidator<UpdatePurchaseMasterArchive> validator) : IRequestHandler<UpdatePurchaseMasterArchive, CommandResult<VmPurchaseMasterArchive>>
{
    private readonly IPurchaseMasterArchiveRepository _Repository = Repository;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<UpdatePurchaseMasterArchive> _validator = validator;

    public async Task<CommandResult<VmPurchaseMasterArchive>> Handle(UpdatePurchaseMasterArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.UpdateAsync(request.Id,_mapper.Map<PurchaseMasterArchives>(request.VmPurchaseMasterArchive));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UpdatePurchaseMasterArchiveValidator : AbstractValidator<UpdatePurchaseMasterArchive>
{
    public UpdatePurchaseMasterArchiveValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Enter an Id Is Required");
        RuleFor(x => x.VmPurchaseMasterArchive.Id).NotEmpty().WithMessage("Id Is Required");
        RuleFor(x => x.VmPurchaseMasterArchive.Id).Equal(x => x.Id).WithMessage("Used Id and Given Id Is Mismatch");
    }
}