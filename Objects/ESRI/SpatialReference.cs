using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeometryLibs.Objects.ESRI
{
    /// <summary>
    /// Spatial reference of EsriJson object
    /// </summary>
    public class SpatialReference
    {
        /// <summary>
        /// Gets or sets native well-known id (wkid) for GCS / projection
        /// </summary>
        [JsonProperty(PropertyName = "wkid")]
        public int wkid { get; set; }

        /// <summary>
        /// Gets or sets latest (wkid) for GCS / projection
        /// </summary>
        [JsonProperty(PropertyName = "latestWkid")]
        public int latestWkid { get; set; }
    }
}
