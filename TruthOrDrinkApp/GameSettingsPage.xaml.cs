using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class GameSettingsPage : ContentPage
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
		
		public GameSettingsPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		private void OnQuestionTypeChanged(object sender, EventArgs e)
		{
			var selectedQuestionType = QuestionTypePicker.SelectedItem?.ToString();

			if (!string.IsNullOrEmpty(selectedQuestionType))
			{
				Console.WriteLine($"Geselecteerde soort vraag: {selectedQuestionType}");
			}
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
		private void OnCategoryChanged(object sender, CheckedChangedEventArgs e) { }
		private void OnPhoneChoiseChanged(object sender, CheckedChangedEventArgs e) { }
		private async void OnVolgendeClicked(object sender, EventArgs e)


		{
			await DisplayAlert("Instellingen","Instellingen opgeslagen.", "OK");
		}

		private string GenerateRandomCode()
		{
			Random random = new Random();
			int part1 = random.Next(100, 1000);
			int part2 = random.Next(100, 1000);
			return $"C-{part1}-{part2}";
		}

		private async void OnGenerateCodeClicked(object sender, EventArgs e)
		{
			string randomCode = GenerateRandomCode();
			RandomCodeLabel.Text = randomCode;
		}


	}
}

	

