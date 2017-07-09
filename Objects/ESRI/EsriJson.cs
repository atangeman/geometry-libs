
namespace GeometryLibs.Objects.ESRI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Text;

    /// <summary>
    /// EsriJson parent object for featurelayer type
    /// </summary>
    public class EsriJson
    {
        /// <summary>
        /// Gets or sets display field for symbology
        /// </summary>
        [JsonProperty(PropertyName = "displayFieldName")]
        public string DisplayFieldName { get; set; }

        /// <summary>
        /// Gets or sets field aliases
        /// </summary>
        [JsonProperty(PropertyName = "fieldAliases")]
        public IDictionary<string, string> FieldAliases { get; set; }

        /// <summary>
        /// Gets or sets geometry type
        /// </summary>
        [JsonProperty(PropertyName = "geometryType")]
        public string GeometryType { get; set; }

        /// <summary>
        /// Gets or sets spatial reference type for object
        /// </summary>
        [JsonProperty(PropertyName = "spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        /// <summary>
        /// gets or sets field objects 
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// Gets or sets feature objects
        /// </summary>
        [JsonProperty(PropertyName = "features")]
        public List<Feature> Features { get; set; }

        /// <summary>
        /// Gets feature object as Ienumerable string type
        /// </summary>
        /// <returns>Enumerable string object representing esriJson geometry type</returns>
        public IEnumerable<string> GetFeatures()
        {
            foreach(Feature f in Features)
            {
                yield return f.ToString(GeometryType);
            }
        }   
    }
}
