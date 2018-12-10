using Microsoft.EntityFrameworkCore;

namespace Buffteks.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options): base(options){
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssign> ProjectAssigns { get; set; }

        // Join
        
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>().ToTable("Client");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Project>().ToTable("Project");
 
            modelBuilder.Entity<ProjectAssign>()
                .HasKey(pr => new {pr.ProjectID, pr.ParticipantID});

             //Project to ProjectAssign
            modelBuilder.Entity<ProjectAssign>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.Participants)
                .HasForeignKey(pr => pr.ProjectID);

            //ProjectParticipant to ProjectAssign
            modelBuilder.Entity<ProjectAssign>()
                .HasOne(pr => pr.ProjectParticipant)
                .WithMany(pp => pp.Projects)
                .HasForeignKey(pr => pr.ParticipantID);
        }  

    }
}    