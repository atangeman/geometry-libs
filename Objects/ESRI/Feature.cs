
namespace GeometryLibs.Objects.ESRI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Feature
    {
        [JsonProperty(PropertyName = "attributes")]
        public IDictionary<string, object> Attributes { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        public string ToString(string geomType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{geomType} (");
            foreach (List<List<double>> rr in Geometry.rings)
            {
                sb.Append("((");
                foreach (List<double> r in rr)
                {
                    double[] d = r.ToArray();
                    sb.Append($"{d[0]} {d[1]}");
                    sb.Append(",");
                }
                sb.Append("))");
                sb.Append(",");
            }
            sb.Append(")");

            return sb.ToString();
        }
    }
}
