using demo_core;
using demo_model;

namespace demo_repository
{
    public class ReviewPeriodRepoImpl : IReviewPeriodRepo
    {
        private readonly IBaseService _baseService;
        public ReviewPeriodRepoImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public string AddReviewPeriod(string reviewname, DateTime timestart, DateTime timeend, int pathId)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_review_period");
                obj.AddParameter("@reviewname", reviewname);
                obj.AddParameter("@timestart", timestart);
                obj.AddParameter("@timeend", timeend);
                obj.AddParameter("@pathid", pathId);
                return obj.ExecStoreToString();
            }catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                obj.Disconnect();
                obj.Dispose();
            }
        }

        public List<Review_Period> GetAllReviewPeriod()
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_period");
                return obj.ExecStoreProcedureToList<Review_Period>();
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

        public List<Review_Period> GetAllReviewPeriodByPath(int pathid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_detail_by_pathid");
                obj.AddParameter("@pathid", pathid);
                return obj.ExecStoreProcedureToList<Review_Period>();
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

        public List<Review_Period> GetAllReviewPeriodByReview(int p_reviewid,int p_pathid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("get_all_review_detail_by_reviewid");
                obj.AddParameter("@reviewid", p_reviewid);
                obj.AddParameter("@pathid", p_pathid);
                return obj.ExecStoreProcedureToList<Review_Period>();
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
