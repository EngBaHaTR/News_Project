using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Context;
using NewsProject.Server.Repository;
using NewsProject.Server.Repository.Main;
using NewsProject.Server.Repository.Services;
using NewsProject.Shared.Models;

namespace NewsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var conectionstring = builder.Configuration.GetConnectionString("DefultConnection");
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(conectionstring));
            //builder.Services.AddScoped<MainInterface<Category> , CategoriesServices>();
           // builder.Services.AddScoped<MainInterface<NewsList>, MainServices<NewsList>>();
            builder.Services.AddScoped<CategoriesServices>();
            builder.Services.AddScoped<NewsListServices>();
            builder.Services.AddScoped<MainInterface<Comment>, MainServices<Comment>>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
