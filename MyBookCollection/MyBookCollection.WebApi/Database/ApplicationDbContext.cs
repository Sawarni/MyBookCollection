﻿using Microsoft.EntityFrameworkCore;
using MyBookCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
    }
}
