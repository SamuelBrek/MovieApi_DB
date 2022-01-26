using System;
using System.Collections.Generic;

#nullable disable

namespace Pelicula.Domain.entities
{
    public partial class Movie
    {
        public int IdMovie { get; set; }
        public string TitleMovie { get; set; }
        public string DirectorMovie { get; set; }
        public string GenreMovie { get; set; }
        public int? PuntMovie { get; set; }
        public int? RatingMovie { get; set; }
        public string YpubliMovie { get; set; }
    }
}
