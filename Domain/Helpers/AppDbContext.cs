using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using CaliperApi.Domain.Models;

namespace CaliperApi.Domain.Helpers
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
                
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
         
            base.OnModelCreating(builder);
        }
    }
}