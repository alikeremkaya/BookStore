using HS14_MVCKitapEvi.Infrastructure.AppContext;
using HS14_MVCKitapEvi.Infrastructure.Repositories;
using HS14_MVCKitapEvi.Infrastructure.Repositories.AdminRepositories;
using HS14_MVCKitapEvi.Infrastructure.Repositories.ProfileUserRepositories;
using HS14_MVCKitapEvi.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS14_MVCKitapEvi.Infrastructure.Extentions;

public static  class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServicces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
                    options.UseLazyLoadingProxies();
                    options.UseSqlServer(configuration.GetConnectionString(AppDbContext.DevConnectionString));
        });

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IProfileUserRepository, ProfileUserRepository>();
        

        AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();




        return services;



    }
}
