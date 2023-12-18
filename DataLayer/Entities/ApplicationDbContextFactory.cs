using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Entities
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<UniDbContext>
    {
        public UniDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=UniDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new UniDbContext(optionsBuilder.Options);
        }
    }
}
