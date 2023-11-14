using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WEB_API_AUTH_Parctice.DBCon;
using WEB_API_AUTH_Parctice.Mapping;
using WEB_API_AUTH_Parctice.Repository;
using WEB_API_AUTH_Parctice.Repository.Base;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WEB_API_AUTH_Parctice.Repository.Auth;
using WEB_API_AUTH_Parctice.Repository.Token_Generator;
using Microsoft.OpenApi.Models;

namespace WEB_API_AUTH_Parctice.Configuration;

public static class ConfigurationBase
{
    // IServiceCollection class use for configuration or services that we need for our program
    public static IServiceCollection CoreConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.

        services.AddControllers();            

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        //add autorization to swager
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",new OpenApiInfo { Title = "Authorization Practice",Version="v1",Description="useing seperate folder and two seperate database for normal model and auth model. And do role based Authorization"});
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        },
                        Scheme = "Auth 01",
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header

                    },
                    new List<string>()
                }
            });
        });


        // add db class and connection string
        services.AddDbContext<PracticeDbContext>((s, build) =>
        {
            build.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // default connection            
            build.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }, ServiceLifetime.Scoped);
        
        // Auth Db Class
        services.AddDbContext<AuthDbContext>((s, build) =>
        {
            build.UseSqlServer(configuration.GetConnectionString("AuthConnection")); // auth connection           
        }, ServiceLifetime.Scoped);

        services.AddAutoMapper(typeof(MappingProfile).Assembly); // add mapper profile 

        // add repository file
        services.AddScoped(typeof(IBaseRepository<,,>),typeof(BaseRepository<,,>));
        services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
        services.AddScoped(typeof(IAuth), typeof(Auth)); // register auth repository
        services.AddScoped(typeof(IToken), typeof(Token)); // register Token repository

        // before using authentication we use identityCore
        services.AddIdentityCore<IdentityUser>() // setup identity for the solution
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Monaem")
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredLength = 1;
        });


        // add authentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters // JWTs should be validated
                                                                                                       // when they are presented for
                                                                                                       // authentication, for that we have
                                                                                                       // some option
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["jwt:Issuer"],
                ValidAudience = configuration["jwt:Audiance"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["jwt:Key"]))
            }) ;



        return services;
    }
}