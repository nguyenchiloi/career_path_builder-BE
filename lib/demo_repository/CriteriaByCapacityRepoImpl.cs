using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class CriteriaByCapacityRepoImpl : ICriteriaByCapacityRepo
    {
        private readonly IBaseService _baseService;
        public CriteriaByCapacityRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public List<CriteriaByCapacity> GetCriteriaByCapacity(int p_capacityid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_criterial_by_capacity");
                obj.AddParameter("@capacityid", p_capacityid);
                return obj.ExecStoreProcedureToList<CriteriaByCapacity>();

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
