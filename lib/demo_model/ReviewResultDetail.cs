using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class ReviewResultDetail
    {
        public int resultdetailid { get; set; }
        public double point { get; set; }
        public string note { get; set; }
        public int criteriaid { get; set; }
        public int assessorid { get; set; }
        public int reviewresultsid { get; set; }
    }
}
