using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class Level
    {
        public int levelid {  get; set; }
        public int nodeid {  get; set; }
        public string levelname { get; set; }
        public string shortname { get; set; }
        public int cycles { get; set; }
        public string description { get; set; }
        public int parentid { get; set; }
        public int pathid { get; set; }
        public int positionx { get; set; }
        public int positiony { get; set; }
        public int levelclass { get; set; }
    }
}
