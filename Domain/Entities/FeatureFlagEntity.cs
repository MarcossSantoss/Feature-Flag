namespace FeatureFlag.Domain.Entities
{
    public class FeatureFlagEntity
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Environment { get; set; }
        public bool IsEnabled { get; set; }
    }
}
