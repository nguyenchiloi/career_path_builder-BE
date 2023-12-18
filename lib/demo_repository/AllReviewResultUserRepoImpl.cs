using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<AllReviewResultUser> GetAllReviewResultUsersByUseridAndReviewId(int reviewid, int userId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_result_detail_staffid_and_reviewid");
                obj.AddParameter("@userid", userId);
                obj.AddParameter("@reviewid", reviewid);
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
    }
}
