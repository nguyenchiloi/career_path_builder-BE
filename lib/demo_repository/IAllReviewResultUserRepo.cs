﻿using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IAllReviewResultUserRepo
    {
        public List<AllReviewResultUser> GetAllReviewResultUsers(int userId);
        public List<AllReviewResultUser> GetAllReviewResultUsersByUseridAndReviewId(int reviewid, int userId);
        public List<AllReviewResultUser> GetAllStaffReviewResultDetail(int userId,int reviewId, int reviewresultsId);
        public string UpdateStaff(int userId, int nodeid, string positionjob);
        public List<Staff> GetAllStaff(int userId);
        public List<ReviewResult> GetAllReviewResultByAssessoridReviewid(int assessorid, int reviewid);

    }
}
