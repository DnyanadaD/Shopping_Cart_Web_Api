using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Data
{
    public class ShoppingCartDbContext : DbContext
    { 
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
    {

    }
    public DbSet<UserDetails> UserDetails { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<AddressT> AddressT { get; set; }
    public DbSet<feedback> feedback { get; set; }

        //public DbSet<SignInModel> SignInModel { get; set; }

    }
}