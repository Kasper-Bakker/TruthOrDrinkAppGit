using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace TruthOrDrinkApp
{
	public partial class FriendlistPage : ContentPage
	{
		// Lijsten voor vrienden
		private ObservableCollection<string> Friends { get; set; }
		public ObservableCollection<string> FilteredFriends { get; set; }

		public FriendlistPage()
		{
			InitializeComponent();

			// Voorbeeldvrienden
			Friends = new ObservableCollection<string>
			{
				"Alice" ,
				"Bob",
				"Charlie",
				"David",
				"Eve"
			};

			// Gefilterde vriendenlijst
			FilteredFriends = new ObservableCollection<string>(Friends);

			// Koppel aan de BindingContext
			BindingContext = this;
		}

		// Zoekfunctie
		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = e.NewTextValue.ToLower();
			FilteredFriends.Clear();

			foreach (var friend in Friends.Where(f => f.ToLower().Contains(searchText)))
			{
				FilteredFriends.Add(friend);
			}
		}

		// Vriend toevoegen
		private async void OnAddFriendClicked(object sender, EventArgs e)
		{
			// Open een prompt om een nieuwe vriend toe te voegen
			string result = await DisplayPromptAsync("Voeg vriend toe", "Voer naam van vriend in:");

			if (!string.IsNullOrWhiteSpace(result))
			{
				Friends.Add(result);
				FilteredFriends.Add(result);
			}
		}
	}
}
