﻿using Microsoft.AspNetCore.Components.WebView.Maui;
//using Adept.Maui.Data;

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

		return builder.Build();
	}
}