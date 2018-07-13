namespace Infrastructure
{
    public abstract class FeatureAbstract : IFeature
    {
        internal IFeatureOptions _options;
        public FeatureAbstract(string name, IFeatureOptions options)
        {
            _options = options;
            Name = name;
        }
        public virtual bool FeatureEnabled
        {
            get
            {
                return false;
            }
        }

        public string Name { get; set; }
    }
}
