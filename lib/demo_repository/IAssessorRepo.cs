using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IAssessorRepo
    {
        public string AddAssessor(int p_assessorid, int p_userid, float p_ratingcoefficient, int p_reviewid);
        public List<AssessorUser> GetAllUserByAssessorIDReviewID(int p_assessorid, int p_reviewid);
        public List<Assessor> GetListAssessorByReviewId(int p_reviewid);
    }
}
