using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface ILevelRepo
    {
        public string AddNewLevel(string levelname, string shortname, int cycles, string description, int parentid, int pathid, int positionx, int positiony, int levelclass);
        public List<Level> GetAllLevel(int pathid);
    }
}
