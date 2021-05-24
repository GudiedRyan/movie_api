using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_api.Models;

namespace movie_api.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly MovieContext _context;
		public MovieRepository(MovieContext context)
		{
			_context = context;
		}
		public async Task<Movie> create(Movie movie)
		{
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();

			return movie;
		}

		public async Task delete(int id)
		{
			var movieToDelete = await _context.Movies.FindAsync(id);
			_context.Movies.Remove(movieToDelete);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Movie>> Get()
		{
			return await _context.Movies.ToListAsync();
		}

		public async Task<Movie> read(int id)
		{
			return await _context.Movies.FindAsync(id);
		}

		public async Task update(Movie movie)
		{
			_context.Entry(movie).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
