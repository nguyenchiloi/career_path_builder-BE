﻿using demo_common;
using demo_model;
using demo_repository;
using System.IO;

namespace demo_service
{
    public class ReviewPeriodServiceImpl : IReviewPeriodService
    {
        private readonly IReviewPeriodRepo _repo;
        
        public ReviewPeriodServiceImpl(IReviewPeriodRepo repo)
        {
            _repo = repo;
        }

        public ResponseMessage AddReviewPeriod(Review_Period review_period)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.AddReviewPeriod(review_period.reviewname,review_period.timestart,review_period.timeend,review_period.pathid);
                rp.message = "Thêm đợt đánh giá thành công";
            }
            catch(Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
            }
            return rp;
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
            catch(Exception ex ) 
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage GetAllReviewPeriodByReview(int id, int p_pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewPeriodByReview(id,p_pathid);
                rp.message = "Lấy danh sách đợt đánh giá thành công";
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage GetAllReviewPeriodByPath(int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewPeriodByPath(pathid);
                rp.message = "Lấy danh sách đợt đánh giá thành công";
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
            }
            return rp;
        }

        public ResponseMessage UpdateReviewPeriod(Review_Period review_periods)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.UpdateReviewPeriod(review_periods.reviewid,review_periods.reviewname,review_periods.timestart,review_periods.timeend);
                rp.message = "Cặp nhật đợt đánh giá thành công";
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
