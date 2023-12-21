using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class MsDbContext : ProjectDbContext
    {
        public MsDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration) : base(options, configuration)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServerContext")));
        }
    }
}
