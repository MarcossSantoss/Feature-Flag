using FeatureFlag.Application.DTOs;
using FeatureFlag.Domain.Entities;

namespace FeatureFlag.Application.Services
{
    public class FeatureFlagService : IFeatureFlagService
    {
        public FeatureFlagService()
        {
        }

        public Task CreateFlagAsync(CreateFeatureFlagDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FeatureFlagEntity>> GetFlagsAsync(string environment)
        {
            throw new NotImplementedException();
        }

        public Task<FeatureFlagEntity?> GetFlagByKeyAsync(string key, string environment)
        {
            throw new NotImplementedException();
        }
    }
}
