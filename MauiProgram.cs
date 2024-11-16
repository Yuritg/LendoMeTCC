using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Lendo_me
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

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources/Languages");
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<BoardService>();
            builder.Services.AddSingleton<MainViewModel>();

            CultureInfo defaultCulture = CultureInfo.CurrentCulture;
            string[] supportedCultures = new[] { "pt", "es", "en" };
            CultureInfo selectedCulture = supportedCultures.Contains(defaultCulture.TwoLetterISOLanguageName) ? defaultCulture : new CultureInfo("en"); // Fallback para inglês

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
