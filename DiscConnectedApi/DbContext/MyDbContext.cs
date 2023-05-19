using Microsoft.EntityFrameworkCore;

namespace DiscConnectedApi.DbContext
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=tcp:gruppcrd.database.windows.net,1433;Initial Catalog=disccord;Persist Security Info=False;User ID=gruppcrd;Password=NUskavikoda123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; // Replace with your Azure SQL Database connection string

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Models.Forum> Forum { get; set; } = default!;
        public DbSet<Models.SubForum> Subforum { get; set; } = default!;
    }
}
