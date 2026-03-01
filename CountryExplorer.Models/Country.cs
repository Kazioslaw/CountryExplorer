using System;
using System.Collections.Generic;
using System.Text;

namespace CountryExplorer.Models
{
	public class Country
	{
		public string FullName { get; set; }
		public string CommonName { get; set; }
		public string FlagPath { get; set; }
		public long Population { get; set; }
		public string? Capital { get; set; }
		public string Region { get; set; }
	}
}
