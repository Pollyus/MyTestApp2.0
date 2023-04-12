using DBRepository;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyTestApp
{
    class Program
    {
        public IConfiguration Configuration { get; }
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<RepositoryDbContext>(
            //    o => o.UseNpgsql(provider => new TestRepository (builder.Configuration.GetConnectionString("MyTestsDb"), provider.GetService<IRepositoryContextFactory>()));
            builder.Services.AddSingleton<IRepositoryContextFactory, RepositoryContextFactory>(); // 1
            builder.Services.AddScoped<ITestRepository>(provider => new TestRepository(builder.Configuration.GetConnectionString("DefaultConnection"), provider.GetService<IRepositoryContextFactory>()));
           // DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=delete2;Username=postgres;Password=postgres");

            var app = builder.Build();

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
        }
    }
}
