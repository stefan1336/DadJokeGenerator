using DadJokeGenerator.Data;
using DadJokeGenerator.Models;

namespace DadJokeGenerator.Services
{
    public class JokeRepoDeluxe : IJokeRepo
    {
        private readonly AppDbContext context;

        public JokeRepoDeluxe(AppDbContext context)
        {
            this.context=context;
        }
        void IJokeRepo.AddJoke(DadJokeModel joke)
        {
            joke.Joke += "!!!";

            context.DadJokes.Add(joke);
            context.SaveChanges();

        }

        List<DadJokeModel> IJokeRepo.GetJokes()
        {
            throw new NotImplementedException();
        }
    }
}
