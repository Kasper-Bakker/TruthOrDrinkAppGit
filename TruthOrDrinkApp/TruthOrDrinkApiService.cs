using Newtonsoft.Json;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp.Services
{
	public class TruthOrDrinkApiService : ApiServiceBase
	{
		// Gebruik de API URL voor één vraag
		protected override string ApiUrl => "https://api.truthordarebot.xyz/v1/truth";

		// Haal een enkele vraag op
		public async Task<string> GetSingleQuestionAsync()
		{
			using (var client = new HttpClient())
			{
				try
				{ 
					var response = await client.GetAsync(ApiUrl);

					if (!response.IsSuccessStatusCode)
					{
						Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
						return null;
					}

					var jsonResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"API Response: {jsonResponse}");

					// Deserialiseer de JSON-respons om de vraag op te halen
					var questionObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
					string question = questionObject?.question;

					// Als er een vraag is, geef deze terug
					return question;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error fetching question: {ex.Message}");
					return null;
				}
			}
		}
	}
}
