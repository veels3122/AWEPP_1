using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext (DbContextOptions options): base(options)
        {
            
        }
        public DbSet<User>Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u=> u.Id);
        }
    }
}
