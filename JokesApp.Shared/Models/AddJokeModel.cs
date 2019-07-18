using System.ComponentModel.DataAnnotations;

namespace JokesApp.Shared.Models
{
    public class AddJokeModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = "Joke's length is over 1000 characters and will take too long to read, no one will bother")]
        [MinLength(25, ErrorMessage = "Please provide at least 25 characters")]
        public string Joke { get; set; }
    }
}
