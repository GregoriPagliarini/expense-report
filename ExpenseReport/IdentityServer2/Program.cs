
using IdentityServer2.Config;
using IdentityServer2.Model;
using IdentityServer2.Model.Context;
using IdentityServer2.Initializer;
using Duende.IdentityServer2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
            connection,
            new MySqlServerVersion(new Version(8, 0, 29)))
        );

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<MySQLContext>()
            .AddDefaultTokenProviders();

        var builderServices = builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        }).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
            .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
            .AddInMemoryClients(IdentityConfiguration.Clients)
            .AddAspNetIdentity<ApplicationUser>();

        builder.Services.AddScoped<IDBInitializer, DBInitializer>();
        //builder.Services.AddScoped<IProfileService, ProfileService>();

        builderServices.AddDeveloperSigningCredential();

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        var app = builder.Build();

        var dbInitializerService = app.Services.CreateScope().ServiceProvider.GetService<IDBInitializer>();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();

        dbInitializerService.Initialize();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}