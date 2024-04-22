using CollegeApp.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data
{
    public class CollegeDBContext : DbContext
    {
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TABLE 1
            modelBuilder.ApplyConfiguration(new StudentConfig());

            // TABLE 2
            //modelBuilder.ApplyConfiguration(new NewTableConfig());

            // TABLE 3
        }
    }
}
