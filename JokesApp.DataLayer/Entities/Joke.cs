using System;

namespace JokesApp.DataLayer.Entities
{
    public class Joke
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
