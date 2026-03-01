using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CountryExplorer.Models
{
	public class Country
	{
		public Name Name { get; set; }
		public Flag Flags { get; set; }
		public long Population { get; set; }
		public List<string>? Capital { get; set; }
		public string Region { get; set; }
	}
}
