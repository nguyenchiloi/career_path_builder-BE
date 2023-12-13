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
    public class CapacityServiceImpl : ICapacityService
    {
        private readonly ICapacityRepo _repo;
        public CapacityServiceImpl(ICapacityRepo repo)
        {
            this._repo = repo;
        }
        public ResponseMessage AddCapacity(Capacity capacity)
        {
            ResponseMessage rp = new ResponseMessage();
            if (capacity.capacityname!="" && capacity.description!="") {
                try
                {

                    string res = _repo.AddCapacity(capacity.capacityname, capacity.description);
                    rp.data = res;
                    if (Int32.Parse(res) == -1)
                    {
                        rp.message = "Thêm khung năng lực không thành công";
                        rp.status = MessageStatus.error;
                        return rp;
                    }
                    rp.message = "Thêm khung năng lực thành công";
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
            else
            {
                rp.message = "Thêm khung năng lực không thành công";
                rp.status = MessageStatus.error;
                rp.data = null;
                return rp;
            }
            
        }
    }
}
