using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface ITreeLevelService
    {
        public List<NodeLevelStructure> GetTreeByUsername(int nodeid);
        public List<NodeLevelStructure> GetAllEmployee();
        public ResponseMessage GetAllLevel();
        public NodeGetTreeLevelStructure GetTreeByUsername();
    }
}
