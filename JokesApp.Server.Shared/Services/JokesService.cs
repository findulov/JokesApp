using JokesApp.DataLayer;
using JokesApp.DataLayer.Entities;
using JokesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesApp.Shared.Services
{
    public class JokesService : IJokesService
    {
        private readonly JokesDbContext db;

        public JokesService(JokesDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<JokeModel>> GetAll(string searchQuery = null)
        {
            IQueryable<Joke> jokesQuery = db.Jokes;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                jokesQuery = jokesQuery
                    .Where(j => j.Text.Contains(searchQuery));
            }

            return await jokesQuery
                .OrderByDescending(j => j.DateCreated)
                .Select(j => new JokeModel
                {
                    Id = j.Id,
                    Joke = j.Text
                }).ToListAsync();
        }

        public async Task<bool> Add(AddJokeModel joke)
        {
            db.Jokes.Add(new Joke
            {
                Text = joke.Joke,
                DateCreated = DateTime.Now
            });

            return await db.SaveChangesAsync() > 0;
        }

        public async Task<JokeModel> GetById(int jokeId)
        {
            return await db.Jokes
               .Where(j => j.Id == jokeId)
               .Select(j => new JokeModel
               {
                   Id = j.Id,
                   Joke = j.Text
               }).SingleOrDefaultAsync();
        }
    }
}
