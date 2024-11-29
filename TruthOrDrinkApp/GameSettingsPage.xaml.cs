using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class GameSettingsPage : ContentPage
	{
		public GameSettingsPage()
		{
			InitializeComponent();
		}

		private async void OnVolgendeClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Instellingen", "Instellingen opgeslagen.", "OK");
		}
	}
}
