
namespace GeometryLibs.Objects.ESRI
{
    using Newtonsoft.Json;
    using NpgsqlTypes;
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

        public IEnumerable<IEnumerable<Coordinate2D>> ToPostGISPoly()
        {
            foreach (IEnumerable<IEnumerable<double>> rr in Geometry.rings)
            {
                foreach (IEnumerable<double> r in rr)
                {
                    yield return RingConvert(rr);
                }
            }
        }

        private IEnumerable<Coordinate2D> RingConvert(IEnumerable<IEnumerable<double>> dList)
        {
            foreach (IEnumerable<double> r in dList)
            {
                double[] d = r.ToArray();
                yield return new Coordinate2D(d[0], d[1]);
            }
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"POLYGON (");
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
