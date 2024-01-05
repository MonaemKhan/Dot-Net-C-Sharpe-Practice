using InvenTrackPro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static InvenTrackPro.SharedKernel.Entities.Identities.IdentityModel;

namespace InvenTrackPro.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InvenTrackProContext>((s, builder) =>
        {
            //builder.UseSqlServer(configuration[ApplicationConstants.DefaultConnection]);
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            builder.UseLoggerFactory(s.GetRequiredService<ILoggerFactory>());
            builder.LogTo(Console.WriteLine, LogLevel.Debug);
            // builder.AddInterceptors();
        }, ServiceLifetime.Scoped);

        services.AddIdentity<User, Role>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<InvenTrackProContext>().AddDefaultTokenProviders();

       
        //services.AddScoped(typeof(ICommonService<,>), typeof(CommonService<,>));
        //services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
