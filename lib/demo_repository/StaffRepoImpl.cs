using demo_core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
