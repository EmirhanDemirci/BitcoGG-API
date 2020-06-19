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
        //Create Users table
        public DbSet<User> Users { get; set; }
        //Create Wallet table
        public DbSet<Wallet> Wallet { get; set; }
        //Create PurchasedCoin table
        public DbSet<PurchasedCoin> PurchasedCoin { get; set; }
    }
}
