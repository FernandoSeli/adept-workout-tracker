using Microsoft.AspNetCore.Components.WebView.Maui;
//using Adept.Maui.Data;
using MudBlazor.Services;
namespace Adept.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddBlazorWebView();
		//builder.Services.AddSingleton<WeatherForecastService>();

		builder.Services.AddMudServices();
		return builder.Build();
	}
}
