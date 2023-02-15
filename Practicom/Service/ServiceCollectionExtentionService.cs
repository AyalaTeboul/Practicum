using Common.Dto_s;
using Context;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceCollectionExtentionService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IDataService<PersonDto>, PersonServices>();
            services.AddScoped<IDataService<HmoDto>,HmoServices>();
            services.AddScoped<IDataService<FatherAndChildDto>,FatherAndChildServices>();
            services.AddSingleton<IContext, PracticomContext>();
             
            services.AddAutoMapper(typeof(MappingProfileService));
            return services;
        }
    }
}
