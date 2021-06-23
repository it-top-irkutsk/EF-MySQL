using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_MySQL
{
    class Program
    {
        static void Main()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            var options = new DbContextOptions<Context>();
            if (connectionString != null)
            {
                options = optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("5.7.33-mysql")).Options;
            }
            else
            {
                throw new ArgumentNullException();
            }

            using var db = new Context(options);
            var users = db.TableUsers.ToList();
            Console.WriteLine("USER:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.LastName}, {user.FirstName}, {user.IsActive}");
            }
            Debug.WriteLine("!!! OK !!!");
        }
    }
}