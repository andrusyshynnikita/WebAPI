using MvvmCross.Converters;
using MvvmCross.Plugin.Color;
using MvvmCross.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestProject.Core.Converters
{
  public  class ColorValueConverter: MvxColorValueConverter<bool>

    {

        protected override MvxColor Convert(bool value, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return new MvxColor(255, 0, 0);
            }

            return new MvxColor(0, 100, 0);
        }
    }
}
