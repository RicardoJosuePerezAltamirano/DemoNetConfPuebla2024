using MauiAppNet9Demo.Services;
using MauiAppNet9Demo.Shared.Abstractions;
using Microsoft.Extensions.Logging;

namespace MauiAppNet9Demo
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

            // Add device-specific services used by the MauiAppNet9Demo.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IPhotoServices, MAUIPhotoServices>();
            builder.Services.AddSingleton<ILocationServices, LocationServices>();
            builder.Services.AddSingleton<LocationServices>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
