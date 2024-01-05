using AutoMapper;
using FluentValidation;
using InvenTrackPro.Application.Profiles;
using InvenTrackPro.Application.Repositories;
using InvenTrackPro.Application.Repositories.BaseRepo;
using InvenTrackPro.Infrastructure.Interfaces;
using InvenTrackPro.Infrastructure.Interfaces.BaseRepo;
using InvenTrackPro.SharedKernel.Common.Behavior;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackPro.Application;

public static class ServiceCollectionExtensions
{
    //public static void ValidateConfigure(this IApplicationBuilder app, IMapper mapper)
    //{
    //    ArgumentNullException.ThrowIfNull(app);
    //    mapper.ConfigurationProvider.AssertConfigurationIsValid();
    //}
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
        .AddClasses(classes => classes.AssignableTo<IApplication>())
        .AsSelfWithInterfaces()
        .WithTransientLifetime());

        services.AddValidatorsFromAssembly(typeof(IApplication).Assembly);
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(typeof(IApplication).Assembly);
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

        });

        //services.AddAutoMapper(x =>
        //{
        //    x.AddMaps(typeof(IApplication).Assembly);
        //});
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
        services.AddScoped(typeof(ICompanyInfoRepository), typeof(CompanyInfoRepository));
        services.AddScoped(typeof(IPurchaseMasterArchiveRepository), typeof(PurchaseMasterArchiveRepository));
        services.AddScoped(typeof(IPurchaseMasterDetailsRepository), typeof(PurchaseMasterDetailsRepository));
        services.AddScoped(typeof(IPurchaseMasterDetailsArchiveRepository), typeof(PurchaseMasterDetailsArchiveRepository));
        services.AddScoped(typeof(IRepairServiceRepository), typeof(RepairServiceRepository));
        services.AddScoped(typeof(IQuanITRepository), typeof(QuanITRepository));

        return services;
    }
}
