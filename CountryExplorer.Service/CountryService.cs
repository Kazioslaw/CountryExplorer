using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using CountryExplorer.Models;

namespace CountryExplorer.Service
{
	public class CountryService
	{
		private readonly HttpClient http;
		private readonly JsonSerializerOptions options;
		public CountryService(HttpClient http)
		{
			this.http = http;
			this.options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
		}

		public async Task<List<Country>?> GetCountryListAsync()
		{
			var countryList = new List<Country>();
			var response = await http.GetAsync("/v3.1/all?fields=name,flags,population,capital,region");

			if (response.StatusCode != HttpStatusCode.OK)
			{
				return null;
			}

			var jsonStream = await response.Content.ReadAsStreamAsync();

			if (jsonStream is null)
			{
				return null;
			}

			countryList = await JsonSerializer.DeserializeAsyncEnumerable<Country>(jsonStream, options).ToListAsync();

			return countryList;
		}

		public async Task<CountryDetails> GetCountryDetailsAsync(string countryName)
		{
			var response = await http.GetAsync($"/v3.1/name/{countryName.ToLowerInvariant()}?fields=name,flags,population,region,subregion,capital,currencies,languages");

			if (response.StatusCode != HttpStatusCode.OK)
			{
				return null;
			}

			var jsonStream = await response.Content.ReadAsStreamAsync();

			if (jsonStream is null)
			{
				return null;
			}

			var temp = await JsonSerializer.DeserializeAsyncEnumerable<CountryDetails>(jsonStream, options).ToListAsync();

			var country = temp.FirstOrDefault();

			return country;
		}
	}

	//public class CapitalConverter : JsonConverter<string?>
	//{
	//	public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	//	{
	//		if (reader.TokenType == JsonTokenType.StartArray)
	//		{
	//			using var doc = JsonDocument.ParseValue(ref reader);
	//			var array = doc.RootElement;
	//			if (array.GetArrayLength() > 0)
	//				return array[0].GetString();
	//		}
	//		return "";
	//	}

	//	public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
	//	{
	//		writer.WriteStartArray();
	//		if (value != null)
	//			writer.WriteStringValue(value);
	//		writer.WriteEndArray();
	//	}
	//}
}
