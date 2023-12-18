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

        public List<CriteriaByCapacity> GetCriteriaByPathid(int p_pathid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_criteria_by_pathid");
                obj.AddParameter("@pathid", p_pathid);
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
        public List<Criteria> GetCriteriaDetaiByID(int p_criteriaid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_criteria_detail_by_criteriaid");
                obj.AddParameter("@criteriaid", p_criteriaid);
                return obj.ExecStoreProcedureToList<Criteria>();
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
