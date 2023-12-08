using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class PathRepoImpl : IPathRepo
    {
        private readonly IBaseService _baseService;
        public PathRepoImpl(IBaseService baseService) {
            this._baseService = baseService;
        }
        public string AddPath(string p_pathname, int p_capacityid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_path");
                obj.AddParameter("@pathname", p_pathname);
                obj.AddParameter("@capacityid", p_capacityid);
                return obj.ExecStoreToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }

        public List<demo_model.Path> GetAllPath()
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_path");
                return obj.ExecStoreProcedureToList<demo_model.Path>();

            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }
    }
}
