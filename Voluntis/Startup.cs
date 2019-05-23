using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Voluntis.Data;
using Voluntis.Models;

// https://github.com/bart120/Voluntis

namespace Voluntis
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VoluntisDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("VolConnection"))
            );

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

            })
                .AddEntityFrameworkStores<VoluntisDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromMinutes(20);

                options.LoginPath = "/Account/onlogin";
                options.AccessDeniedPath = "/Account/AccessDenied";
                
            });
            

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                //app.UseStatusCodePagesWithRedirects("/SatusCode?code={0}");
            }

            // Middleware pour les fichiers statics
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(ConfigureRoute);

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            // area route
            routeBuilder.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            // default route
            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "index" });

            /*routeBuilder.MapRoute(
                name: "apropos",
                template: "a-propos-de",
                defaults: new { controller = "Home", action = "About" });
                */
        }
    }
}
