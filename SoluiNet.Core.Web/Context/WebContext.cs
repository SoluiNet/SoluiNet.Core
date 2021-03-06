﻿// <copyright file="WebContext.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.Web.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoluiNet.Core.Web.Session;

    /// <summary>
    /// The web context.
    /// </summary>
    public static class WebContext
    {
        static WebContext()
        {
            SessionList = new Dictionary<string, WebSession>();
            Routes = new RouteRegistry();
        }

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        public static string LayoutTemplate { get; set; }

        /// <summary>
        /// Gets or sets the session list.
        /// </summary>
        public static Dictionary<string, WebSession> SessionList { get; set; }

        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        public static WebSession Session { get; set; }

        /// <summary>
        /// Gets or sets the routes.
        /// </summary>
        public static RouteRegistry Routes { get; set; }
    }
}
