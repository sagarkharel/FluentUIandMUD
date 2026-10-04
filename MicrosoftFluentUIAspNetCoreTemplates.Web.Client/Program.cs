using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MicrosoftFluentUIAspNetCoreTemplates.Shared.Services;
using MicrosoftFluentUIAspNetCoreTemplates.Web.Client.Services;

using Microsoft.FluentUI.AspNetCore.Components;

using MudBlazor.Services;


namespace MicrosoftFluentUIAspNetCoreTemplates.Web.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddFluentUIComponents();
            builder.Services.AddMudServices();
            // Add device-specific services used by the MicrosoftFluentUIAspNetCoreTemplates.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            await builder.Build().RunAsync();
        }
    }
}
