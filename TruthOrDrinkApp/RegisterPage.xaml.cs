using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class RegisterPage : ContentPage
	{
		private readonly Constants _database;

		public RegisterPage()
		{
			InitializeComponent();
			string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "truthordrink.db");
			_database = new Constants(dbPath);
		}

		private async void OnAccountAanmakenClicked(object sender, EventArgs e)
		{
			string username = UsernameEntry.Text?.Trim();
			string email = EmailEntry.Text?.Trim();
			string password = PasswordEntry.Text?.Trim();
			string confirmPassword = ConfirmPasswordEntry.Text?.Trim();
			int age = int.TryParse(AgeEntry.Text, out var parsedAge) ? parsedAge : 0;

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{
				await DisplayAlert("Fout", "Alle velden moeten worden ingevuld.", "OK");
				return;
			}

			if (password != confirmPassword)
			{
				await DisplayAlert("Fout", "Wachtwoorden komen niet overeen.", "OK");
				return;
			}

			if (age < 18)
			{
				await DisplayAlert("Fout", "Je moet minimaal 18 jaar oud zijn.", "OK");
				return;
			}

			if (!TermsCheckBox.IsChecked)
			{
				await DisplayAlert("Fout", "Je moet de algemene voorwaarden accepteren.", "OK");
				return;
			}

			var existingUser = await _database.FindAsync<User>(u => u.Name == username || u.Email == email);
			if (existingUser != null)
			{
				await DisplayAlert("Fout", "Gebruikersnaam of e-mailadres is al geregistreerd.", "OK");
				return;
			}

			string hashedPassword = HashPassword(password);

			var newUser = new User
			{
				Name = username,
				Email = email,
				PasswordHash = hashedPassword,
				Age = age
			};

			await _database.AddAsync(newUser);
			await DisplayAlert("Succes", $"Welkom, {username}! Je kunt nu inloggen.", "OK");
			await Navigation.PopAsync();
		}

		private string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(bytes);
			}
		}
	}
}
