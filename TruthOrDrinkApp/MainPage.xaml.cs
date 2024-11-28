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
			await DisplayAlert("Login", "Succesvol ingelogd!", "OK");
		}

		private async void OnRegisterClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RegisterPage());
		}
	}
}
