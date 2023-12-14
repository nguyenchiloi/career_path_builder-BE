using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static NpgsqlTypes.NpgsqlTsQuery;

namespace demo_repository
{
    public class LevelRepoImpl : ILevelRepo
    {
        private readonly IBaseService _baseService;
        public LevelRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public string AddNewLevel(string levelname, string shortname, int cycles, string description, int parentid, int pathid, int positionx, int positiony, int levelclass)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_level");
                obj.AddParameter("@levelname", levelname);
                obj.AddParameter("@shortname", shortname);
                obj.AddParameter("@cycles", cycles);
                obj.AddParameter("@description", description);
                obj.AddParameter("@parentid", parentid);
                obj.AddParameter("@pathid", pathid);
                obj.AddParameter("@positionx", positionx);
                obj.AddParameter("@positiony", positiony);
                obj.AddParameter("@levelclass", levelclass);
                return obj.ExecStoreToString();
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

        public List<Level> GetAllLevel(int pathid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_level");
                obj.AddParameter("@pathid", pathid);
                
                return obj.ExecStoreProcedureToList<Level>();
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
