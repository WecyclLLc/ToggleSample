using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToggleWeb.Controllers
{
    public class ValuesController : ApiController
    {
        //private readonly IFeatureContext _featureContext;
        //public ValuesController(IFeatureContext featureContext)
        //{
        //    _featureContext = featureContext;
        //    var f = _featureContext.Features();
        //    var a = f.FirstOrDefault().FeatureEnabled;
        //}
        // GET api/values
        [FeatureEnabled(FeatureName = "FeatureA")]
        public IHttpActionResult Get()
        {
            return   Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
