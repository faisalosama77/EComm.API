﻿using EComm.API.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace EComm.API.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Fluent API 
            modelBuilder.Entity<Customer>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Customer>()
                .Property(p => p.Status)
                .HasDefaultValue("Active");

            modelBuilder.Entity<Customer>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue("False");
            modelBuilder.Entity<Customer>()
                .HasIndex(p => p.Email) // clusterd and un clasterd index
                .IsUnique();
                
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasDefaultValue("Available");

            modelBuilder.Entity<Product>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue("False");

            modelBuilder.Entity<Order>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue("False");

            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Order>()
                .HasMany(oi => oi.OrderItem)
                .WithOne(o => o.Order);
        }

    }
}
