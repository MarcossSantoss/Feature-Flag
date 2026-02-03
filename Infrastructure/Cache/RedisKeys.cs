using StackExchange.Redis;

namespace FeatureFlag.Infrastructure.Cache
{
    public static class RedisKeys
    {
        public const string FeaturePercentage = "feature:percentage";
    }
}
