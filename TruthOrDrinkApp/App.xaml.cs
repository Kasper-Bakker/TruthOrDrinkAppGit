using TruthOrDrinkApp.Data;

namespace TruthOrDrinkApp;
public partial class App : Application
{
	public static Constants Database { get; set; }

	public App()
	{
		InitializeComponent();
		InitializeDatabase();

		MainPage = new NavigationPage(new LoginPage());
	}

	private async void InitializeDatabase()
	{
		try
		{
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "truthordrink.db");
			Database = new Constants(dbPath);
			await Database.InitializeDatabaseAsync();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Database initialisatie fout: {ex.Message}");
			throw;
		}
	}

}
