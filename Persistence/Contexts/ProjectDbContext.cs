using Core.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts
{
    /// <summary>
    ///Çünkü bu bağlamı birden fazla sağlayıcı için taşıma takip ediyor
    /// varsayılan olarak PostGreSql db'de çalışır. sql geçmek istiyorsanız
    /// AddDbContext eklerken, ondan türetilen MsDbContext'i kullanın.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        protected IConfiguration Configuration;

        /// <summary>
        /// Burada birden fazla database oluşturmamıza olanak sağlar.Örneğin MySql,Oracle,MsSql vs.
        /// we can create migration.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            //Eski Zaman Damgası Davranışını Etkinleştir
            //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //    //DateTime Infinity Dönüşümlerini Devre Dışı Bırak
            //    AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        /// <summary>
        /// Genel versiyonu da uygulayalım.Burada diğer databaselerde eklenebilir hale getirdik.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PostgreSqlContext")).EnableSensitiveDataLogging());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
                .Entries<Entity>()
                .Where(e => e.State == EntityState.Added ||
                e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entry.Entity.UpdatedDate = DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<UserOperationClaim> userOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<CreditCart> CreditCarts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductBranch> ProductBranches { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
