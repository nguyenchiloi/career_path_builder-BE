using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IAssensorRepo
    {
        public string AddAssenor(int p_userid, float p_ratingcoefficient, int p_reviewid);
    }
}
