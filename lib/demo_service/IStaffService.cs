﻿using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IStaffService
    {
        public ResponseMessage AddStaff(Staff staff);
        public ResponseMessage GetAllStaff();
        public ResponseMessage GetStaffByReviewId(int reviewId);
    }
}
