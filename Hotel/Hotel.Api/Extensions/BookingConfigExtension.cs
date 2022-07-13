using Hotel.Service.Configurations.Implementations;
using Hotel.Service.Configurations.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Hotel.Api.Extensions
{
    public static class BookingConfigExtension
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection service, IConfiguration configuration)
        {
            
            service.AddSingleton<IBookingConfig, BookingConfig>(scope => 
            {
                return new BookingConfig
                {
                    AdvanceDays = configuration.GetValue<int>("BookingConfig:AdvanceDays"),
                    AllowedDays = configuration.GetValue<int>("BookingConfig:AllowedDays")
                };
            });
          
            return service;
        }
    }
}
