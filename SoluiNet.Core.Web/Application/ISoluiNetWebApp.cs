// <copyright file="ISoluiNetWebApp.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoluiNet.Core.Application;
    using SoluiNet.Core.Plugin;
    using SoluiNet.Core.Web.Plugin;

    /// <summary>
    /// Provides an interface for the SoluiNet.DevTools UI application.
    /// </summary>
    public interface ISoluiNetWebApp : ISoluiNetApp
    {
        /// <summary>
        /// Gets or sets all available web plugins.
        /// </summary>
        ICollection<IProvidesWebCommunication> WebPlugins { get; set; }
    }
}