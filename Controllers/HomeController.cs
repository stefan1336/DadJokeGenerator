using DadJokeGenerator.Api;
using DadJokeGenerator.Models;
using DadJokeGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DadJokeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJokeRepo jokeRepo;

        public HomeController(IJokeRepo jokeRepo)
        {
            this.jokeRepo=jokeRepo;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> NewJoke()
        {
            // hämta ett dad joke
            DadJokeModel? newDadJoke = await new ApiCaller().MakeCall("");

            // spara dad joket i en databas
            jokeRepo.AddJoke(newDadJoke);
            
            return View(newDadJoke);
        }

        public async Task<IActionResult> AllJokes()
        {
            // hämta alla skämt från databasen
            List<DadJokeModel> jokes = jokeRepo.GetJokes();
            return View(jokes);
        }


    }
}