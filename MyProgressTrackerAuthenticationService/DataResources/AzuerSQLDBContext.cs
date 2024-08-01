using Microsoft.EntityFrameworkCore;
using MyProgressTrackerAuthenticationService.Models.Entities;

namespace MyProgressTrackerAuthenticationService.DataResources
{
    public class AzuerSQLDBContext : DbContext
    {
        public AzuerSQLDBContext(DbContextOptions<AzuerSQLDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration can be done here
        }
    }
}
