using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EbsTisbiBook.WebAppMVC.Models.Identity
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        public IdentityContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Teacher>().ToTable("TeacherUsers");
            modelBuilder.Entity<Student>().ToTable("StudentUsers");
        }
    }
}