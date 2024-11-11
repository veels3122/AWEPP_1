using System.Collections.Generic;
using System.Reflection.Emit;
using AWEPP.Models;
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
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Usertype> UserTypes { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<TypeAcces> TypeAccesses { get; set; }
        public DbSet<TypeAccesUser> TypeAccessUsers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<TypeAccounts> TypeAccounts { get; set; }
        public DbSet<TypeExpenses> TypeExpenses { get; set; }
        public DbSet<TypeIdenty> TypeIdentities { get; set; }
        public DbSet<TypeProducts> TypeProductss { get; set; }
       public DbSet<Expenses> Expensess { get; set; }
        public DbSet<BankHistory> BankHistory { get; set; }
        public DbSet<Products> Productss { get; set; }
        public DbSet<CitiesHistory> CitiesHistory { get; set; }
        public DbSet<ContactsHistory> ContactsHistory { get; set; }
        public DbSet<CustomerHistory> CustomerHistory { get; set; }
        public DbSet<ExpensesHistory> ExpensesHistory { get; set; }
        public DbSet<ProductsHistory> ProductsHistory { get; set; }
        public DbSet<SavingHistory> SavingHistory { get; set; }
        public DbSet<TypeAccesHistory> TypeAccesHistory { get; set; }
        public DbSet<TypeAccesUserHistory> TypeAccesUserHistory { get; set; }
        public DbSet<TypeAccountsHistory> TypeAccountsHistory { get; set; }
        public DbSet<TypeExpensesHistory> TypeExpensesHistory { get; set; }
        public DbSet<TypeIdentyHistory> TypeIdentyHistory { get; set; }
        public DbSet<TypeProductsHistory> TypeProductsHistory { get; set; }
        public DbSet<UsertypeHistory> UsertypeHistory { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Usertype>().HasKey(u => u.Id);
            modelBuilder.Entity<UserHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeAccesUser>().HasKey(ta => ta.Id);
            modelBuilder.Entity<TypeAcces>().HasKey(u => u.Id);
            modelBuilder.Entity<Bank>().HasKey(u => u.Id);
            modelBuilder.Entity<Cities>().HasKey(u => u.Id);
            modelBuilder.Entity<Contacts>().HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().HasKey(u => u.Id);
            modelBuilder.Entity<Saving>().HasKey(u => u.Id);
            modelBuilder.Entity<Products>().HasKey(p => p.Id);
            modelBuilder.Entity<TypeAccounts>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeExpenses>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeIdenty>().HasKey(u => u.Id);
            modelBuilder.Entity<TypeProducts>().HasKey(u => u.Id);
            modelBuilder.Entity<Expenses>().HasKey(e => e.Id);
            modelBuilder.Entity<AuditLog>().Property(a => a.Date).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");


        }
    }
}
