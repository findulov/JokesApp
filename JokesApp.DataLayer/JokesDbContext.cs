using JokesApp.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.DataLayer
{
    public class JokesDbContext : IdentityDbContext
    {
        public JokesDbContext(DbContextOptions<JokesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; }
    }
}
