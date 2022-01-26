using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelicula.Infraestructure.Repositories;
using Pelicula.Domain.entities;
using Microsoft.AspNetCore.Http;

namespace Pelicula.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllMovies()
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            return Ok(movies.GetAllMovies());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById (int id)
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            var movie = movies.GetById(id);
            if (movie == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            return Ok (movie);
        }
        
        [HttpGet]
        [Route("Directores/{director}")]
        public IActionResult GetGetDirectors (string director)
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            var movie = movies.GetDirectors(director);
            if (movie.Count() == 0)
            {
                return NotFound($"El director {director}, no existe o no tiene créditos en ningúna película registrada .");
            }
            return Ok (movie);
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateMovie (Movie newMovie)
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            try
            {
                movies.CreateMovie(newMovie);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "No es posible realizar el registro, no cambies el valor del id o déjalo en 0.");
            }
            return Ok("Se ha agregado la pelicula");
        }
        
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateMovie (int id, Movie updateMovie)
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            var validation = movies.GetById(id);
            if (validation == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            movies.UpdateMovie(id, updateMovie);
            return Ok("Se ha actualizado la película");
        }
        
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteMovie (int id)
        {
            MovieSqlRepository movies = new MovieSqlRepository();
            var validation = movies.GetById(id);
            if (validation == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            movies.DeleteMovie(id);
            return Ok($"Se ha eliminado la película con el id {id}");
        }
    }
}