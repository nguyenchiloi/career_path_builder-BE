using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class NodeGetTreeLevelStructure
    {
        public List<NodeChartLevelStructureOutput<NodeLevelStructure>> nodes { get; set; }
        public List<NodeEdgeChartNode> edges { get; set; }

        public List<NodeLevelStructure> levels { get; set; }
    }
}
