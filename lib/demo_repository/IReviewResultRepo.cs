using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IReviewResultRepo
    {
        public List<Review_Result> GetAllReviewResult();
        public List<Get_All_Review_Detail_By_ReviewId> GetAllReviewDetailByReviewId(int reviewid);
        public List<Get_All_Review_Detail_By_UserId> get_All_Review_Detail_By_UserIds(int userId);
        public string AddReviewResult(Review_Result reviewResult);
        public string UpdateReviewResult(int reviewresultsid, int reviewresult);

    }
}
