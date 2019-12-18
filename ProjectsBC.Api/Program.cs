using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectsBC.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectsBC.Domain.Entities;

namespace ProjectsBC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) 
            {
                var db = scope.ServiceProvider.GetService<ProjectDbContext>();

                db.Database.Migrate();
                Seed(db);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Seed(ProjectDbContext db) {

            if (db.Users.Any()) {
                return;
            }
            var user = new User()
            {
                Email = "mario@mario.com",
                Name = "Mario"
            };
            db.Users.Add(user);
           
            var team = new Team()
            {
                Name = "Mega Team",
                Members = new[] { user }
            };
            db.Teams.Add(team);

            var project = new Project()
            {
                Decription = "Mega Team",
                Team = team
            };
            db.Projects.Add(project);

            db.SaveChanges();

        }
    }
}
