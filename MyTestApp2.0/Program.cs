using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DBRepository.Repositories.AppRepositories;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Identity;
using Models;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MyTestApp
{
    class Program
    {
        public static Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // добавляем сервисы CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTestService", Version = "v1", });
            });

            builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/my-app/build";
            });


            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ITestRepository>(provider => new
                    TestRepository(builder.Configuration.GetConnectionString("DefaultConnection"),
                    provider.GetService<IRepositoryContextFactory>()));
            builder.Services.AddScoped<IUserRepository>(provider => new
                    UserRepository(builder.Configuration.GetConnectionString("DefaultConnection"),
            provider.GetService<IRepositoryContextFactory>()));
            builder.Services.AddScoped<IProjectRepository>(provider => new
                   ProjectRepository(builder.Configuration.GetConnectionString("DefaultConnection"),
            provider.GetService<IRepositoryContextFactory>()));
            builder.Services.AddScoped<ITestGroupRepository>(provider => new
                   GroupRepository(builder.Configuration.GetConnectionString("DefaultConnection"),
            provider.GetService<IRepositoryContextFactory>()));

            //builder.Services.AddIdentity<User, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = false;
            //})
            //.AddUserStore<RepositoryContextFactory>()
            //.AddDefaultTokenProviders();



            //Auto-migrations
            builder.Services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
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

            app.UseHttpsRedirection();

            // настраиваем CORS https://metanit.com/sharp/aspnet6/14.2.php

            app.UseCors(builder =>
                  builder.WithOrigins("https://localhost:32768/", "https://localhost:3000")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .SetIsOriginAllowed(_ => true)
                 .AllowCredentials()
             );
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Join(app.Environment.ContentRootPath, "ClientApp/my-app");

                if (app.Environment.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");

                }
            });

           
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.MapControllers();
            //CreateUserRoles(service).Wait();
            app.Run();
            return Task.CompletedTask;
        }

        
    }

}

