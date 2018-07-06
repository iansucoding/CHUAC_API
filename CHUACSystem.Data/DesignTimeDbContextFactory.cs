using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CHUACSystem.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ACSystemDbContext>
    {
        public ACSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ACSystemDbContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=CHUACSystemDb;Trusted_Connection=True;");
            return new ACSystemDbContext(builder.Options);
        }
    }
}
