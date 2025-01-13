using TruthOrDrinkApp.Services;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class GamePage : ContentPage
	{
		private readonly TruthOrDrinkApiService _apiService; 
		private string _currentQuestion; 

		public string CurrentQuestion
		{
			get => _currentQuestion;
			set
			{
				_currentQuestion = value;
				OnPropertyChanged(); 
			}
		}

		public GamePage(string selectedQuestionType)
		{
			InitializeComponent();
			_apiService = new TruthOrDrinkApiService(); 
			LoadNextQuestion(); 
		}

		public GamePage()
		{
		}

		private async void LoadNextQuestion()
		{
			try
			{
				var question = await _apiService.GetSingleQuestionAsync();

				if (!string.IsNullOrEmpty(question))
				{
					CurrentQuestion = question;
					QuestionLabel.Text = CurrentQuestion;
				}
				else
				{
					QuestionLabel.Text = "Er zijn geen vragen beschikbaar.";
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het ophalen van de vraag: {ex.Message}", "OK");
			}
		}

		private void OnNextQuestionClicked(object sender, EventArgs e)
		{
			LoadNextQuestion(); 
		}
	}
}
