using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class CriterialLevel
    {
        public int userid { get; set; }
        public string staffname { get; set; } = string.Empty;
        public string positionjob {  get; set; } = string.Empty;
        public int nodeid { get; set; }
        public int parentid { get; set; }
        public int pathid { get; set; }
        public string levelname { get; set; } = string.Empty;
        public int criteriaid { get; set; }
        public string criterianame { get; set; }
        public float point {  get; set; }
        public float coefficien {  get; set; }
        public string reviewname { get; set; } = string.Empty;
    }
}
