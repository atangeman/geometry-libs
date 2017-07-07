using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometryLibs.Objects.ESRI
{
    public class SpatialReference
    {
        [JsonProperty(PropertyName = "wkid")]
        public int wkid { get; set; }

        [JsonProperty(PropertyName = "latestWkid")]
        public int latestWkid { get; set; }
    }
}
