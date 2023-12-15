using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static NpgsqlTypes.NpgsqlTsQuery;

namespace demo_repository
{
    public class StaffRepoImpl : IStaffRepo
    {
        private readonly IBaseService _baseService;
        public StaffRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public string AddStaff(string staffname, bool gender, DateTime dateofbirth, string department, string positionjob, int nodeid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_staff");
                obj.AddParameter("@staffname", staffname);
                obj.AddParameter("@gender", gender);
                obj.AddParameter("@dateofbirth", dateofbirth.Date);
                obj.AddParameter("@department", department);
                obj.AddParameter("@positionjob", positionjob);
                obj.AddParameter("@nodeid", nodeid);
                return obj.ExecStoreToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }

        public List<Staff> GetAllStaff()
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_staff");
                return obj.ExecStoreProcedureToList<Staff>();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }

        public List<Staff> GetStaffByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }

        public List<Staff> GetStaffByUserId(int userId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_staff_by_userid");
                obj.AddParameter("userid", userId);
                return obj.ExecStoreProcedureToList<Staff>();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }
    }
}
