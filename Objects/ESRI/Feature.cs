
namespace GeometryLibs.Objects.ESRI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Feature
    {
        [JsonProperty(PropertyName = "attributes")]
        public IDictionary<string, object> Attributes { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }
    }
}
