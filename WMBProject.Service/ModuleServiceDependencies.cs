using Microsoft.Extensions.DependencyInjection;
using WMBProject.Service.Artists;
using WMBProject.Service.Invoices;
using WMBProject.Service.Orders;
using WMBProject.Service.Songs;

namespace WMBProject.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IArtistService, ArtistService>();
        services.AddTransient<ISongService, SongService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IInvoiceService, InvoiceService>();
      //  services.AddTransient<ICustomerService, CustomerService>();

        return services;
    }
}

