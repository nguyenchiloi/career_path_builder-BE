using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IReviewResultService
    {
        public ResponseMessage GetAllReviewResult();
        public ResponseMessage GetAllReviewDetailByReviewID(int id);
        public ResponseMessage GetAllReviewDetailByUserID(int id);
        public ResponseMessage AddReviewResult(Review_Result review_Result);
    }
}
