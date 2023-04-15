
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ReactApp
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

            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
            //app.UseMvc();

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
            
            // Add services to the container.

            builder.Services.AddControllersWithViews();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //Db connection withoutauto migrations
            // builder.Services.AddSingleton<IRepositoryContextFactory, RepositoryContextFactory>(); // 1
            //builder.Services.AddScoped<ITestRepository>(provider => new TestRepository(builder.Configuration.GetConnectionString("DefaultConnection"), provider.GetService<IRepositoryContextFactory>()));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;


            //builder.Services.AddMvc();
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            return Task.CompletedTask;
        }
    }
}
