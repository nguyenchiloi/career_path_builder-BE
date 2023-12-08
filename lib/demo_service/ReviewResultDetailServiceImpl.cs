using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class ReviewResultDetailServiceImpl : IReviewResultDetailService
    {
        private readonly IReviewResultDetailRepo _reviewResultDetailRepo;
        public ReviewResultDetailServiceImpl(IReviewResultDetailRepo reviewResultDetail)
        {
            _reviewResultDetailRepo = reviewResultDetail;
        }

        public ResponseMessage AddReviewResultDetail(List<Add_Review_Result_Detail> model)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                foreach (var item in model)
                {
                    _reviewResultDetailRepo.AddReviewResultDetail(item.point, item.note, item.criteriaid, item.accessorid, item.reviewresultid);
                }
                rp.message = "Thêm đánh giá thành công";
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
            }
            return rp;
        }
    }
}
