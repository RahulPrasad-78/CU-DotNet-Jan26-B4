using Assessment13.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VagaBond.WebAPI.Data;
using VagaBond.WebAPI.Repository;
using VagaBond.WebAPI.Service;

namespace VagaBond.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<VagaBondWebAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VagaBondWebAPIContext") ?? throw new InvalidOperationException("Connection string 'VagaBondWebAPIContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
            builder.Services.AddScoped<IDestinationService, DestinationService>();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
