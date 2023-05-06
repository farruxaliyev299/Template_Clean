﻿using HackTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest.Infrastructure.Persistence
{
    public class HackTestDbContext : DbContext
    {
        public HackTestDbContext(DbContextOptions<HackTestDbContext> options):base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
