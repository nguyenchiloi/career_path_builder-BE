using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface ICriteriaRepo
    {
        public string AddCriteriaToLevel(float p_point, float p_coefficien,int p_criteriaid,int p_nodeid);
        public List<CriteriaByLevel> GetCriteriaByLevel(int p_levelid);
    }
}
