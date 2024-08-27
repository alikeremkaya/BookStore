namespace HS14_MVCKitapEvi.Aplication.Extentions;
public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProfileUserService, ProfileUserService>();
        services.AddScoped<IAdminService, AdminService>();

        return services;

    }
}
