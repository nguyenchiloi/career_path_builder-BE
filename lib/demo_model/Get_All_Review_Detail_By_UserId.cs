using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_model
{
    public class Get_All_Review_Detail_By_UserId
    {
        public int userId {  get; set; }
        public string staffName { get; set; }
        public bool gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string department { get; set; }
        public string positionJob { get; set; }
        public int reviewResultsId { get; set; }
        public DateTime assessmentTime { get; set; }
        public int reviewreult { get; set; }
        public int reviewId { get; set; }
    }
}
