using Microsoft.Extensions.DependencyInjection;
using WMBProject.Service.Artists;
using WMBProject.Service.Authentications;
using WMBProject.Service.Invoices;
using WMBProject.Service.Orders;
using WMBProject.Service.Songs;
using WMBProject.Service.StaticServices;

namespace WMBProject.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IArtistService, ArtistService>();
        services.AddTransient<ISongService, SongService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IInvoiceService, InvoiceService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IStaticService, StaticService>();

        //  services.AddTransient<ICustomerService, CustomerService>();

        return services;
    }
}

