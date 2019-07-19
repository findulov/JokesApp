using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesApp.Shared.Models;
using JokesApp.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokesService jokesService;

        public JokesController(IJokesService jokesService)
        {
            this.jokesService = jokesService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll(string searchQuery = null)
        {
            var jokes = await jokesService.GetAll(searchQuery);

            return Ok(jokes);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var joke = await jokesService.GetById(id);

            return Ok(joke);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddJokeModel model)
        {
            bool success = false;

            if (!ModelState.IsValid)
            {
                return Ok(success);
            }

            success = await jokesService.Add(model);

            return Ok(success);
        }
    }
}
