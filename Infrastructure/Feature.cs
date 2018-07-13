using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Infrastructure
{
    public class Feature : IFeature
    {
        private IFeatureToggle _type = null;
        private readonly IFeatureOptions _options;
        public Feature(string name, IFeatureOptions options)
        {
            Name = name;
            _options = options;
        }


        private Dictionary<Type, bool> requireName = new Dictionary<Type, bool>()
        {
            {typeof(AlwaysEnabled), false },
            {typeof(AlwaysDisabled), false }
        };

        public bool FeatureEnabled
        {
            get
            {
                if (_type != null) return _type.FeatureEnabled;

                //var type =  ConfigurationManager.AppSettings[$"{Name}.Type"];
                var type = _options.Options().FirstOrDefault(x => x.Key == $"{Name}.Type").Value;
                Type t = Type.GetType(type);

                var kvp = requireName.FirstOrDefault(x => x.Key == t);

                return (kvp.Value ? (IFeatureToggle)Activator.CreateInstance(t, new object[] { Name }) : (IFeatureToggle)Activator.CreateInstance(t)).FeatureEnabled;
            }
        }

        public string Name { get;  set; }
    }
}
