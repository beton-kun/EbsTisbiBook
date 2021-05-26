using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EbsTisbiBook.WebAppMVC.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using EbsTisbiBook.WebAppMVC.Models.Infrastucture;
using EbsTisbiBook.WebAppMVC.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EbsTisbiBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<RazorViewEngineOptions>(o =>
            {
                //o.ViewLocationFormats.Clear();
                //o.ViewLocationFormats.Add("/Views/Admin/{1}/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddScoped<LibraryContext>();

            services.AddSession();

            services.AddDbContext<IdentityContext>(opts =>
            {
                opts.UseSqlServer(Configuration["ConnectionStrings:LibraryConnection"]);
                opts.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]);
            });

            services.AddIdentity<User, IdentityRole>(options =>
            options.Password = new PasswordOptions
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireUppercase = false,
                RequireNonAlphanumeric = false
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                  pattern: "{area:exists}/{controller=Books}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
