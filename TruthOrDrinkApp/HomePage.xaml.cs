namespace TruthOrDrinkApp
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private async void OnVragenToevoegenClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new AddQuestionsPage());
		}

		private async void OnStartGameClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new GameSettingsPage());
		}
	}
}
