using Microsoft.EntityFrameworkCore;

namespace DropShip.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<Cart> Carts {get;set;}
    }
}