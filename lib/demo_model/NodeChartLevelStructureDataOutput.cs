using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class NodeChartLevelStructureDataOutput<T>
    {
        public int classid { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public T data { get; set; }
        public NodeCoordinateChart position { get; set; }
        public bool isdisable { get; set; } = false;
    }
}
