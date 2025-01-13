using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class LoginPage : ContentPage
	{
		private readonly Constants _database;

		public LoginPage()
		{
			InitializeComponent();
			string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "truthordrink.db");
			_database = new Constants(dbPath);
		}

		// In LoginPage
		private async void OnLoginClicked(object sender, EventArgs e)
		{
			string username = UsernameEntry.Text?.Trim();
			string password = PasswordEntry.Text?.Trim();

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				await DisplayAlert("Fout", "Gebruikersnaam en wachtwoord zijn verplicht.", "OK");
				return;
			}

			var user = await App.Database.FindAsync<User>(u => u.Name == username);

			if (user != null && VerifyPassword(password, user.PasswordHash))
			{
				await DisplayAlert("Succes", $"Welkom terug, {user.Name}!", "OK");

				Application.Current.MainPage = new NavigationPage(new HomePage());  
			}
			else
			{
				await DisplayAlert("Fout", "Gebruiker niet gevonden of wachtwoord onjuist.", "OK");
			}
		}

		private bool VerifyPassword(string password, string storedHash)
		{
			string hashedPassword = HashPassword(password);
			return hashedPassword == storedHash;
		}

		private string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(bytes);
			}
		}

		private async void OnRegisterClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RegisterPage());
		}
	}
}
