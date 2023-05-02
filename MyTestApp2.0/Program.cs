using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DBRepository.Repositories.AppRepositories;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Identity;
using Models;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

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


            
            //builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<RepositoryContextFactory>();
            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    //Конфигурация пароля
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireDigit = false;
            //});
            //builder.Services.AddHttpContextAccessor();
            //builder.Services.AddMvcCore().AddApiExplorer();

           
        

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

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("manager"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }

            // Создание менеджера
            string adminEmail = "admin@mail.com";
            string adminPassword = "Qwerty";
            string adminName = "Администратор";

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {                    
                    FirstName = adminName,
                    Email = adminEmail,
                    UserName = adminEmail
                };
                IdentityResult result = await
                userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "manager");
                }
            }

            // Создание покупателя
            string userName = "Покупатель";
            string userEmail = "user@mail.com";
            string userPassword = "Qwerty";
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User
                {
                    FirstName = userName,
                    Email = userEmail,
                    UserName = userEmail
                };
                IdentityResult result = await
                userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "customer");
                }
            }
        }
    }

}

