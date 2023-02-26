﻿using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x=>x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(y => y.Name).IsUnique();
        }
    }
}