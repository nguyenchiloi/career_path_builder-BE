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
    public class ReviewResultServiceImpl : IReviewResultService
    {
        private readonly IReviewResultRepo _repo;
        public ReviewResultServiceImpl(IReviewResultRepo repo)
        {
            this._repo = repo;
        }

        public ResponseMessage AddReviewResult(Review_Result review_Result)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.AddReviewResult(review_Result);
                rp.message = "Thêm danh sách thành công";
            }
            catch
            {
                rp.status = MessageStatus.error;
                rp.message = "Thêm danh sách thất bại";
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage GetAllReviewDetailByReviewID(int id)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewDetailByReviewId(id);
                rp.message = "Lấy danh sách thành công";
            }
            catch
            {
                rp.status = MessageStatus.error;
                rp.message = "Lấy danh sách thất bại";
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage GetAllReviewDetailByUserID(int id)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.get_All_Review_Detail_By_UserIds(id);
                rp.message = "Lấy danh sách thành công";
            }
            catch
            {
                rp.status = MessageStatus.error;
                rp.message = "Lấy danh sách thất bại";
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage GetAllReviewResult()
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewResult();
                rp.message = "Lấy danh sách kết quả đánh giá thành công";
            }
            catch
            {
                rp.status = MessageStatus.error;
                rp.message = "Lấy danh sách kết quả đánh giá thất bại";
                rp.data = null;
            }
            return rp;
        }
    }
}
