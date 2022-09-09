var builder = WebApplication.CreateBuilder(args);


var builderServices = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryClients(IdentityConfiguration.Clients)
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources);


var app = builder.Build();

app.UseIdentityServer();

app.MapGet("/", () => "Hello world!");

 app.Run();
