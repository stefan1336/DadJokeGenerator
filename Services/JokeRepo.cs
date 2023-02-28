using DadJokeGenerator.Data;
using DadJokeGenerator.Models;

namespace DadJokeGenerator.Services
{
    public class JokeRepo : IJokeRepo
    {
        private readonly AppDbContext context;

        public JokeRepo(AppDbContext context)
        {
            this.context=context;
        }
        public void AddJoke(DadJokeModel joke)
        {
            context.DadJokes.Add(joke);
            context.SaveChanges();
        }

        public List<DadJokeModel> GetJokes()
        {
            return context.DadJokes.ToList();
        }
    }
}
