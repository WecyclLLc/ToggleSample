using System.Collections.Generic;

namespace Infrastructure
{
    public interface IFeatureContext
    {

        IList<IFeature> Features();
    }
}
