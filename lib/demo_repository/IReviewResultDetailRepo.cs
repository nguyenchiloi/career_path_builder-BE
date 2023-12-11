using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IReviewResultDetailRepo
    {
        public string AddReviewResultDetail(double p_point, string p_note, int criteriaid, int assessorid, int reviewresultid);
    }
}
