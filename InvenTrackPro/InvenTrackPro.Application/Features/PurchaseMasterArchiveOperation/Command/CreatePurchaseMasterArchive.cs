using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterArchive.Command;

public record CreatePurchaseMasterArchive(VmPurchaseMasterArchive VmPurchaseMasterArchive) : IRequest<CommandResult<VmPurchaseMasterArchive>>;

public class CreatePurchaseMasterArchiveHandler(IMapper mapper, IValidator<CreatePurchaseMasterArchive> validator, IPurchaseMasterArchiveRepository Repository) : IRequestHandler<CreatePurchaseMasterArchive, CommandResult<VmPurchaseMasterArchive>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreatePurchaseMasterArchive> _validator = validator;
    private readonly IPurchaseMasterArchiveRepository _Repository = Repository;

    public async Task<CommandResult<VmPurchaseMasterArchive>> Handle(CreatePurchaseMasterArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.InsertAsync(_mapper.Map<PurchaseMasterArchives>(request.VmPurchaseMasterArchive));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreatePurchaseMasterArchiveValidator : AbstractValidator<CreatePurchaseMasterArchive>
{
    public CreatePurchaseMasterArchiveValidator()
    {
        RuleFor(x => x.VmPurchaseMasterArchive.Id).Empty();
    }
}