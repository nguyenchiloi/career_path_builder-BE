﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_core
{
    public interface IBaseService
    {
        public InitNpgConnection GetConnection();
    }
}
