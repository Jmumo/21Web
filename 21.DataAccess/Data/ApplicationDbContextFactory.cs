using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _21.DataAccess.Data;


    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=21Web;User Id=sa;Password=Johnda12#;TrustServerCertificate=True;");
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
