using Majorsoft.Blazor.Components.Common.JsInterop;
using MeirellescPortfolio;
using MeirellescPortfolio.Localization;
using MeirellescPortfolio.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;
using MudBlazor.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        ConfigureServices(builder);

        var host = builder.Build();

        // Resolve the service and call the method
        var localizationService = host.Services.GetRequiredService<IStringLocalizer<Resource>>();
        var projectService = host.Services.GetRequiredService<IProjectService>();
        await projectService.LoadSetupData(localizationService);

        await host.RunAsync();
    }

    private static void ConfigureServices(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddMudServices();

        builder.Services.AddJsInteropExtensions();

        builder.Services.AddLocalization();

        builder.Services.AddSingleton<IProjectService, ProjectService>();

        builder.Services.AddVideoPlayerServices();
    }
}