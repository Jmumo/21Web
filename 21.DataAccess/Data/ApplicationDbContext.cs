
using _21.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace _21.DataAccess.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }

    // protected override  void onModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Category>().HasData(new Category
    //     {
    //         Id = 1,
    //         Name = "Test",
    //         Description = "Test",
    //         DisplayOrder = 1
    //     });
    // }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            Name = "Action",
            Description = "Action",
            DisplayOrder = 1
        },
            
        new Category
        {
            Id = 2,
            Name = "SCIFI",
            Description = "SCIFI",
            DisplayOrder = 2
        },
        
        new Category
            {
                Id = 3,
                Name = "History",
                Description = "History",
                DisplayOrder = 3
            }
        );
        
        
    }
}