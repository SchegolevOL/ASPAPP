using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication5Context(
                serviceProvider.GetRequiredService<DbContextOptions<WebApplication5Context>>()))
            {
                if (context == null || context.Movie == null) 
                {
                    throw new ArgumentNullException("Null_Webapp5context");
                }

                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                        new Movie
                        {
                             Title = "Film1",
                             ReleaseDate = DateTime.Parse("22-09-1987"),
                             Genre = "Romantic Comedy",
                             Price = 12.80M
                        },
                        new Movie
                        {
                             Title = "Film2",
                             ReleaseDate = DateTime.Parse("02-09-1883"),
                             Genre = "Brutal Dramma",
                             Price = 17.30M
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}
