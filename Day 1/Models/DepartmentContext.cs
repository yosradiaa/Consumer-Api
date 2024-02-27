using Microsoft.EntityFrameworkCore;

namespace Day_1.Models
{
    public class DepartmentContext :DbContext
    {
        public DepartmentContext() { }
        public DepartmentContext( DbContextOptions option ):base(option)
        {

        }
        public DbSet<Department> Departments { get; set; }

        //to make the Department name unique
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasIndex(d => d.name)
                .IsUnique();
        }
    }
}
