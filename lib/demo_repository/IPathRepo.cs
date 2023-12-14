using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface IPathRepo
    {
        public List<demo_model.Path> GetAllPath();
        public string AddPath(string p_pathname ,int p_capacityid);
    }
}
