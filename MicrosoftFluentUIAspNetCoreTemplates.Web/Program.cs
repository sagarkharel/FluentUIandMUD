using Microsoft.FluentUI.AspNetCore.Components;
using MicrosoftFluentUIAspNetCoreTemplates.Shared.Services;
using MicrosoftFluentUIAspNetCoreTemplates.Web.Components;
using MicrosoftFluentUIAspNetCoreTemplates.Web.Services;
using MudBlazor.Services;


namespace MicrosoftFluentUIAspNetCoreTemplates
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddFluentUIComponents();
            builder.Services.AddMudServices();

            // Add device-specific services used by the MicrosoftFluentUIAspNetCoreTemplates.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(
                    typeof(MicrosoftFluentUIAspNetCoreTemplates.Shared._Imports).Assembly,
                    typeof(MicrosoftFluentUIAspNetCoreTemplates.Web.Client._Imports).Assembly);

            app.Run();
        }
    }
}
