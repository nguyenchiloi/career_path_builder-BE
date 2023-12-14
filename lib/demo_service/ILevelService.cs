using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface ILevelService
    {
        public ResponseMessage AddLevel(Level level);
        public ResponseMessage GetLevelByPathid(int pathid);
        public ResponseMessage GetTreeByPathid(int pathid);
    }
}
