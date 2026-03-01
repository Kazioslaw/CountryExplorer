namespace CountryExplorer.Models
{
	public class CountryDetails
	{
		public string FullName { get; set; }
		public string CommonName { get; set; }
		public string FlagPath { get; set; }
		public long Population { get; set; }
		public string Region { get; set; }
		public string Subregion { get; set; }
		public string? Capital { get; set; }
		public List<string> Currencies { get; set; }
		public List<string> Languages { get; set; }
	}
}
