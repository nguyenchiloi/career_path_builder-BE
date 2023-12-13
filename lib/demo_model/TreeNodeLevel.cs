using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class TreeNodeLevel
    {
        public int id {  get; set; }
        public Level data {  get; set; }
        public NodeCoordinateChart position {  get; set; }
        public int levelclass {  get; set; }
    }
}
