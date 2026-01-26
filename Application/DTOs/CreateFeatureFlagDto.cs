namespace FeatureFlag.Application.DTOs
{
    public class CreateFeatureFlagDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Environment { get; set; }
        public bool IsEnabled { get; set; }
    }
}
