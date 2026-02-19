namespace FeatureFlag.Interfaces
{
    public interface IFeatureFlagService
    {
        Task<int> GetPercentage();
        Task SetPercentageAsync(int percentage);
    }
}
