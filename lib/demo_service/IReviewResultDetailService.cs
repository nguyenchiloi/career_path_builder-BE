using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IReviewResultDetailService
    {
        public ResponseMessage GetAllReviewResultDetail();
        public ResponseMessage AddReviewResultDetail(List<Add_Review_Result_Detail> add_Review_Result_Detail);
    }
}
