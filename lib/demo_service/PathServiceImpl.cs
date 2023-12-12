using demo_common;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class PathServiceImpl : IPathService
    {
        private readonly IPathRepo _pathRepo;
        public PathServiceImpl(IPathRepo pathRepo)
        {
            this._pathRepo = pathRepo;
        }
        public ResponseMessage AddPath(demo_model.Path path)
        {
            ResponseMessage rpm = new ResponseMessage();
            try
            {
                rpm.data = _pathRepo.AddPath(path.pathname, path.capacityid);
                rpm.status = MessageStatus.success;
                rpm.message = "Thêm lộ trình thành công";
            }
            catch {
                rpm.data = null;
                rpm.status = MessageStatus.error;
                rpm.message = "Thêm lộ trình thất bại";
            }
            return rpm;
        }

        public ResponseMessage GetAllPath()
        {
            ResponseMessage rpm = new ResponseMessage();
            try
            {
                rpm.message = "Lấy danh sách lộ trình thành công";
                rpm.status = MessageStatus.success;
                rpm.data = _pathRepo.GetAllPath();
            }
            catch
            {
                rpm.message = "Lấy danh sách lộ trình thất bại";
                rpm.status = MessageStatus.error;
                rpm.data = null;
            }
            return rpm;
        }
    }
}
