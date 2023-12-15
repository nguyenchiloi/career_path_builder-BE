using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NpgsqlTypes.NpgsqlTsQuery;

namespace demo_repository
{
    public class AllReviewResultUserRepoImpl : IAllReviewResultUserRepo
    {
        private readonly IBaseService _baseService;
        public AllReviewResultUserRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public List<AllReviewResultUser> GetAllReviewResultUsers(int userId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_result_detail_staffid");
                obj.AddParameter("@userid", userId);
                return obj.ExecStoreProcedureToList<AllReviewResultUser>();
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

        public List<Staff> GetAllStaff(int userId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_detail_by_userid");
                obj.AddParameter("@userid", userId);
                return obj.ExecStoreProcedureToList<Staff>();
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

        public string UpdateStaff(int userId, int nodeid, string positionjob)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("update_staff");
                obj.AddParameter("@userid", userId);
                obj.AddParameter("@nodeid", nodeid);
                obj.AddParameter("@positionjob", positionjob);
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
    }
}
