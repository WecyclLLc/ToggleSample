using System.Collections.Generic;

namespace Infrastructure
{
    public interface IFeatureOptions
    {
        Dictionary<string, string> Options();
    }
}
