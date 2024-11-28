using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
		}

		private async void OnAccountAanmakenClicked(object sender, EventArgs e)
		{
			if (!AgeCheckBox.IsChecked || !TermsCheckBox.IsChecked)
			{
				await DisplayAlert("Fout", "U moet de leeftijd bevestigen en de voorwaarden accepteren.", "OK");
				return;
			}

			await Navigation.PushAsync(new LoginSavePage());
		}
	}
}
