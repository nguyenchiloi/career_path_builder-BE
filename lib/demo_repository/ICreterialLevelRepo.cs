﻿using demo_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_repository
{
    public interface ICreterialLevelRepo
    {
        public List<CriterialLevel> GetAllCriterialLevel(int pathid);
    }
}
