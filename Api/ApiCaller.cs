using DadJokeGenerator.Models;
using System.Runtime.InteropServices;

namespace DadJokeGenerator.Api
{
    public class ApiCaller
    {
        // Hämta httpClient
        // Göra en request
        // Hantera responsen

        public async Task<DadJokeModel?> MakeCall(string endPont)
        {
            DadJokeModel? result = await ApiInitializer.httpClient.GetFromJsonAsync<DadJokeModel>(endPont);

            return result;
            
        }
    }
}
