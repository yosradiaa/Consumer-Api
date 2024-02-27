
using Day_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_1
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
            builder.Services.AddDbContext<DepartmentContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
            });

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolice", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCors("MyPolice");
            app.MapControllers();
            app.Run();
        }
    }
}
