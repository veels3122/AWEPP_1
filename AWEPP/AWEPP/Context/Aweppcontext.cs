using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;


namespace AWEPP.Context
{
    public class Aweppcontext : DbContext
    {
        public Aweppcontext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set;}
        public DbSet<Usertype> Usertypes { get; set;}
        public DbSet<UserHistory> UserHistory { get; set; }
        public DbSet<TypeAcces> TypeAcces { get; set; }
        public DbSet<TypeAccesUser> TypeAccesUser { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Contacts>Contact  { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expenses> Expense { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<TypeAccounts> Type_account { get; set; }
        public DbSet<TypeExpenses> Type_expense { get; set; }
        public DbSet<TypeIdenty> Type_Identys { get; set; }
        public DbSet<TypeProducts> Type_product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usertype>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserHistory>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeAcces>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeAccesUser>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bank>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cities>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contacts>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expenses>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Saving>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeAccounts>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeExpenses>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeIdenty>()
                .HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeProducts>()
                .HasKey(u => u.Id);
            
        }

    }
}
