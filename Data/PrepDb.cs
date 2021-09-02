using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Model;

namespace PlatformService.Data
{
     public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "Dot Net", Publisher = "Microsoft", Cost = "free",
                    },  new Platform()
                    {
                        Name = "Docker", Publisher = "Microsoft", Cost = "free",
                    }, new Platform()
                    {
                        Name = "Kubernetes", Publisher = "Oracle", Cost = "free",
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We have data");
            }
        }
    }
}