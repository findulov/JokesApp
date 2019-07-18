using JokesApp.DataLayer.Entities;
using JokesApp.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JokesApp.DataLayer
{
    public class DataSeeder
    {
        private readonly JokesDbContext db;

        public DataSeeder(JokesDbContext db)
        {
            this.db = db;
        }

        public void Seed()
        {
            var jokesJson = File.ReadAllText("jokes.json");
            var jokes = JsonConvert.DeserializeObject<IEnumerable<JokeModel>>(jokesJson);
                       
            foreach (var joke in jokes)
            {
                var jokeEntity = db.Jokes.SingleOrDefault(j => j.Text == joke.Joke);

                if (jokeEntity == null)
                {
                    jokeEntity = new Joke
                    {
                        Text = joke.Joke,
                        DateCreated = DateTime.Now
                    };

                    db.Jokes.Add(jokeEntity);
                    db.SaveChanges();
                }
            }
        }
    }
}
