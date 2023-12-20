using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class AssessorServiceImpl : IAssessorService
    {
        private readonly IAssessorRepo _repo;
        public AssessorServiceImpl(IAssessorRepo repo)
        {
            this._repo = repo;
        }
        public ResponseMessage AddAssessor(List<Assessor> assessors)
        {
            ResponseMessage rp = new ResponseMessage();
            int index = 0;
            foreach (Assessor assessor in assessors)
            {
                try {
                    string res = _repo.AddAssessor(assessor.assessorid ,assessor.userid, assessor.ratingcoefficient, assessor.reviewid);
                    if (Int32.Parse(res) == -1)
                    {
                        rp.message = "Thêm người đánh giá không thành công";
                        rp.status = MessageStatus.error;
                        rp.data = index;
                        return rp;
                    }
                    index++;
                } catch (Exception ex) {
                    rp.message = ex.Message;
                    rp.status = MessageStatus.error;
                    rp.data = null;
                    return rp;
                }
                
            }
            rp.message = "Thêm người đánh giá thành công";
            rp.status = MessageStatus.success;
            rp.data = null;
            return rp;
        }

        public ResponseMessage GetAllUserByAssessorIDReviewID(int assessorID, int reviewID)
        {
            ResponseMessage rp = new ResponseMessage();
            if (assessorID>0 &&  reviewID>0)
            {
                try
                {
                        rp.message = "Lấy danh sách user theo người đánh giá và đợt đánh giá thành công";
                        rp.status = MessageStatus.success;
                        rp.data = _repo.GetAllUserByAssessorIDReviewID(assessorID, reviewID);
                        return rp;
                }
                catch (Exception ex)
                {
                    rp.message = ex.Message;
                    rp.status = MessageStatus.error;
                    rp.data = null;
                    return rp;
                }
            }
            rp.message = "Lấy danh sách user theo người đánh giá và đợt đánh giá không thành công";
            rp.status = MessageStatus.error;
            rp.data = null;
            return rp;
        }

        public ResponseMessage GetListAssessorByReviewId(int reviewId)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.data = _repo.GetListAssessorByReviewId(reviewId);
                rp.message = "Lấy danh sách đánh giá thành công";
                rp.status = MessageStatus.success;
                return rp;
            }
            catch (Exception ex)
            {
                rp.message = ex.Message;
                rp.status = MessageStatus.error;
                rp.data = null;
                return rp;
            }
        }
    }
}
