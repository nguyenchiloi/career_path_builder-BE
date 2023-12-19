using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class ListReviewResult
    {
        public int userid {  get; set; }
        public List<ReviewResult> reviewResults { get; set; }
    }
}
