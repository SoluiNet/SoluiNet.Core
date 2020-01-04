﻿// <copyright file="ISoluiNetApp.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoluiNet.Core.Plugin;

    /// <summary>
    /// Provides an interface for the SoluiNet.DevTools application.
    /// </summary>
    public interface ISoluiNetApp
    {
        /// <summary>
        /// Gets all available plugins.
        /// </summary>
        ICollection<IBasePlugin> Plugins { get; }

        /// <summary>
        /// Gets all available plugins that will run in the background.
        /// </summary>
        ICollection<IRunsBackgroundTask> BackgroundTaskPlugins { get; }
    }
}
