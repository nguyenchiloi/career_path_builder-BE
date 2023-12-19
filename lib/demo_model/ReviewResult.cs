using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class ReviewResult
    {
            public int reviewresultid { get; set; }
            public int userid { get; set; }
            public int assessorid { get; set; }
            public int reviewid { get; set; }
            public DateTime assessmenttime { get; set; }
            public int criteriaid { get; set; }
            public float point { get; set; }
            public string note { get; set; }
    }
}
