using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB.Models;

namespace WEB.Data;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<City> Cities {get; set;}
    public DbSet<Country> Countries {get; set;}
    public DbSet<Shipping> Shippings {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<OrderItem> OrderItems {get; set;}
    public DbSet<Order> Orders {get; set;}
    
}