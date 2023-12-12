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
    public class CriteriaByCapacityServiceImpl : ICriteriaByCapacityService
    {
        private readonly ICriteriaByCapacityRepo _repo;
        public CriteriaByCapacityServiceImpl(ICriteriaByCapacityRepo repo)
        {
            this._repo = repo;
        }
        public ResponseMessage GetAllCriteriaByCapacity(int capacityid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.message = "Lấy danh sách tiêu chí thuộc khung năng lực thành công";
                rp.status = MessageStatus.success;
                rp.data = _repo.GetCriteriaByCapacity(capacityid);
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
