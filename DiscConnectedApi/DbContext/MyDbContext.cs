using Microsoft.EntityFrameworkCore;

namespace DiscConnectedApi.DbContext
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=tcp:gruppcrd.database.windows.net,1433;Initial Catalog=disccord;Persist Security Info=False;User ID=gruppcrd;Password=NUskavikoda123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; 

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Models.Forum> Forum { get; set; } = default!;
    }
}
