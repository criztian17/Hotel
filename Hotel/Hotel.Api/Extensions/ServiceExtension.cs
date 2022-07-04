using Hotel.Service.Implementations;
using Hotel.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Api.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services
                .AddScoped<IGuestService, GuestService>()
                .AddScoped<IRoomService, RoomService>()
                .AddScoped<IBookingService, BookingService>()
                .AddScoped<INotificationService, NotificationService>();
            return services;
        }

    }
}
