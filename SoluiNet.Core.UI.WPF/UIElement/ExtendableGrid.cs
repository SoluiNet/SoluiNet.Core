﻿// <copyright file="ExtendableGrid.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.UI.WPF.UIElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The base class for an extendable grid. The grid will create new rows for each new child.
    /// </summary>
    /// <typeparam name="T">The type which will be used for each row.</typeparam>
    public class ExtendableGrid<T> : Grid
        where T : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendableGrid{T}"/> class.
        /// The extendable grid will provide a "+"-button which will call the CreateNewElement-event and add this element to its childs.
        /// </summary>
        public ExtendableGrid()
            : base()
        {
            this.PrepareControl();
        }

        /// <summary>
        /// The delegate for the creation of a new element.
        /// </summary>
        /// <returns>Returns the new element.</returns>
        /// <example>
        /// <code>
        /// var grid = new ExtendableGrid&lt;Button&gt;();
        ///
        /// NewElementCreation newElementCreationDelegate = () => {
        ///   var newButton = new Button();
        ///
        ///   // do something with the button
        ///
        ///   return newButton;
        /// }
        ///
        /// grid.CreateNewElement = newElementCreationDelegate;
        /// </code>
        /// </example>
        public delegate T NewElementCreation();

        /// <summary>
        /// Gets or sets the create new element event handler.
        /// </summary>
        public NewElementCreation CreateNewElement { get; set; }

        /// <summary>
        /// Prepare the control.
        /// </summary>
        public void PrepareControl()
        {
            this.RowDefinitions.Clear();

            var gridLengthConverter = new GridLengthConverter();

            this.RowDefinitions.Add(new RowDefinition() { Height = (GridLength)gridLengthConverter.ConvertFrom(35) });

            var button = new Button();

            button.Content = "+";

            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.Width = 25;
            button.Height = 25;
            button.Margin = new Thickness(5);

            button.SetValue(Grid.RowProperty, 0);

            button.Click += (object sender, RoutedEventArgs e) =>
            {
                var newElement = this.CreateNewElement();

                if (newElement == null)
                {
                    return;
                }

                this.AddElement(newElement);
            };

            this.Children.Add(button);
        }

        /// <summary>
        /// Add a new element to the extendable grid.
        /// </summary>
        /// <param name="newElement">The new element which should be added.</param>
        public void AddElement(T newElement)
        {
            this.RowDefinitions.Add(new RowDefinition());

            newElement.SetValue(Grid.RowProperty, this.RowDefinitions.Count - 1);

            if (newElement is RemovableUserControl)
            {
                (newElement as RemovableUserControl).RemoveElement = () =>
                {
                    this.Children.Remove(newElement);
                };
            }

            this.Children.Add(newElement);
        }

        /// <summary>
        /// Reset the control.
        /// </summary>
        public void Reset()
        {
            this.Children.Clear();
            this.PrepareControl();
        }
    }
}
