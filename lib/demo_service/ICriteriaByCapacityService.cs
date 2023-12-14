using demo_common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface ICriteriaByCapacityService
    {
        public ResponseMessage GetAllCriteriaByCapacity(int capacityid);
        public ResponseMessage GetAllCriteriaByPathid(int pathid);
    }
}
