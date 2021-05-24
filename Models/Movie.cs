using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_api.Models
{
	public class Movie
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int ReleaseYear { get; set; }
	}
}
