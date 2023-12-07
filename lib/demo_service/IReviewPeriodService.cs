using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IReviewPeriodService
    {
        public List<Review_Period> GetAllReviewPeriod();
        public ResponseMessage GetAllReviewPeriodResponse();
    }
}
