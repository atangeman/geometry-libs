using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibs.Objects.ESRI
{
    /// <summary>
    /// EsriJson Geometry object 
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Gets or sets geometry coordinate rings
        /// </summary>
        public IEnumerable<IEnumerable<IEnumerable<double>>> rings { get; set; }
    }
}
