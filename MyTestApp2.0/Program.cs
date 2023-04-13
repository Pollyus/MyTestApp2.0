using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpsPolicy;

namespace MyTestApp
{
    class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Auto-migrations
            builder.Services.AddTransient<IRepositoryContextFactory, RepositoryContextFactory>();
            var builderConfiguration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json"); //1
            var config = builderConfiguration.Build(); // 1
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())  //2
            {
                var db = scope.ServiceProvider.GetRequiredService<IRepositoryContextFactory>();
                db.CreateDbContext(config.GetConnectionString("DefaultConnection")).Database.Migrate();// 3
            }

            //Db connection withoutauto migrations
            // builder.Services.AddSingleton<IRepositoryContextFactory, RepositoryContextFactory>(); // 1
            //builder.Services.AddScoped<ITestRepository>(provider => new TestRepository(builder.Configuration.GetConnectionString("DefaultConnection"), provider.GetService<IRepositoryContextFactory>()));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //builder.Services.AddMvc();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            return Task.CompletedTask;
        }
    }

}

