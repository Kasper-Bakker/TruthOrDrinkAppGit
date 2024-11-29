using Microsoft.Maui.Controls;

namespace TruthOrDrinkApp
{
	public partial class AddQuestionsPage : ContentPage
	{
		public AddQuestionsPage()
		{
			InitializeComponent();
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
