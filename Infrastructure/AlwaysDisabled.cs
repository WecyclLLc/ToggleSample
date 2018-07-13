namespace Infrastructure
{
    public class AlwaysDisabled : IFeatureToggle
    {
        public bool FeatureEnabled => false;

        public string Name { get; set; }
    }
}
