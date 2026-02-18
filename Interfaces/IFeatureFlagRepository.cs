namespace FeatureFlag.Infrastructure.Repositories
{
    public interface IFeatureFlagRepository
    {
        Task<int> GetPercentageAsync();
        Task SetPercentageAsync(int percentage);
    }
}
