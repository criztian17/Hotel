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
                .AddTransient<IGuestService, GuestService>()
                .AddTransient<IRoomService, RoomService>()
                .AddTransient<IBookingService, BookingService>()
                .AddTransient<INotificationService, NotificationService>();
            return services;
        }

    }
}
