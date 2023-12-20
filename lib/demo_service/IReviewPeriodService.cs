using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IReviewPeriodService
    {
        public List<Review_Period> GetAllReviewPeriod();
        public ResponseMessage GetAllReviewPeriodResponse();
        public ResponseMessage GetAllReviewPeriodByReview(int reviewid,int pathid);
        public ResponseMessage GetAllReviewPeriodByPath(int pathid);
        public ResponseMessage AddReviewPeriod(Review_Period review_period);
        public ResponseMessage UpdateReviewPeriod(Review_Period review_periods);
    }
}
