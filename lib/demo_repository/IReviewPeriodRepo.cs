using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IReviewPeriodRepo
    {
        public List<Review_Period> GetAllReviewPeriod();
        public List<Review_Period> GetAllReviewPeriodByReview(int p_reviewid,int p_pathid);
        public List<Review_Period> GetAllReviewPeriodByPath(int pathid);
        public string AddReviewPeriod(string p_reviewname, DateTime timestart, DateTime timeend,int pathId);

    }
}
