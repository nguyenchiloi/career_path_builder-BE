using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IAllReviewResultUserService
    {
        public ResponseMessage GetAllReviewResultUser(int staffId);
        public ResponseMessage GetReviewResultUserByKey(int staffId, int pathid, int reviewid);
        public ResponseMessage GetReviewResultUserByUserid(int staffid, int reviewid, int reviewresultid);
        public ResponseMessage GetAverageReviewResultUser(int listuserid, int pathid);
        public ResponseMessage GetUserCompare(int pathid, int reviewid, int userid1, int userid2);

    }
}
