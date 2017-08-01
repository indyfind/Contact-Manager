using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContactManagerContext(
                serviceProvider.GetRequiredService<DbContextOptions<ContactManagerContext>>()))
            {
                // Look for any movies.
                if (context.Company.Any())
                {
                    return;   // DB has been seeded
                }

                context.Company.AddRange(
                     new Company
                     {
                         Name = "Vandalay Industries",
                         Address1 = "123 Fake St.",
                         City = "New York",
                         State = "NY",
                         Zip = 34800,
                         Phone = "5554902876",
                         Category = "Architecture"
                     },
                     new Company
                     {
                         Name = "Dunkin Donuts",
                         Address1 = "813 E Belvidere Rd",
                         City = "Grayslake",
                         State = "IL",
                         Zip = 60030,
                         Phone = "8475437366",
                         Category = "Restaurant"
                     },
                     new Company
                     {
                         Name = "Jimmy Johns",
                         Address1 = "1924 N Illinois 83",
                         City = "Round Lake Beach",
                         State = "IL",
                         Zip = 60035,
                         Phone = "8479862775",
                         Category = "Restaurant"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
