using Microsoft.Extensions.Logging;
using TruthOrDrinkApp.Repositories;

namespace TruthOrDrinkApp
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
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("truthordrinksplash.png", "SplashFont");
				});
			builder.Services.AddSingleton<UserRepository>();
#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
