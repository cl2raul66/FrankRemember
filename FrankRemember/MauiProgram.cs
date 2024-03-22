using CommunityToolkit.Maui;
using FrankRemember.Services;
using FrankRemember.ViewModels;
using FrankRemember.Views;
using Microsoft.Extensions.Logging;

namespace FrankRemember;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("icofont.ttf", "icofont");
            });

        builder.Services.AddSingleton<ITripService, TripService>();

        builder.Services.AddTransient<MainPage, MainPageViewModel>();
        builder.Services.AddTransient<PgLogHistory, PgLogHistoryViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
