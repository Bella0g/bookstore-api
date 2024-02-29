using Microsoft.EntityFrameworkCore;
using book_store.Data;
using book_store.Services;
using Microsoft.AspNetCore.Identity;
using UserModel;

namespace book_store;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Database=Database;Username=postgres;Password=BookApi123"));
        builder.Services.AddAuthorization(options =>
    
            options.AddPolicy(
                "add/cart",
                policy =>
                {
                    policy.RequireAuthenticatedUser();
                }
            ));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();

            //Authentication
            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            builder.Services.AddScoped<ProductService, ProductService>();
            //builder.Services.AddScoped<CartService, CartService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapIdentityApi<User>();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
}
