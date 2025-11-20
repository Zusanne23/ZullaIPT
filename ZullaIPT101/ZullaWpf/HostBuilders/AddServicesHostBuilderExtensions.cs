using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZullaWpf.ViewModels;
using ZullaWpfDomain.Commands;
using ZullaWpfDomain.Models;
using ZullaWpfDomain.Queries;
using ZullaWpfFramework.Commands;
using ZullaWpfFramework.Queries;

namespace ZullaWpf.HostBuilders;

public static class AddServicesHostBuilderExtensions
{
    public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            services.AddSingleton<MainViewModel>();

            services.AddScoped<ICommandHandler<CreateDanceClassCommand>, CreateDanceClassCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateDanceClassCommand>, UpdateDanceClassCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteDanceClassCommand>, DeleteDanceClassCommandHandler>();
            services.AddScoped<IQueryHandler<GetAllDanceClassesQuery, IEnumerable<DanceClass>>, GetAllDanceClassesQueryHandler>();
        });

        return hostBuilder;
    }
}
