
namespace GeometryLibs.Objects.ESRI
{
    using Newtonsoft.Json;
    using NpgsqlTypes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Feature object data model
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets attributes for feature
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets geometry for feature
        /// </summary>
        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        /// <summary>
        /// Method for converting ESRI 
        /// </summary>
        /// <returns>IEnumerable coordinate object compatible with PostGIS polygon geometry types</returns>
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

        /// <summary>
        /// Gets inner ring coordinates from ESRIJson geometry
        /// </summary>
        /// <param name="dList">Enumerable array of parent ring container</param>
        /// <returns>IEnumerable coordinate object compatible with PostGIS geom specifications</returns>
        private IEnumerable<Coordinate2D> RingConvert(IEnumerable<IEnumerable<double>> dList)
        {
            foreach (IEnumerable<double> r in dList)
            {
                double[] d = r.ToArray();
                yield return new Coordinate2D(d[0], d[1]);
            }
        }

        /// <summary>
        /// cast to string representation for use in ST_Geometry::FromText method.
        /// </summary>
        /// <returns>string representation of geometry object</returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"POLYGON ("); // todo: make geomtype agnostic 
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

        /// <summary>
        /// Casts as string representation of geometry
        /// </summary>
        /// <param name="geomType">Geometry type to cast</param>
        /// <returns>String representation of esriJson geometry object</returns>
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
