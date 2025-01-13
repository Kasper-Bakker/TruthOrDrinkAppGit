using SQLiteBrowser;

namespace TruthOrDrinkApp
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}
		private async void OpenDatabaseBrowser(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DatabaseBrowserPage(Path.Combine(FileSystem.AppDataDirectory, "TruthOrDrink.db")));
		}

		private async void OnVragenToevoegenClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new AddQuestionsPage());
		}

		private async void OnVriendenClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new FriendlistPage());
		}

		private async void OnStartGameClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new GameSettingsPage());
		}
	}
}
