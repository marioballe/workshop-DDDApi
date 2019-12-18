using Microsoft.EntityFrameworkCore;
using ProjectsBC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsBC.Infrastructure
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pbi> Pbis { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //per fer mappings
        {
            modelBuilder.Entity<Sprint>().OwnsOne<DateRange>(s=> s.DateRange); // propietat de sprint
        }
    }
}
