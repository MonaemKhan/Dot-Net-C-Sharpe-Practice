using FluentValidation;
using InvenTrackPro.Application.Models.Auth;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel;

namespace InvenTrackPro.Application.Features.AuthOperation.Command;

public record UserRegistration(RegistrationModel RegistrationModel) : IRequest<CommandResult<RegistrationResponse>>;
public class UserRegistrationHandler(UserManager<User> userManager, IValidator<UserRegistration> validator) : IRequestHandler<UserRegistration, CommandResult<RegistrationResponse>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IValidator<UserRegistration> _validator = validator;

    public async Task<CommandResult<RegistrationResponse>> Handle(UserRegistration request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var existingUser = await _userManager.FindByNameAsync(request.RegistrationModel.UserName);

            if (existingUser is not null)
            {
                throw new Exception($"Username '{request.RegistrationModel.UserName}' already exists.");
            }

            var existingEmail = await _userManager.FindByEmailAsync(request.RegistrationModel.Email);
            var user = new User
            {
                Email = request.RegistrationModel.Email,
                UserName = request.RegistrationModel.UserName,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            if (existingEmail is null)
            {
                var result = await _userManager.CreateAsync(user, request.RegistrationModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return new CommandResult<RegistrationResponse>(new RegistrationResponse() { UserId = user.Id }, CommandResultTypeEnum.Success);
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            throw new Exception($"Email {request.RegistrationModel.Email} already exists.");
        }
        throw new ValidationException(validationResult.Errors);
    }
}

public class UserRegistrationValidator : AbstractValidator<UserRegistration>
{
    public UserRegistrationValidator()
    {
        RuleFor(x => x.RegistrationModel).NotNull().WithMessage("'{PropertyName}' information is required.");
        RuleFor(x => x.RegistrationModel.Email)
            .NotEmpty().WithMessage("'{PropertyName}' is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.RegistrationModel.UserName)
            .NotEmpty().WithMessage("'{PropertyName}' is required.");

        RuleFor(x => x.RegistrationModel.Password)
            .NotEmpty().WithMessage("'{PropertyName}' is required.")
            .Length(6, 26).WithMessage("Password length must be between 6 and 26 characters")
            .Matches(@"([A-Z])").WithMessage("At least one uppercase letter")
            .Matches(@"([a-z])").WithMessage("At least one lowercase letter")
            .Matches(@"([0-9])").WithMessage("At least one number")
            .Matches(@"([#?!@$%^&*-])").WithMessage("At least one special character");

    }

}