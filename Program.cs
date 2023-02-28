using DadJokeGenerator.Api;
using DadJokeGenerator.Data;
using DadJokeGenerator.Services;
using Microsoft.EntityFrameworkCore;

namespace DadJokeGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            ApiInitializer.httpClient.BaseAddress = new Uri("https://icanhazdadjoke.com/");
            ApiInitializer.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var connectionString = builder.Configuration.GetConnectionString("JokeDbConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IJokeRepo, JokeRepoDeluxe>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}