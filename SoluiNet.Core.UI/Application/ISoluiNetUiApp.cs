// <copyright file="ISoluiNetUiApp.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.UI.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoluiNet.Core.Application;
    using SoluiNet.Core.Plugin;
    using SoluiNet.Core.UI;
    using SoluiNet.Core.UI.UIElement;

    /// <summary>
    /// Provides an interface for the SoluiNet.DevTools UI application.
    /// </summary>
    public interface ISoluiNetUiApp : ISoluiNetApp
    {
        /// <summary>
        /// Gets all available UI elements.
        /// </summary>
        ICollection<ISoluiNetUIElement> UiElements { get; }
    }
}