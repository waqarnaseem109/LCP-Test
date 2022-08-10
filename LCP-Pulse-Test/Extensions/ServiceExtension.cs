using System;
using Contracts;
using Repository;

namespace LCP_Pulse_Test.Extensions
{
    public static class ServiceExtension
    {

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
           
        }
    }
}

