using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class StaffServiceImpl : IStaffService
    {
        private readonly IStaffRepo _staffRepo;
        public StaffServiceImpl(IStaffRepo staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public ResponseMessage AddStaff(Staff staff)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _staffRepo.AddStaff(staff.staffName, staff.gender, staff.dateofbirth, staff.department, staff.positionjob, staff.nodeid);
                rp.message = "Thêm nhân viên thành công";
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

        public ResponseMessage GetAllStaff()
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _staffRepo.GetAllStaff().ToList().OrderBy(x => x.userId).ToList();
                rp.message = "lấy tất cả nhân viên thành công";
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

        public ResponseMessage GetStaffByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
