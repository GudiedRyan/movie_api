using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movie_api.Models;
using movie_api.Repositories;

namespace movie_api.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IMovieRepository _movieRepository;
		public MoviesController(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		[HttpGet("/api/movies")]
		public async Task<IEnumerable<Movie>> GetMovies()
		{
			return await _movieRepository.Get();
		}

		[HttpGet("/api/movies/{id}")]
		public async Task<ActionResult<Movie>> read(int id)
		{
			return await _movieRepository.read(id);
		}

		[HttpPost("/api/movies")]
		public async Task<ActionResult<Movie>> create([FromBody] Movie movie)
		{
			var newMovie = await _movieRepository.create(movie);
			return CreatedAtAction(nameof(GetMovies), new { id = newMovie.Id }, newMovie);
		}
		[HttpPut("/api/movies/{id}")]
		public async Task<ActionResult> update(int id, [FromBody] Movie movie)
		{
			if (id != movie.Id)
			{
				return BadRequest();
			}

			await _movieRepository.update(movie);

			return Ok();
		}
		[HttpDelete("/api/movies/{id}")]
		public async Task<ActionResult> delete(int id)
		{
			var movieToDelete = await _movieRepository.read(id);
			if (movieToDelete == null)
				return NotFound();

			await _movieRepository.delete(movieToDelete.Id);
			return Ok();
		}

	}
}
