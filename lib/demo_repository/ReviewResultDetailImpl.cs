using demo_core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public class ReviewResultDetailImpl : IReviewResultDetailRepo
    {
        private readonly IBaseService _baseService;
        public ReviewResultDetailImpl(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public string AddReviewResultDetail(double p_point, string p_note, int criteriaid, int assessorid, int reviewresultid)
        {
            var obj = _baseService.GetConnection();
            try
            {
                obj.Connect();
                obj.CreateNewStoredProcedure("add_review_result_detail");
                obj.AddParameter("@point", p_point);
                obj.AddParameter("@note", p_note);
                obj.AddParameter("@criteriaid", criteriaid);
                obj.AddParameter("@assessorid", assessorid);
                obj.AddParameter("@reviewresultsid", reviewresultid);
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
