using System;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class PrepDb
	{

        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
			using(var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
				SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

		public static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migration....");
                try
                {
                    context.Database.Migrate();
                }catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migration: {ex.Message}");
                }
            }
            
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                Console.WriteLine("CommandService Endpoint http://localhost:5144/api/c/Platforms/");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We alerady have data");
            }
        }

        
    }
}

