using demo_common;
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
        public ResponseMessage GetReviewResultUserByKey(int staffId);
    }
}
