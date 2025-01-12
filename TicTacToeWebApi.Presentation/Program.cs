using Microsoft.EntityFrameworkCore;
using TicTacToeWebApi.DAL;
using TicTacToeWebApi.DAL.Interfaces;
using TicTacToeWebApi.DAL.Repositories;
using TicTacToeWebApi.Domain.Entity;
using TicTacToeWebApi.Service.Emplementations;
using TicTacToeWebApi.Service.Interfaces;

namespace TicTacToeWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionStrings));

            builder.Services.AddScoped<IBaseRepository<Game>, GameRepository>();
            builder.Services.AddScoped<IGameService, GameService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}