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
        public ResponseMessage AddAssensor(List<Assensor> assensors)
        {
            ResponseMessage rp = new ResponseMessage();
            int index = 0;
            foreach (Assensor assensor in assensors)
            {
                try {
                    string res = _repo.AddAssenor(assensor.assessorid ,assensor.userid, assensor.ratingcoefficient, assensor.reviewid);
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
    }
}
