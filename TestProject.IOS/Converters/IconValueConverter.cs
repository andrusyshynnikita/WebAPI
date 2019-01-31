using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Converters;
using UIKit;

namespace TestProject.IOS.Converters
{
   public class IconValueConverter : MvxValueConverter<bool>
    {
        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == false)
            {
                return new UIImage("icons8_unchecked_checkbox_50.png");
            }

                return new UIImage("icons8_checked_checkbox_filled_50.png");

           
        }
    }
}