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
    }
}
