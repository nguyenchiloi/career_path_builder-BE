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
