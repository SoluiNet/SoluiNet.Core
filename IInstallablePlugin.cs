﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoluiNet.DevTools.Core
{
    public interface IInstallablePlugin : IBasePlugin
    {
        void Install();
    }
}
