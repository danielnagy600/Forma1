using Forma1WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Forma1WebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Forma1WebApp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = new SqliteConnection("datasource=:memory:");
            connection.Open();

            services.AddIdentity<StoreUser, IdentityRole>(cfg => 
            {
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.User.RequireUniqueEmail = false;
                cfg.Password.RequiredUniqueChars = 0;
                
            })
              .AddEntityFrameworkStores<Forma1Context>();

            services.AddTransient<TeamSeeder>();

            services.AddControllersWithViews();
            services.AddDbContext<Forma1Context>(options => 
            {
                //TODO: Kiszervezni json fájlba
                options.UseSqlite(connection);
            });
            
            services.AddScoped<ITeamRepository, TeamRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
             
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Fallback",
                    pattern: "{controller=App}/{action=Index}/{id?}");
            });
        }
    }
}
