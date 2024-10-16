using System.Collections.Generic;
using System.Reflection.Emit;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Usertype> UserTypes { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<TypeAcces> TypeAccesses { get; set; }
        public DbSet<TypeAccesUser> TypeAccessUsers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expenses> Expense { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<TypeAccounts> Accounts { get; set; }
        public DbSet<TypeExpenses> Expenses { get; set; }
        public DbSet<TypeIdenty> TipoIdenty { get; set; }
        public DbSet<TypeProducts> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Usertype>().HasKey(u => u.Id);
            modelBuilder.Entity<UserHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeAcces>().HasKey(u => u.Id);
            modelBuilder.Entity<Bank>().HasKey(u => u.Id);
            modelBuilder.Entity<Cities>().HasKey(u => u.Id);
            modelBuilder.Entity<Contacts>().HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().HasKey(u => u.Id);
            modelBuilder.Entity<Expenses>().HasKey(u => u.Id);
            modelBuilder.Entity<Products>().HasKey(u => u.Id);
            modelBuilder.Entity<Saving>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeAccounts>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeExpenses>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeIdenty>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeProducts>().HasKey(u => u.Id);
        }
    }
}
