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

    }
}
