using DadJokeGenerator.Models;

namespace DadJokeGenerator.Services
{
    public interface IJokeRepo
    {
        void AddJoke(DadJokeModel joke);
        List<DadJokeModel> GetJokes();
    }
}
