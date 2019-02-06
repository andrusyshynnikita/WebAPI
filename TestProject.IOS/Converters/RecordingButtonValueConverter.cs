﻿using System;
using System.Globalization;
using MvvmCross.Converters;

namespace TestProject.IOS.Converters
{
    public class RecordingButtonValueConverter : MvxValueConverter<bool>

    {
        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return "Record";
            }

            return "Stop";
        }
    }
}