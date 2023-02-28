using DadJokeGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace DadJokeGenerator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) 
        {
            
        }

        public DbSet<DadJokeModel> DadJokes { get; set; }
    }
}
