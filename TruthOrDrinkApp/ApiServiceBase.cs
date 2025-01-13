using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TruthOrDrinkApp.Services
{
	public abstract class ApiServiceBase
	{
		protected abstract string ApiUrl { get; }

		public async Task<List<string>> GetDataAsync()
		{
			using (var client = new HttpClient())
			{
				try
				{
					var response = await client.GetAsync(ApiUrl);

					if (!response.IsSuccessStatusCode)
					{
						Console.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
						return new List<string>();
					}

					var jsonResponse = await response.Content.ReadAsStringAsync();
					var data = JsonConvert.DeserializeObject<List<string>>(jsonResponse);

					if (data == null || data.Count == 0)
					{
						Console.WriteLine("API returned no data.");
						return new List<string>();
					}

					return data;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error fetching data: {ex.Message}");
					return new List<string>();
				}
			}
		}
	}
}