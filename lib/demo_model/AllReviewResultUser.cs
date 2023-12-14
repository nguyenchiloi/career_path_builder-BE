using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class AllReviewResultUser
    {
        public int resultdetailid {  get; set; }
        public int criteriaid {  get; set; }
        public string criterianame {  get; set; }
        public float point {  get; set; }
        public int assessorid {  get; set; }
        public string note {  get; set; }
        public int userdanhgia {  get; set; }
        public float ratingcoefficient {  get; set; }
        public int userduocdanhgia { get; set; }
        public int reviewresultsid { get; set; }
    }
}
