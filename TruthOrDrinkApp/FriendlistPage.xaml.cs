using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class FriendlistPage : ContentPage
	{
		private ObservableCollection<Friend> Friends { get; set; }
		public ObservableCollection<string> FilteredFriends { get; set; } 

		public FriendlistPage()
		{
			InitializeComponent();

			Friends = new ObservableCollection<Friend>();
			FilteredFriends = new ObservableCollection<string>();

			BindingContext = this;

			LoadFriends();
		}

		private async void LoadFriends()
		{
			try
			{
				var dbFriends = await App.Database.GetAllAsync<Friend>();
				Friends.Clear();
				FilteredFriends.Clear();

				foreach (var friend in dbFriends)
				{
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

		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = e.NewTextValue?.ToLower() ?? string.Empty;
			FilteredFriends.Clear();

			foreach (var friend in Friends.Where(f => f.FriendName.ToLower().Contains(searchText)))
			{
				FilteredFriends.Add(friend.FriendName);
			}
		}

		private async void OnAddFriendClicked(object sender, EventArgs e)
		{
			try
			{
				string friendName = await DisplayPromptAsync("Voeg vriend toe", "Voer naam van vriend in:");

				if (!string.IsNullOrWhiteSpace(friendName))
				{
					var newFriend = new Friend
					{
						UserId = 1, 
						FriendName = friendName.Trim(),
						CreatedAt = DateTime.Now
					};

					await App.Database.AddAsync(newFriend);

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
