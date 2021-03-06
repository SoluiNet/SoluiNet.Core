﻿// <copyright file="DurationConverter.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Core.UI.WPF.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using SoluiNet.Core.Tools.Number;

    /// <summary>
    /// Converts durations to readable strings.
    /// </summary>
    public class DurationConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value, CultureInfo.InvariantCulture).ToDurationString();
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
