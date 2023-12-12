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
    public class CreterialLevelServiceImpl : ICreterialLevelService
    {
        private readonly ICreterialLevelRepo _repo;
        public CreterialLevelServiceImpl(ICreterialLevelRepo repo)
        {
            _repo = repo;
        }

        public ResponseMessage GetAllCreterialLevel(int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllCriterialLevel(pathid);
                rp.message = "Lấy tiêu chí từng level thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }
    }
}
