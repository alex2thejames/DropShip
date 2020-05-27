using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DropShip.Models;

namespace DropShip
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
            services.AddSession(opts => 
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
                 // Set a short timeout for easy testing.
                // opts.IdleTimeout = TimeSpan.FromMinutes(60);
                // You might want to only set the application cookies over a secure connection:
                // opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                // opts.Cookie.SameSite = SameSiteMode.Strict;
                // opts.Cookie.HttpOnly = true;
                // Make the session cookie essential
                // opts.Cookie.IsEssential = true;
            });

            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddRazorPagesOptions(o =>
                {
                    // This is for Sample only, remove this to handle the post request in secure way
                    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
                });
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}