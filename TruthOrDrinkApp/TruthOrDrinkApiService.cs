using Newtonsoft.Json;

namespace TruthOrDrinkApp.Services
{
	public class TruthOrDrinkApiService : ApiServiceBase
	{
		protected override string ApiUrl => "https://api.truthordarebot.xyz/v1/truth";

		public async Task<string> GetSingleQuestionAsync()
		{
			const string apiUrl = "https://api.truthordarebot.xyz/v1/truth";

			using (var client = new HttpClient())
			{
				try
				{
					var response = await client.GetAsync(apiUrl);

					if (!response.IsSuccessStatusCode)
					{
						Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
						return null;
					}

					var jsonResponse = await response.Content.ReadAsStringAsync();

					Console.WriteLine($"API Response: {jsonResponse}");

					var questionObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
					string question = questionObject?.question;

					Console.WriteLine($"Vraag opgehaald: {question}");

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
