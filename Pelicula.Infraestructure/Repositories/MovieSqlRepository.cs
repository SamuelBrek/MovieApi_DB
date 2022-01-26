using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelicula.Domain.entities;
using Pelicula.Infraestructure.Data;

namespace Pelicula.Infraestructure.Repositories
{
    public class MovieSqlRepository
    {
        private readonly MoviesBrekContext _moviesctx;

        public MovieSqlRepository(){
            _moviesctx = new MoviesBrekContext();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _moviesctx.Movies;
        }

        public Movie GetById(int id)
        {
            var movies = _moviesctx.Movies.Where(movie => movie.IdMovie == id);
            return movies.FirstOrDefault();
        }

        //public void CreateMovie (Movie newMovie)
        //{
           // _moviesctx.Add(newMovie);
        //}

        public IEnumerable<Movie> GetDirectors(string director)
        {
            var movies = _moviesctx.Movies.Where(movie => movie.DirectorMovie == director);
            return movies;
        }

        public void CreateMovie(Movie newMovie)
        {
            var entity = newMovie;
            _moviesctx.Movies.Add(entity);
            var rows =  _moviesctx.SaveChanges();
            if(rows <= 0)
                throw new Exception("INCORRECTO! No se ha podido registrar la película");

            return;
        }

        public void DeleteMovie (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Falta aún información por completar");
            }
            var result = GetById(id);
            _moviesctx.Remove(result);
            var rows =  _moviesctx.SaveChanges();
            return;
        }

        public void UpdateMovie (int id, Movie updateMovie)
        {
            if (id <= 0 || updateMovie == null)
            {
                throw new ArgumentException("Falta aún información por completar");
            }
            var entity = GetById(id);

            entity.TitleMovie = updateMovie.TitleMovie;
            entity.DirectorMovie = updateMovie.DirectorMovie;
            entity.GenreMovie = updateMovie.GenreMovie;
            entity.PuntMovie = updateMovie.PuntMovie;
            entity.RatingMovie = updateMovie.RatingMovie;
            entity.YpubliMovie = updateMovie.YpubliMovie;
            _moviesctx.Update(entity);
            var rows =  _moviesctx.SaveChanges();
            return;
        }

    }
}