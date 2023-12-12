using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class TreeLevelRepoImpl : ITreeLevelRepo
    {
        public readonly IBaseService _baseService;
        public TreeLevelRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public List<NodeLevelStructure> GetAllEmployee()
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_level");
                return obj.ExecStoreProcedureToList<NodeLevelStructure>();
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

        public List<NodeLevelStructure> GetTreeByUsername(int nodeid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_level");
                return obj.ExecStoreProcedureToList<NodeLevelStructure>();
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
