using Microsoft.Extensions.DependencyInjection;
using Repository.Entity;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class RepositoryCollectionExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<Hmo>, HmoRepository>();
            services.AddScoped<IDataRepository<Person>, PersonRepository>();
            services.AddScoped<IDataRepository<FatherAndChild>, FatherAndChildRepository>();
            return services;
        }
    }
}
