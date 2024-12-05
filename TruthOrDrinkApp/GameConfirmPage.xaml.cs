using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class GameConfirmPage : ContentPage
	{
		public string SelectedQuestionType { get; set; }
		public string SelectedDifficulty { get; set; }
		public string SelectedCategory { get; set; }
		public string PhoneChoice { get; set; }
		public string GeneratedCode { get; set; }

		public GameConfirmPage()
		{
			InitializeComponent();
			BindingContext = this;

			SelectedQuestionType = "Voorgestelde vragen";
			SelectedDifficulty = "Makkelijk";
			SelectedCategory = "First Round: Vragen om op een vriendelijke manier kennis te maken";
			PhoneChoice = "Ja";
			GeneratedCode = "ABCD1234"; 
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

		private async void OnInviteFriendsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new InviteFriendsPage());
		}
		private async void OnStartGameClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GamePage());
		}
	}
}
