// <copyright file="WebRenderer.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.Web.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SoluiNet.Core.Extensions;
    using SoluiNet.Core.Tools.Object;
    using SoluiNet.Core.Web.Context;

    /// <summary>
    /// The web renderer.
    /// </summary>
    public static class WebRenderer
    {
        /// <summary>
        /// Render a page.
        /// </summary>
        /// <param name="rawMarkup">The raw markup.</param>
        /// <param name="title">The title.</param>
        /// <param name="masterPageMarkup">The markup of the master page.</param>
        /// <returns>Returns the rendered markup as string.</returns>
        public static string RenderPage(string rawMarkup, string title = "", string masterPageMarkup = "")
        {
            if (string.IsNullOrEmpty(masterPageMarkup))
            {
                if (string.IsNullOrEmpty(WebContext.LayoutTemplate))
                {
                    masterPageMarkup = typeof(WebRenderer).GetEmbeddedResourceContent("Master.snhtml", "Template");
                }
                else
                {
                    masterPageMarkup = WebContext.LayoutTemplate;
                }
            }

            return masterPageMarkup.Inject(new Dictionary<string, string>()
            {
                { "Content", rawMarkup.InjectCommonValues() },
                { "Title", !string.IsNullOrEmpty(title) ? title.InjectCommonValues() : "SoluiNet.DevTools.Web" },
            });
        }
    }
}
