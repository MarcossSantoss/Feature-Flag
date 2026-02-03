using FeatureFlag.Infrastructure.Cache;
using StackExchange.Redis;

namespace FeatureFlag.Infrastructure.Repositories
{
    public class FeatureFlagRepository : IFeatureFlagRepository
    {
        private readonly IDatabase _redis;

        public FeatureFlagRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }

        public async Task<int> GetPercentageAsync()
        {
            var value = await _redis.StringGetAsync(RedisKeys.FeaturePercentage);

            if (value.IsNullOrEmpty)
                return 0;

            if (!int.TryParse(value.ToString(), out var percentage))
                return 0;

            return percentage;
        }

        public async Task SetPercentageAsync(int percentage)
        {
            await _redis.StringSetAsync(RedisKeys.FeaturePercentage, percentage);
        }

    }
}
