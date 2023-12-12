using demo_common;
using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public interface IPathService
    {
        public ResponseMessage GetAllPath();
        public ResponseMessage AddPath(demo_model.Path path);
    }
}
