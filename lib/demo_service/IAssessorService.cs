using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IAssessorService
    {
        public ResponseMessage AddAssessor(List<Assessor> assessors);
        public ResponseMessage GetAllUserByAssessorIDReviewID(int  assessorID, int reviewID);
    }
}
