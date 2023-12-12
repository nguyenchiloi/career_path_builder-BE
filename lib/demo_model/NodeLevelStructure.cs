using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class NodeLevelStructure
    {
        public int levelid {  get; set; }
        public int nodeid { get; set; }
        public string levelname {  get; set; }
        public string shortname {  get; set; }
        public int cycles {  get; set; }
        public string description {  get; set; }
        public int? parentid {  get; set; }
        public int pathid {  get; set; }
        public bool isold { get; set; }//Check xem phần tử đã có ở data cũ chưa
    }
}
