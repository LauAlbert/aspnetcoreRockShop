using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockShop.Models
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                  serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Rocks.Any())
                {
                    context.AddRange(
                        new Rock { Name = "Red Rock", ShortDescription = "This is a red rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/1.jpg", ImageThumbnailUrl = "Images/1.jpg", Price = 41.20M, RockOfTheWeek = true },
                        new Rock { Name = "Blue Rock", ShortDescription = "This is a blue rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/2.jpg", ImageThumbnailUrl = "Images/2.jpg", Price = 2.30M },
                        new Rock { Name = "Orange Rock", ShortDescription = "This is a orange rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/3.jpg", ImageThumbnailUrl = "Images/3.jpg", Price = 14.90M },
                        new Rock { Name = "Black Rock", ShortDescription = "This is a black rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/4.jpg", ImageThumbnailUrl = "Images/4.jpg", Price = 13.10M },
                        new Rock { Name = "Light Blue Rock", ShortDescription = "This is a light blue rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/5.jpg", ImageThumbnailUrl = "Images/5.jpg", Price = 112.10M },
                        new Rock { Name = "Green Rock", ShortDescription = "This is a green rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/6.jpg", ImageThumbnailUrl = "Images/6.jpg", Price = 65.80M },
                        new Rock { Name = "Silver Rock", ShortDescription = "This is a silver rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/7.jpg", ImageThumbnailUrl = "Images/7.jpg", Price = 2.30M },
                        new Rock { Name = "Gold Rock", ShortDescription = "This is a gold rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/8.jpg", ImageThumbnailUrl = "Images/8.jpg", Price = 5.90M, RockOfTheWeek = true },
                        new Rock { Name = "Violet Rock", ShortDescription = "This is a violet rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/9.jpg", ImageThumbnailUrl = "Images/9.jpg", Price = 6.70M },
                        new Rock { Name = "Pink Rock", ShortDescription = "This is a pink rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/10.jpg", ImageThumbnailUrl = "Images/10.jpg", Price = 97.60M, RockOfTheWeek = true },
                        new Rock { Name = "White Rock", ShortDescription = "This is a white rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/11.jpg", ImageThumbnailUrl = "Images/11.jpg", Price = 2.50M },
                        new Rock { Name = "Yellow Rock", ShortDescription = "This is a yellow rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/12.jpg", ImageThumbnailUrl = "Images/12.jpg", Price = 5.40M, RockOfTheWeek = true },
                        new Rock { Name = "Brown Rock", ShortDescription = "This is a brown rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/13.jpg", ImageThumbnailUrl = "Images/13.jpg", Price = 50.50M, RockOfTheWeek = true },
                        new Rock { Name = "Purple Rock", ShortDescription = "This is a purple rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/14.jpg", ImageThumbnailUrl = "Images/14.jpg", Price = 34.20M },
                        new Rock { Name = "Water Rock", ShortDescription = "This is a water rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/15.jpg", ImageThumbnailUrl = "Images/15.jpg", Price = 12.60M, RockOfTheWeek = true },
                        new Rock { Name = "Fire Rock", ShortDescription = "This is a fire rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/16.jpg", ImageThumbnailUrl = "Images/16.jpg", Price = 9.00M },
                        new Rock { Name = "Thunder Rock", ShortDescription = "This is a thunder rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/17.jpg", ImageThumbnailUrl = "Images/17.jpg", Price = 4.50M },
                        new Rock { Name = "Grass Rock", ShortDescription = "This is a grass rock.", LongDescription = lorem, Weight = 6.80, ImageUrl = "Images/17.jpg", ImageThumbnailUrl = "Images/17.jpg", Price = 3.50M }

                        );
                }
                context.SaveChanges();
            }
        }

        public static string lorem =  "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Praesent id mauris at sapien rhoncus ullamcorper. Sed tincidunt lacinia efficitur. Praesent hendrerit enim neque, eget mattis ex pulvinar in. Aliquam porta dapibus consectetur. Aliquam a vehicula sem. Donec a est quis tellus sollicitudin auctor ut at lectus. Maecenas mattis porta risus.";
    }
}
