using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class NodeChartLevelStructureOutput<T>
    {
        public int classid { get; set; }
        public List<NodeChartLevelStructureDataOutput<T>> listdata { get; set; }
    }
}
