using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibs.Objects.ESRI
{
    public class Geometry
    {
        public IEnumerable<IEnumerable<IEnumerable<double>>> rings { get; set; }
    }
}
