using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface ICriteria_LevelsService
    {
        public ResponseMessage AddCriteriaToLevels(Levels_Criteria levels_Criteria);
        public ResponseMessage GetCriteriaByLevel(int levelid);
    }
}
