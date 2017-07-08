﻿
namespace GeometryLibs.Objects.ESRI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using System.Text;

    public class EsriJson
    {
        [JsonProperty(PropertyName = "displayFieldName")]
        public string DisplayFieldName { get; set; }

        [JsonProperty(PropertyName = "fieldAliases")]
        public IDictionary<string, string> FieldAliases { get; set; }

        [JsonProperty(PropertyName = "geometryType")]
        public string GeometryType { get; set; }

        [JsonProperty(PropertyName = "spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty(PropertyName = "features")]
        public List<Feature> Features { get; set; }

        public IEnumerable<string> GetFeatures()
        {
            foreach(Feature f in Features)
            {
                yield return f.ToString(GeometryType);
            }
        }   
    }
}
