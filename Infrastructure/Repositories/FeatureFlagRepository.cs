using FeatureFlag.Application.Services;
using FeatureFlag.Domain.Entities;
using FeatureFlag.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FeatureFlag.Infrastructure.Repositories
{
    public class FeatureFlagRepository : IFeatureFlagRepository
    {
        private readonly AppDbContext _context;

        public FeatureFlagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FeatureFlagEntity featureFlag)
        {
            await _context.FeatureFlags.AddAsync(featureFlag);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FeatureFlagEntity>> GetAllByEnvironmentAsync(string environment)
        {
            return await _context.FeatureFlags.Where(f => f.Environment == environment).ToListAsync();
        }

        public async Task<FeatureFlagEntity?> GetByKeyAsync(string key, string environment)
        {
            return await _context.FeatureFlags.FirstOrDefaultAsync(f => f.Key == key && f.Environment == environment);
        }
    }
}
