using FluentValidation;
using InvenTrackPro.Application.Models.Auth;
using InvenTrackPro.SharedKernel.Common;
using InvenTrackPro.SharedKernel.Extensions.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel;

namespace InvenTrackPro.Application.Features.AuthOperation.Command;

public record UserLoginCommand(LoginModel LoginModel) : IRequest<CommandResult<LoginResponse>>;
public class UserLoginCommandHandler(IConfiguration configuration, UserManager<User> userManager, IValidator<UserLoginCommand> validator, IOptions<JwtConfig> jwtConfig) : IRequestHandler<UserLoginCommand, CommandResult<LoginResponse>>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IValidator<UserLoginCommand> _validator = validator;
    private readonly JwtConfig _jwtConfig = jwtConfig.Value;

    public async Task<CommandResult<LoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userManager.FindByNameAsync(request.LoginModel.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.LoginModel.Password))
            return new CommandResult<LoginResponse>(null, CommandResultTypeEnum.Unauthorized);

        var authClaims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, user.UserName!),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new("UserId", user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        var secretKey = _jwtConfig.SecretKey;
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey!));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience,
            Subject = new ClaimsIdentity(authClaims),
            Expires = DateTime.Now.AddMinutes(_jwtConfig.ValidForInMinutes),
            SigningCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha512Signature),


        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        await _userManager.SetAuthenticationTokenAsync(user, "HRMaster", "authToken", tokenString);
        return new CommandResult<LoginResponse>(new LoginResponse(tokenString, token.ValidTo),
            CommandResultTypeEnum.Success);
    }
}

public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(x => x.LoginModel).NotNull().WithMessage("'{PropertyName}' information is required.");
        RuleFor(x => x.LoginModel.Email)
            .NotEmpty().WithMessage("'{PropertyName}' is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.LoginModel.Password).NotEmpty().WithMessage("'{PropertyName}' is required.");
    }
}