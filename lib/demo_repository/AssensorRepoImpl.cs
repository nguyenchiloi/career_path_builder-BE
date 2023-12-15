using demo_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class AssensorRepoImpl : IAssensorRepo
    {
        private readonly IBaseService _baseService;
        public AssensorRepoImpl(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public string AddAssenor(int p_assessorid, int p_userid, float p_ratingcoefficient, int p_reviewid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_assessor");
                obj.AddParameter("@assessorid", p_assessorid);
                obj.AddParameter("@userid", p_userid);
                obj.AddParameter("@ratingcoefficient", p_ratingcoefficient);
                obj.AddParameter("@reviewid", p_reviewid);
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
