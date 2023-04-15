
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

            //������ jwt-������ 
            builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            // ���������, ����� �� �������������� �������� ��� ��������� ������
            //            ValidateIssuer = true,
            //            // ������, �������������� ��������
            //            ValidIssuer = AuthOptions.ISSUER,
            //            // ����� �� �������������� ����������� ������
            //            ValidateAudience = true,
            //            // ��������� ����������� ������
            //            ValidAudience = AuthOptions.AUDIENCE,
            //            // ����� �� �������������� ����� �������������
            //            ValidateLifetime = true,
            //            // ��������� ����� ������������
            //            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            //            // ��������� ����� ������������
            //            ValidateIssuerSigningKey = true,
            //        };
            //    });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "ValidIssuer",
                    ValidAudience = "ValidateAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("IssuerSigningSecretKey")),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            builder.Services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
            builder.Services.AddScoped<ITestRepository>(provider => new
                    TestRepository(builder.Configuration.GetConnectionString("DefaultConnection"),
                    provider.GetService<IRepositoryContextFactory>()));

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
            
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

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

            //app.Map("/login/{username}", (string username) =>
            //{
            //    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
            //    // ������� JWT-�����
            //    var jwt = new JwtSecurityToken(
            //            issuer: AuthOptions.ISSUER,
            //            audience: AuthOptions.AUDIENCE,
            //            claims: claims,
            //            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            //    return new JwtSecurityTokenHandler().WriteToken(jwt);
            //});

            //app.Map("/data", [Authorize] () => new { message = "Hello World!" });



            //builder.Services.AddMvc();
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseRouting();

            

            app.MapControllers();

            app.Run();
            return Task.CompletedTask;
        }
        //public class AuthOptions
        //{
        //    public const string ISSUER = "MyAuthServer"; // �������� ������
        //    public const string AUDIENCE = "MyAuthClient"; // ����������� ������
        //    const string KEY = "mysupersecret_secretkey!123";   // ���� ��� ��������
        //    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        //}
    }
}
