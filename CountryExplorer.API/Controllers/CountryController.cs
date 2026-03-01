using CountryExplorer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryExplorer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private CountryService service;

		public CountryController(CountryService service)
		{
			this.service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetCountryListAsync()
		{
			var countryList = await service.GetCountryListAsync();

			if (countryList is null)
			{
				return NotFound();
			}

			return Ok(countryList);
		}

		[HttpGet("{name}")]
		public async Task<IActionResult> GetCountryDetailsAsync(string name)
		{
			var country = await service.GetCountryDetailsAsync(name);

			if (country is null)
			{
				return NotFound("Country name was not found");
			}

			return Ok(country);
		}
	}
}
