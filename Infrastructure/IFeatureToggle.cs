namespace Infrastructure
{
    public interface IFeatureToggle
    {
        bool FeatureEnabled { get; }
        string Name { get;  set; }
    }
}
