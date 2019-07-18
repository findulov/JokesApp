using JokesApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesApp.Shared.Services
{
    public interface IJokesService
    {
        Task<IEnumerable<JokeModel>> GetAll(string searchQuery = null);

        Task<JokeModel> GetById(int jokeId);

        Task<bool> Add(AddJokeModel joke);
    }
}
