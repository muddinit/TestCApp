using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace TestCApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TestDb"));

        }

        private static void AddTestData(ApiContext context)
        {

            context.AddRange(
            new Models.Dot
            {
                Id = 1,
                PositionX = 120.5,
                PositionY = 120,
                Radius = 25,
                Color = "red"
            },
            new Models.Dot
            {
                Id = 2,
                PositionX = 345.5,
                PositionY = 10,
                Radius = 2.5,
                Color = "yellow"
            },
            new Models.Dot
            {
                Id = 3,
                PositionX = 250.5,
                PositionY = 50,
                Radius = 11.25,
                Color = "yellow"
            },
            new Models.Post
            {
                DotId = 1,
                Text = "commment",
                BackgroundColor = "red"
            },
            new Models.Post
            {
                DotId = 2,
                Text = "1",
                BackgroundColor = "purple"
            },
            new Models.Post
            {
                DotId = 2,
                Text = "ooooooooooooooooooooooo",
                BackgroundColor = "gray"
            },
            new Models.Post
            {
                DotId = 2,
                Text = "ooooooooooooooooooooooo",
                BackgroundColor = "cyan"
            }
            );

            context.SaveChanges();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var context = serviceProvider.GetService<ApiContext>();
            AddTestData(context);

        }
    }
}
