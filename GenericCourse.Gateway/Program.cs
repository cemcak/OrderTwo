using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false;
});

builder.Configuration
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();



builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot().Wait();
app.MapGet("/", () => "Hello World!");

app.Run();
