using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			bool isLoginSuccessful = true; 

			if (isLoginSuccessful)
			{
				await DisplayAlert("Login", "Succesvol ingelogd!", "OK");

				await Navigation.PushAsync(new HomePage());
			}
			else
			{
				await DisplayAlert("Login", "Onjuiste gebruikersnaam of wachtwoord.", "OK");
			}
		}

		private async void OnRegisterClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RegisterPage());
		}
	}
}
