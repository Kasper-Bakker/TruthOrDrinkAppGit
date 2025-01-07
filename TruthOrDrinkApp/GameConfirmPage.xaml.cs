namespace TruthOrDrinkApp;

public partial class GameConfirmPage : ContentPage
{
	public GameConfirmPage(string questionType, string difficulty, string category, string phoneChoice, string generatedCode)
	{
		InitializeComponent();
		BindingContext = this;

		// Zet de labels met de ontvangen waarden
		QuestionTypeLabel.Text = $"Soort vragen: {questionType}";
		DifficultyLabel.Text = $"Moeilijkheidsgraad: {difficulty}";
		CategoryLabel.Text = $"Categorie: {category}";
		PhoneChoiceLabel.Text = $"Spelen op telefoons van alle spelers: {phoneChoice}";
		RandomCodeLabel.Text = $"Code: {generatedCode}";
	}

	private async void OnStartGameClicked(object sender, EventArgs e)
	{
		await DisplayAlert("Game starten", "Het spel wordt gestart!", "OK");
		// Navigatie naar de spelpagina
		// await Navigation.PushAsync(new GamePage());
	}

	private async void OnInviteFriendsClicked(object sender, EventArgs e)
	{
		await DisplayAlert("Vrienden uitnodigen", "Deel de QR-code of de code met je vrienden!", "OK");
	}

	private async void OnGenerateCodeClicked(object sender, EventArgs e)
	{
		// Genereer een nieuwe code
		string randomCode = GenerateRandomCode();
		RandomCodeLabel.Text = $"Code: {randomCode}";
	}

	private string GenerateRandomCode()
	{
		Random random = new Random();
		int part1 = random.Next(100, 1000);
		int part2 = random.Next(100, 1000);
		return $"C-{part1}-{part2}";
	}
}
