using Microsoft.Maui.Controls;
using TruthOrDrinkApp.Data;
using System.IO;

namespace TruthOrDrinkApp
{
	public partial class App : Application
	{
		public static Constants Database { get; set; }
		public App()
		{
			InitializeComponent();
			InitializeDatabase();
			MainPage = new NavigationPage(new HomePage());
		}

		private void InitializeDatabase()
		{
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db");
			Database = new Constants(dbPath);
		}

	}
}