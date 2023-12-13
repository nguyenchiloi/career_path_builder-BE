using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface ICriteriaByCapacityRepo
    {
        public List<CriteriaByCapacity> GetCriteriaByCapacity(int p_capacityid);
    }
}
