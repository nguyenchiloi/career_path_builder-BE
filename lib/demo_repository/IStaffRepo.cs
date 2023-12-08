using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IStaffRepo
    {
        public string AddStaff(string staffname, bool gender, DateTime dateofbirth, string department, string positionjob, int nodeid);
    }
}
