using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class FriendlistPage : ContentPage
	{
		// Lijsten voor vrienden
		private ObservableCollection<Friend> Friends { get; set; }
		public ObservableCollection<string> FilteredFriends { get; set; } // Alleen namen van vrienden

		public FriendlistPage()
		{
			InitializeComponent();

			// Initialiseer de lijsten
			Friends = new ObservableCollection<Friend>();
			FilteredFriends = new ObservableCollection<string>();

			// Stel de BindingContext in
			BindingContext = this;

			// Laad vrienden uit de database
			LoadFriends();
		}

		// Vrienden laden uit de database
		private async void LoadFriends()
		{
			try
			{
				var dbFriends = await App.Database.GetAllAsync<Friend>();
				Friends.Clear();
				FilteredFriends.Clear();

				foreach (var friend in dbFriends)
				{
					// Controleer op null-waarden en gebruik een standaardwaarde indien nodig
					friend.FriendName = friend.FriendName ?? "Onbekende Vriend";
					Friends.Add(friend);
					FilteredFriends.Add(friend.FriendName);
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het laden van vrienden: {ex.Message}", "OK");
			}
		}

		// Zoekfunctie
		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = e.NewTextValue?.ToLower() ?? string.Empty;
			FilteredFriends.Clear();

			foreach (var friend in Friends.Where(f => f.FriendName.ToLower().Contains(searchText)))
			{
				FilteredFriends.Add(friend.FriendName); // Alleen namen weergeven
			}
		}

		// Vriend toevoegen
		private async void OnAddFriendClicked(object sender, EventArgs e)
		{
			try
			{
				// Open een prompt om een nieuwe vriend toe te voegen
				string friendName = await DisplayPromptAsync("Voeg vriend toe", "Voer naam van vriend in:");

				if (!string.IsNullOrWhiteSpace(friendName))
				{
					// Maak een nieuwe vriend aan
					var newFriend = new Friend
					{
						UserId = 1, // Dit moet de ingelogde gebruiker-ID zijn
						FriendName = friendName.Trim(),
						CreatedAt = DateTime.Now
					};

					// Voeg de vriend toe aan de database
					await App.Database.AddAsync(newFriend);

					// Update de ObservableCollections
					Friends.Add(newFriend);
					FilteredFriends.Add(newFriend.FriendName);
				}
				else
				{
					await DisplayAlert("Fout", "De naam van de vriend mag niet leeg zijn.", "OK");
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het toevoegen van de vriend: {ex.Message}", "OK");
			}
		}
	}
}
