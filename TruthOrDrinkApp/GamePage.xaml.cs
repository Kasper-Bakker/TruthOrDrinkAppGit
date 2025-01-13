using TruthOrDrinkApp.Services;
using TruthOrDrinkApp.Data;  // Voeg de database service toe voor gepersonaliseerde vragen
using TruthOrDrinkApp.MVVM.Models; // Voeg de model voor vragen toe

namespace TruthOrDrinkApp
{
	public partial class GamePage : ContentPage
	{
		private readonly TruthOrDrinkApiService _apiService;
		private readonly Constants _databaseService; // Database service om gepersonaliseerde vragen te laden
		private List<Question> _personalizedQuestions;
		private List<Question> _standardQuestions;
		private List<Question> _currentQuestions;
		private int _currentQuestionIndex;

		public string CurrentQuestion { get; set; }

		// Ontvang de geselecteerde vraagtype via de constructor
		public GamePage(string selectedQuestionType)
		{
			InitializeComponent();
			_apiService = new TruthOrDrinkApiService();

			// Verkrijg het databasepad en maak een instantie van Constants (database)
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "truthordrink.db");
			_databaseService = new Constants(dbPath);

			_personalizedQuestions = new List<Question>();
			_standardQuestions = new List<Question>();
			_currentQuestions = new List<Question>();
			_currentQuestionIndex = 0;

			// Laad de vragen op basis van het geselecteerde vraagtype
			LoadQuestions(selectedQuestionType);
		}

		// Laad zowel standaard- als gepersonaliseerde vragen
		private async void LoadQuestions(string selectedQuestionType)
		{
			try
			{
				// Haal standaardvragen op van de API
				_standardQuestions = await _apiService.GetQuestionsAsync();

				// Haal gepersonaliseerde vragen op uit de database
				var dbQuestions = await _databaseService.GetAllQuestionsAsync();
				_personalizedQuestions = dbQuestions.Where(q => q.IsPersonalized).ToList();

				// Toon de juiste vragen op basis van de keuze
				if (selectedQuestionType == "Standard")
				{
					_currentQuestions = _standardQuestions;
				}
				else if (selectedQuestionType == "Personalized")
				{
					_currentQuestions = _personalizedQuestions;
				}

				DisplayNextQuestion();
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het laden van de vragen: {ex.Message}", "OK");
			}
		}

		// Update de vraag die momenteel wordt weergegeven
		private void DisplayNextQuestion()
		{
			if (_currentQuestions.Count > 0)
			{
				// Toon de huidige vraag
				CurrentQuestion = _currentQuestions[_currentQuestionIndex].QuestionText;
				QuestionLabel.Text = CurrentQuestion;
			}
			else
			{
				QuestionLabel.Text = "Geen vragen beschikbaar!";
			}
		}

		// Wanneer de gebruiker op "Volgende vraag" klikt
		private void OnNextQuestionClicked(object sender, EventArgs e)
		{
			if (_currentQuestions.Count > 0)
			{
				// Update het indexnummer voor de volgende vraag
				_currentQuestionIndex = (_currentQuestionIndex + 1) % _currentQuestions.Count;
				DisplayNextQuestion();
			}
		}

		// Laad de vragen bij het openen van de pagina
		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadQuestions("");  // Zorg ervoor dat je de vragen opnieuw laadt als je terugkomt naar de gamepagina
		}
	}
}
