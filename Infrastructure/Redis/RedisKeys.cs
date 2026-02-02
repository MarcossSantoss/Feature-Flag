using StackExchange.Redis;

namespace FeatureFlag.Infrastructure.Redis
{
    public static class RedisKeys
    {
        public const string FeaturePercentage = "feature:percentage";
    }
}
