using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {
        public OdeToFoodDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OdeToFood;Integrated Security=True";
            builder.UseSqlServer(connectionString);
            return new OdeToFoodDbContext(builder.Options);
        }
    }
}
