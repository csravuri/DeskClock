using CommunityToolkit.Maui;
using DeskClock.Pages;
using DeskClock.ViewModels;
using Microsoft.Extensions.Logging;

namespace DeskClock;

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
			});

		builder.Services.AddSingleton<ClockPage>();
		builder.Services.AddSingleton<ClockViewModel>();

		builder.Services.AddSingleton<StopWatchPage>();
		builder.Services.AddSingleton<StopWatchViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
