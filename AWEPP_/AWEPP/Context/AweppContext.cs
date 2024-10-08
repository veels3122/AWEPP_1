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
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<TypeAccount> TypeAccounts { get; set; }
        public DbSet<TypeExpense> TypeExpenses { get; set; }
        public DbSet<TypeIdenty> TypeIdentys { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Usertype>().HasKey(u => u.Id);
            modelBuilder.Entity<UserHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeAcces>().HasKey(u => u.Id);
            modelBuilder.Entity<Bank>().HasKey(u => u.Id);
            modelBuilder.Entity<City>().HasKey(u => u.Id);
            modelBuilder.Entity<Contact>().HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().HasKey(u => u.Id);
            modelBuilder.Entity<Expense>().HasKey(u => u.Id);
            modelBuilder.Entity<Product>().HasKey(u => u.Id);
            modelBuilder.Entity<Saving>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeAccount>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeExpense>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeIdenty>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeProduct>().HasKey(u => u.Id);
        }
    }
}
