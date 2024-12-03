using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class AddQuestionsPage : ContentPage
	{

		private int _selectedDifficulty;

		public int SelectedDifficulty
		{
			get => _selectedDifficulty;
			set
			{
				if (_selectedDifficulty != value)
				{
					_selectedDifficulty = value;
					UpdateStarColors();
				}
			}
		}

		public AddQuestionsPage()
		{
			InitializeComponent();
			BindingContext = this;
			SelectedDifficulty = 1;
		}

		private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			SelectedDifficulty = (int)e.NewValue;
		}

		private void UpdateStarColors()
		{
			Star1.TextColor = SelectedDifficulty >= 1 ? Colors.Gold : Colors.Gray;
			Star2.TextColor = SelectedDifficulty >= 2 ? Colors.Gold : Colors.Gray;
			Star3.TextColor = SelectedDifficulty >= 3 ? Colors.Gold : Colors.Gray;
			Star4.TextColor = SelectedDifficulty >= 4 ? Colors.Gold : Colors.Gray;
			Star5.TextColor = SelectedDifficulty >= 5 ? Colors.Gold : Colors.Gray;
		}
		private async void OnVraagOpslaanClicked(object sender, EventArgs e)
		{
			string vraag = VraagEditor.Text;

			if (string.IsNullOrWhiteSpace(vraag))
			{
				await DisplayAlert("Fout", "Voer een geldige vraag in.", "OK");
				return;
			}

			await DisplayAlert("Succes", $"Vraag opgeslagen:\n\n{vraag}", "OK");

			VraagEditor.Text = string.Empty;
		}
	}
}
