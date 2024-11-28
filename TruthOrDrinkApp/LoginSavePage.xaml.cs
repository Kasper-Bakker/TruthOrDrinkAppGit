using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class LoginSavePage : ContentPage
	{
		public LoginSavePage()
		{
			InitializeComponent();
		}

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			bool isSaveChecked = SaveYes.IsChecked;

			if (isSaveChecked)
			{
				await DisplayAlert("Inloggegevens", "Uw inloggegevens zijn opgeslagen.", "OK");
			}
			else
			{
				await DisplayAlert("Inloggegevens", "Uw inloggegevens zijn niet opgeslagen.", "OK");
			}

		}
	}
}
