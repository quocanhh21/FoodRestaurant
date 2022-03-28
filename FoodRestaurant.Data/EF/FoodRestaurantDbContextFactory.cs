using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodRestaurant.Data.EF
{
    public class FoodRestaurantDbContextFactory : IDesignTimeDbContextFactory<FoodRestaurantDbContext>
    {
        public FoodRestaurantDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<FoodRestaurantDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new FoodRestaurantDbContext(optionsBuilder.Options);
        }
    }
}
