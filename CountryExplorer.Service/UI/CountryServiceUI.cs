using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using CountryExplorer.Models;

namespace CountryExplorer.Service.UI
{
	public class CountryServiceUI
	{
		private HttpClient http;

		public CountryServiceUI(HttpClient http)
		{
			this.http = http;
		}

		public async Task<List<Country>> GetCountryListAsync(int skip, int take)
		{
			var countries = await http.GetFromJsonAsAsyncEnumerable<Country>("/api/Country").Skip(skip).Take(take).ToListAsync();

			return countries;
		}

		public async Task<CountryDetails> GetCountryDetailsAsync(string name)
		{
			var country = await http.GetFromJsonAsync<CountryDetails>($"/api/Country/{name}");

			return country;
		}
	}
}
