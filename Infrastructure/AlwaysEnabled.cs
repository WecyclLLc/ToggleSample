namespace Infrastructure
{
    public class AlwaysEnabled : IFeatureToggle
    {
        public bool FeatureEnabled => true;

        public string Name { get; set; }
    }
}
