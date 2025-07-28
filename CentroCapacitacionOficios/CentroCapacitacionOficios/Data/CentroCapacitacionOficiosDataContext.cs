using System.ComponentModel.DataAnnotations.Schema;
using CentroCapacitacionOficios.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroCapacitacionOficios.Data
{
    public class CentroCapacitacionOficiosDataContext : DbContext
    {
        public CentroCapacitacionOficiosDataContext(DbContextOptions<CentroCapacitacionOficiosDataContext> options) : base(options) 
        { 
        }
        public DbSet<Entities.Certificate> Certificates { get; set; }
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Instructor> Instructors { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Certificate>().ToTable("Certificates");
            modelBuilder.Entity<Certificate>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.User)
                .WithMany(u => u.Certificates)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Course)
                .WithMany(cu => cu.Certificates)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Entities.Course>().ToTable("Courses");
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);

            modelBuilder.Entity<Entities.Instructor>().ToTable("Instructors");

            modelBuilder.Entity<Entities.User>().ToTable("Users");

            modelBuilder.Entity<Entities.Video>().ToTable("Videos");
            modelBuilder.Entity<Video>()
                .HasOne(v => v.Course)
                .WithMany(c => c.Videos)
                .HasForeignKey(v => v.CourseId);



        }
    }
}
