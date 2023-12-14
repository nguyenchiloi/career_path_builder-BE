using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface ICapacityRepo
    {
        public string AddCapacity(string c_capacityname, string c_description);
    }
}
