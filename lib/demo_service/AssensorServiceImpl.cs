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
    public class AssensorServiceImpl : IAssensorService
    {
        private readonly IAssensorRepo _repo;
        public AssensorServiceImpl(IAssensorRepo repo)
        {
            this._repo = repo;
        }
        public ResponseMessage AddAssensor(Assensor assensor)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.message = "Thêm người đánh giá thành công";
                rp.status = MessageStatus.success;
                rp.data = _repo.AddAssenor(assensor.userid, assensor.ratingcoefficient);
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
