using Challenge.Valkimia.Application.Extensions;
using Challenge.Valkimia.Infrastructure.Resources;
using Challenge.Valkimia.Presentation.Resources.Interfaces;
using Challenge.Valkimia.Presentation.Resources.Services;
using Challenge.Valkimia.Presentation.Web.Extensions;
using MassTransit;
using Serilog;
using System.Reflection;


Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                .AddEnvironmentVariables()
                .Build()).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();

//LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.AddScoped<IAuthorizationStateProvider, AuthorizationStateProvider>();

//MVC
var mvcBuilder = builder.Services.AddMvc(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
mvcBuilder.AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);
mvcBuilder.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
        return factory.Create("SharedResources", assemblyName.Name);
    };
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
