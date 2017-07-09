

namespace GeometryLibs.Objects.ESRI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// EsriJson field object
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Gets or sets name of field
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets type of field.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets alias of field
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }
    }
}
