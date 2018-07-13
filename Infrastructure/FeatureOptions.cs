using System.Collections.Generic;

namespace Infrastructure
{
    public class FeatureOptions : IFeatureOptions
    {
        public Dictionary<string, string> Options()
        {
            return new Dictionary<string, string>()
            {
                { "FeatureA.Type", "Infrastructure.AlwaysEnabled"},
                {"FeatureB.Type", "Infrastructure.AlwaysDisabled" }
            };
        }
    }
}
