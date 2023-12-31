﻿using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BookStorage.db");
        }
    }
}
