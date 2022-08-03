using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStore.EF
{
    public class BugsContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public BugsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            //seeding
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Project 1" },
                new Project { ProjectId = 2, Name = "Project 2" }
                );


            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Title = "bug #1", ProjectId = 1 },
                new Ticket { TicketId = 2, Title = "bug #2", ProjectId = 1 },
                new Ticket { TicketId = 3, Title = "bug #3", ProjectId = 2 }
                );
        }
    }
}
