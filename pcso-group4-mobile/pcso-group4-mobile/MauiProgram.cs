using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Markup;
using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using pcso_group4_mobile.View;
using pcso_group4_mobile.ViewModel;

namespace pcso_group4_mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiCommunityToolkitCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });



        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<HomePage>();

        builder.Services.AddSingleton<CombinationsViewModel>();
        builder.Services.AddSingleton<CombinationsPage>();

        builder.Services.AddSingleton<LuckyPickViewModel>();
        builder.Services.AddSingleton<LuckyPickPage>();

        builder.Services.AddSingleton<ServiceClient>();

        builder.Services.AddSingleton<GameModel>();
        builder.Services.AddSingleton<CombinationModel>();


        return builder.Build();
    }
}