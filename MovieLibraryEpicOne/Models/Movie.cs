using System.ComponentModel.DataAnnotations;

namespace MovieLibraryEpicOne.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; protected set; }
        [Required]
        public string Name { get; protected set; }
        [Required]
        public double IMDB { get; protected set; }
        [Required]
        public double RottenTomatoes { get; protected set; }
        [Required]
        public string Poster { get; protected set; }
        [Required]
        public Director LeadDirector { get; protected set; }
        [Required]
        public Genre MainGenre { get; protected set; }
        public List<Actor> Actors { get; protected set; }

        public Movie() { }
    }
}
