using System.Collections.Generic;

namespace Infrastructure
{
    public class FeatureContext : IFeatureContext
    {
        private readonly IFeatureOptions _featureOptions;
        public FeatureContext(IFeatureOptions featureOptions)
        {
            _featureOptions = featureOptions;
        }
        public IList<IFeature> Features()
        {
            return new List<IFeature>()
            {
                new Feature("FeatureA", _featureOptions),
                new Feature("FeatureB", _featureOptions)
            };
        }
    }
}
