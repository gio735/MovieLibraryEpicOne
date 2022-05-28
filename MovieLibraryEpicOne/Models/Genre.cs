using MovieLibraryEpicOne.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieLibraryEpicOne.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; protected set; }
        [Required]
        public string Name { get; protected set; }
        public Genre() { }

        public static List<string> GetGenres()
        {
            List<string> result = new();
            using( var context = new DataContext())
            {
                var genres = context.Genres.ToList();
                foreach(var genre in genres)
                {
                    if (!result.Contains(genre.Name))
                    {
                        result.Add(genre.Name);
                    }
                }
            }
            return result;
        }
    }
}
