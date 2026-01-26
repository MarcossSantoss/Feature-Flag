using FeatureFlag.Application.DTOs;
using FeatureFlag.Domain.Entities;

namespace FeatureFlag.Application.Services
{
    public interface IFeatureFlagService
    {
        Task CreateFlagAsync(CreateFeatureFlagDto dto);
        Task<IEnumerable<FeatureFlagEntity>> GetFlagsAsync(string environment);
        Task<FeatureFlagEntity?> GetFlagByKeyAsync(string key, string environment);
    }
}
