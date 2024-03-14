using Microsoft.EntityFrameworkCore;
using ProductModel;
using CartModel;
using UserModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using book_store.Models;

namespace book_store.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public ApplicationDbContext() { }
    }

}
