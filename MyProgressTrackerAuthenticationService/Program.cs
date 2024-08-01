
using Microsoft.EntityFrameworkCore;
using MyProgressTrackerAuthenticationService.DataResources;
using MyProgressTrackerAuthenticationService.Handlers;
using MyProgressTrackerAuthenticationService.Services;

namespace MyProgressTrackerAuthenticationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AzuerSQLDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AzuerSQLDBConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<SystemAuthenticationServiceCore>();
            builder.Services.AddScoped<UserLoginHandler>();
            builder.Services.AddScoped<UserRegistrationHandler>();

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
