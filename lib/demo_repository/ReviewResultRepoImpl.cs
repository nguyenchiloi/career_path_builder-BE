using demo_core;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class ReviewResultRepoImpl : IReviewResultRepo
    {
        private readonly IBaseService _baseService;
        public ReviewResultRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public string AddReviewResult(Review_Result reviewResult)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_review_result");
                obj.AddParameter("@assessmenttime", reviewResult.assessmenttime);
                obj.AddParameter("@reviewresult", reviewResult.reviewresult);
                obj.AddParameter("@reviewid", reviewResult.reviewid);
                obj.AddParameter("@userid", reviewResult.userid);
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
            throw new NotImplementedException();
        }

        public List<Get_All_Review_Detail_By_ReviewId> GetAllReviewDetailByReviewId(int reviewid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_detail_by_reviewid");
                obj.AddParameter("@reviewid", reviewid);
                return obj.ExecStoreProcedureToList<Get_All_Review_Detail_By_ReviewId>();
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

        public List<Review_Result> GetAllReviewResult()
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_result");
                return obj.ExecStoreProcedureToList<Review_Result>();
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

        public List<Get_All_Review_Detail_By_UserId> get_All_Review_Detail_By_UserIds(int userId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_detail_by_userid");
                obj.AddParameter("@userid", userId);
                return obj.ExecStoreProcedureToList<Get_All_Review_Detail_By_UserId>();
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

        public string UpdateReviewResult(int reviewresultsid, int reviewresult)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("update_review_result");
                obj.AddParameter("@reviewresulsid", reviewresultsid);
                obj.AddParameter("@reviewresult", reviewresult);
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
