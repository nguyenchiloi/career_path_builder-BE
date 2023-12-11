using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class CriterialLevel
    {

        public int nodeid { get; set; }
        public int pathid { get; set; }
        public string levelname { get; set; }
        public int criteriaid { get; set; }
        public string criterianame { get; set; }
        public float point {  get; set; }
        public float coefficien {  get; set; }
    }
}
