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
        public string GetAllReviewPeriod1(int p_reviewid);
        public string AddReviewPeriod(string p_reviewname, DateTime timestart, DateTime timeend,int pathId);

    }
}
