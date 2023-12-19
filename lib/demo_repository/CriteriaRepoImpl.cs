using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class CriteriaRepoImpl : ICriteriaRepo
    {
        private readonly IBaseService _baseService;
        public CriteriaRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public string AddCriteriaToLevel(float p_point, float p_coefficien, int p_criteriaid, int p_nodeid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_criteria_to_level");
                obj.AddParameter("@point", p_point);
                obj.AddParameter("@coefficien", p_coefficien);
                obj.AddParameter("@criteriaid", p_criteriaid);
                obj.AddParameter("@nodeid", p_nodeid);
                return obj.ExecStoreToString();

            }
            catch (Exception ex){
                throw ex;
            }
            finally
            {
                obj.Dispose();
                obj.Disconnect();
            }
        }

        public List<CriteriaByLevel> GetCriteriaByLevel(int p_levelid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_criteria_by_levelid");
                obj.AddParameter("@nodeid", p_levelid);
                return obj.ExecStoreProcedureToList<CriteriaByLevel>();

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
