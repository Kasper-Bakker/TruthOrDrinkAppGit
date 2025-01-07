namespace TruthOrDrinkApp;
public partial class GameSettingsPage : ContentPage
{
	public string SelectedQuestionType { get; set; }
	public string SelectedDifficulty { get; set; }
	public string SelectedCategory { get; set; }
	public string PhoneChoice { get; set; }
	public string GeneratedCode { get; set; } 

	public GameSettingsPage()
	{
		InitializeComponent();
		BindingContext = this;

		SelectedQuestionType = "Voorgestelde vragen";
		SelectedDifficulty = "1";  
		SelectedCategory = "First Round: Vragen om op een vriendelijke manier kennis te maken";
		PhoneChoice = "Ja";

		Star1Color = Colors.Yellow;
		Star2Color = Colors.Gray;
		Star3Color = Colors.Gray;
		Star4Color = Colors.Gray;
		Star5Color = Colors.Gray;
	}


	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		int value = (int)e.NewValue;

		Star1Color = value >= 1 ? Colors.Yellow : Colors.Gray;
		Star2Color = value >= 2 ? Colors.Yellow : Colors.Gray;
		Star3Color = value >= 3 ? Colors.Yellow : Colors.Gray;
		Star4Color = value >= 4 ? Colors.Yellow : Colors.Gray;
		Star5Color = value >= 5 ? Colors.Yellow : Colors.Gray;

		OnPropertyChanged(nameof(Star1Color));
		OnPropertyChanged(nameof(Star2Color));
		OnPropertyChanged(nameof(Star3Color));
		OnPropertyChanged(nameof(Star4Color));
		OnPropertyChanged(nameof(Star5Color));
	}


	private void OnQuestionTypeChanged(object sender, EventArgs e)
	{
		SelectedQuestionType = QuestionTypePicker.SelectedItem?.ToString() ?? "Voorgestelde vragen";
	}

	private void OnCategoryChanged(object sender, CheckedChangedEventArgs e)
	{
		if (Category1RadioButton.IsChecked)
			SelectedCategory = Category1RadioButton.Content.ToString();
		else if (Category2RadioButton.IsChecked)
			SelectedCategory = Category2RadioButton.Content.ToString();
		else if (Category3RadioButton.IsChecked)
			SelectedCategory = Category3RadioButton.Content.ToString();
		else if (Category4RadioButton.IsChecked)
			SelectedCategory = Category4RadioButton.Content.ToString();
	}

	private void OnPhoneChoiceChanged(object sender, CheckedChangedEventArgs e)
	{
		PhoneChoice = PhoneChoise.IsChecked ? "Ja" : "Nee";
	}

	private async void OnVolgendeClicked(object sender, EventArgs e)
	{

		SelectedQuestionType = QuestionTypePicker.SelectedItem?.ToString() ?? "Voorgestelde vragen"; 
		SelectedDifficulty = DifficultySlider.Value.ToString("0"); 
		PhoneChoice = PhoneChoise.IsChecked ? "Ja" : "Nee";  

		await Navigation.PushAsync(new GameConfirmPage(
			SelectedQuestionType,
			SelectedDifficulty,
			SelectedCategory,
			PhoneChoice,
			GeneratedCode));
	}
	public Color Star1Color { get; set; }
	public Color Star2Color { get; set; }
	public Color Star3Color { get; set; }
	public Color Star4Color { get; set; }
	public Color Star5Color { get; set; }

}
