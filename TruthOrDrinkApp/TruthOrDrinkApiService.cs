using Newtonsoft.Json;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp.Services
{
	public class TruthOrDrinkApiService : ApiServiceBase
	{
		protected override string ApiUrl => "https://api.truthordarebot.xyz/v1/truth";

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

					var questionObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
					string question = questionObject?.question;

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
