using FeatureFlag.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlag.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeatureFlagEntity> FeatureFlags { get; set; }
    }
}
