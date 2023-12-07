using demo_common;
using demo_model;
using demo_repository;

namespace demo_service
{
    public class ReviewPeriodServiceImpl : IReviewPeriodService
    {
        private readonly IReviewPeriodRepo _repo;
        
        public ReviewPeriodServiceImpl(IReviewPeriodRepo repo)
        {
            _repo = repo;
        }

        public List<Review_Period> GetAllReviewPeriod()
        {
            return _repo.GetAllReviewPeriod();
        }

        public ResponseMessage GetAllReviewPeriodResponse()
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewPeriod();
                rp.message = "Lấy danh sách đợt đánh giá thành công";
            }
            catch
            {
                rp.status = MessageStatus.error;
                rp.message = "Lấy danh sách đợt đánh giá thất bại";
                rp.data = null;
            }
            return rp;
        }
    }
}
