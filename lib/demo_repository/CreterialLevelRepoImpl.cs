using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class CreterialLevelRepoImpl : ICreterialLevelRepo
    {
        private readonly IBaseService _baseService;
        public CreterialLevelRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public List<CriterialLevel> GetAllCriterialLevel(int pathid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_level_all_critial");
                obj.AddParameter("@pathid", pathid);
                return obj.ExecStoreProcedureToList<CriterialLevel>();
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
