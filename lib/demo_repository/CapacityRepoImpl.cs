using demo_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class CapacityRepoImpl : ICapacityRepo
    {
        private readonly IBaseService _baseService;
        public CapacityRepoImpl(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public string AddCapacity(string c_capacityname, string c_description)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_capacity");
                obj.AddParameter("@capacityname", c_capacityname);
                obj.AddParameter("@description", c_description);
                return obj.ExecStoreToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj.Dispose();
                obj.Disconnect();
            }
        }
    }
}
