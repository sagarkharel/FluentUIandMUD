using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using MicrosoftFluentUIAspNetCoreTemplates.Services;
using MicrosoftFluentUIAspNetCoreTemplates.Shared.Services;
using MudBlazor.Services;

namespace MicrosoftFluentUIAspNetCoreTemplates
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the MicrosoftFluentUIAspNetCoreTemplates.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFluentUIComponents();
            builder.Services.AddMudServices();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
