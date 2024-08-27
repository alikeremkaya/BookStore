using Microsoft.AspNetCore.Mvc.Razor;
using HS14_MVCKitapEvi.Infrastructure.Extentions;
using HS14_MVCKitapEvi.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;
using HS14_MVCKitapEvi.Aplication.Extentions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddAplicationServices();
builder.Services.AddInfrastructureServicces(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
