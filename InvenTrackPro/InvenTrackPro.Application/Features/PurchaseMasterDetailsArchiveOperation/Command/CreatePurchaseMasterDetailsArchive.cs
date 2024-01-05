using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Models.Entities;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.SharedKernel.Entities;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;

namespace InvenTrackPro.Application.Features.PurchaseMasterDetailsArchive.Command;

public record CreatePurchaseMasterDetailsArchive(VmPurchaseMasterDetailsArchive VmPurchaseMasterDetailsArchive) : IRequest<CommandResult<VmPurchaseMasterDetailsArchive>>;

public class CreatePurchaseMasterDetailsArchiveHandler(IMapper mapper, IValidator<CreatePurchaseMasterDetailsArchive> validator,
    IPurchaseMasterDetailsArchiveRepository Repository) : IRequestHandler<CreatePurchaseMasterDetailsArchive, CommandResult<VmPurchaseMasterDetailsArchive>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreatePurchaseMasterDetailsArchive> _validator = validator;
    private readonly IPurchaseMasterDetailsArchiveRepository _Repository = Repository;

    public async Task<CommandResult<VmPurchaseMasterDetailsArchive>> Handle(CreatePurchaseMasterDetailsArchive request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var result = await _Repository.InsertAsync(_mapper.Map<PurchaseMasterDetailsArchives>(request.VmPurchaseMasterDetailsArchive));
            return result switch
            {
                not null => new CommandResult<VmPurchaseMasterDetailsArchive>(result, CommandResultTypeEnum.Success),
                _ => new CommandResult<VmPurchaseMasterDetailsArchive>(null, CommandResultTypeEnum.UnprocessableEntity)
            };
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class CreatePurchaseMasterDetailsArchiveValidator : AbstractValidator<CreatePurchaseMasterDetailsArchive>
{
    public CreatePurchaseMasterDetailsArchiveValidator()
    {
        RuleFor(x => x.VmPurchaseMasterDetailsArchive.Id).Empty();
    }
}