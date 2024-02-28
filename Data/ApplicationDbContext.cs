using Microsoft.EntityFrameworkCore;
using ProductModel;
using CartModel;
using UserModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace book_store.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
    }
}
