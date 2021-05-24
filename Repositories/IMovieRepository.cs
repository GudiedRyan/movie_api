using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movie_api.Models;

namespace movie_api.Repositories
{
	public interface IMovieRepository
	{
		Task<IEnumerable<Movie>> Get();
		Task<Movie> read(int id);
		Task<Movie> create(Movie movie);
		Task update(Movie movie);
		Task delete(int id);
	}
}
