using System;
using System.Collections.Generic;
using System.Text;
using BitcoGG_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BitcoGG_API.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
    }
}
