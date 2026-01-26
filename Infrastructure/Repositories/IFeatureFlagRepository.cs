using System.Collections.Generic;
using System.Threading.Tasks;
using FeatureFlag.Application.DTOs;
using FeatureFlag.Domain.Entities;

namespace FeatureFlag.Infrastructure.Repositories
{
    public interface IFeatureFlagRepository
    {
        Task CreateFlagAsync(CreateFeatureFlagDto dto);
        Task<IEnumerable<FeatureFlagEntity>> GetFlagsAsync(string environment);
        Task<FeatureFlagEntity?> GetFlagByKeyAsync(string key, string environment);
    }
}
