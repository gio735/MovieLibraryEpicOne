using System.ComponentModel.DataAnnotations;

namespace MovieLibraryEpicOne.Models
{
    public class Director
    {
        [Key]
        public int Id { get; protected set; }
        [Required]
        public string Name { get; protected set; }
        [Required]
        public string Lastname {  get; protected set; }
        [Required]
        public DateTime BirthDate { get; protected set; }
        [Required]
        public double Rating { get;protected set; }
        public string Portrait { get; protected set; }
        public List<Movie> Movies { get; protected set; }

        public Director(){}
    }
}
