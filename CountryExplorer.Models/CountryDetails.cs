namespace CountryExplorer.Models
{
	public class CountryDetails
	{
		public Name Name { get; set; }
		public Flag Flags { get; set; }
		public long Population { get; set; }
		public string Region { get; set; }
		public string Subregion { get; set; }
		public List<string>? Capital { get; set; }
		public Dictionary<string, Dictionary<string, string>> Currencies { get; set; }
		public Dictionary<string, string> Languages { get; set; }
	}
}
