using Hotel.Repository;
using Hotel.Repository.Repositories.Implementations;
using Hotel.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Hotel.Api.Extensions
{
    public static class RepositoryExtension
    {
        /// <summary>
        /// Register the Repository to the service
        /// </summary>
        /// <param name="service">IServiceCollection object</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddDbContext<DataContext>(cfg =>
            {

                cfg.UseSqlite("FileName=HotelDb", option =>
                {
                    option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });

            });
            service.AddTransient<Seed>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IBookingRepository, BookingRepository>();
            service.AddScoped<IRoomRepository, RoomRepository>();
            service.AddScoped<IGuestRepository, GuestRepository>();
            service.AddScoped<INotificationRepository, NotificationRepository>();
            return service;
        }
    }
}
