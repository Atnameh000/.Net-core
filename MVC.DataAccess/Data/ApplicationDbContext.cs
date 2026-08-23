using First_MVC.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Models;

namespace MVC.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Category>().HasData(
    //         new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
    //         new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
    //         new Category { Id = 3, Name = "Horror", DisplayOrder = 3 }
    //     );
    // }

    public DbSet<Product> Products { get; set; }
}