using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Context
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration )
        {
            string connectionstring = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(opt => { opt.UseSqlServer(connectionstring); }) ;
            services.AddIdentityCore<AppUser>(cfr => //alt satır devamı 
            { cfr.Password.RequireNonAlphanumeric = false; }).AddEntityFrameworkStores<ApplicationDbContext>() ;
            services.AddScoped<IUnitOfWork>(sv=>sv.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            return services;
        }
    }
}
