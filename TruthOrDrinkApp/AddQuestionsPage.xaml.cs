using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using TruthOrDrinkApp.Data;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp
{
	public partial class AddQuestionsPage : ContentPage
	{
		private ObservableCollection<Question> Questions { get; set; }

		public ObservableCollection<string> FilteredQuestions { get; set; }

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
			Questions = new ObservableCollection<Question>();
			FilteredQuestions = new ObservableCollection<string>();

			BindingContext = this;
			SelectedDifficulty = 1;

			LoadQuestions();
		}

		private async void LoadQuestions()
		{
			try
			{
				var dbQuestions = await App.Database.GetAllAsync<Question>();
				Questions.Clear();
				FilteredQuestions.Clear();

				foreach (var question in dbQuestions)
				{
					Questions.Add(question);
					FilteredQuestions.Add(question.QuestionText); 
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het laden van vragen: {ex.Message}", "OK");
			}
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

			var question = new Question
			{
				QuestionText = vraag,
				Difficulty = SelectedDifficulty, 
				CreatedAt = DateTime.Now,
				Category = "General",
				IsPersonalized = false 
			};

			try
			{
				await App.Database.AddAsync(question); 
				Questions.Add(question); 
				FilteredQuestions.Add(question.QuestionText);

				await DisplayAlert("Succes", $"Vraag opgeslagen:\n\n{vraag}", "OK");

				VraagEditor.Text = string.Empty;
			}
			catch (Exception ex)
			{
				await DisplayAlert("Fout", $"Er ging iets mis bij het opslaan van de vraag: {ex.Message}", "OK");
			}
		}

		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = e.NewTextValue?.ToLower() ?? string.Empty;
			FilteredQuestions.Clear();

			foreach (var question in Questions.Where(q => q.QuestionText.ToLower().Contains(searchText)))
			{
				FilteredQuestions.Add(question.QuestionText);
			}
		}

		private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			SelectedDifficulty = (int)e.NewValue;
		}

	}
}
