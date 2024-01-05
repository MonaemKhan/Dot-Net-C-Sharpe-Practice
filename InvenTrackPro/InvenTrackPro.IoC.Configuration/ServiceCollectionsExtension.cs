using InvenTrackPro.Infrastructure;
using InvenTrackPro.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using InvenTrackPro.SharedKernel.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InvenTrackPro.IoC.Configuration;
public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddServiceRegistation(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices(configuration);
        services.AddHttpContextAccessor();
        services.AddControllers(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                             .RequireAuthenticatedUser()
                             .Build();
            config.Filters.Add(new AuthorizeFilter(policy));

        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        services.AddOptions();
        //services.AddOptions<ApplicationSettings>(ApplicationConstants.ApplicationSettings);

        var origins = configuration.GetSection("Domain").Get<Domain>();
        if (origins.ClientTwo.Count != 0) { origins?.ClientOne?.AddRange(origins.ClientTwo); }

        services.AddCors(options => options.AddPolicy("InvenTrackPro", builder =>
        {
            builder.WithOrigins(origins?.ClientOne?.ToArray())
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        }));
        services.AddResponseCaching();
        services.AddResponseCompression();
        services.AddDistributedMemoryCache();
        // services.AddCertificateForwarding(conf=>conf.CertificateHeader="");
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
        });

        //var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidAudience = configuration["JwtConfig:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"]))
            };
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.ResolveConflictingActions(o => o.First());
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "InvenTrackPro",
                Description = "An ASP.NET Core Web API for Inventory Management System (IMS)",
                Contact = new OpenApiContact
                {
                    Name = "Tactsoft Limited",
                    Url = new Uri("http://tactsoftltd.com"),
                },
                License = new OpenApiLicense
                {
                    Name = "Apache License",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.txt")
                }
            });

        });
        return services;
    }
}
