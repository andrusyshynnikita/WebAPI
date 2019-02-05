using MvvmCross.Plugin.Color;
using MvvmCross.UI;
using System.Globalization;

namespace TestProject.IOS.Converters
{
    public class ColorValueConverter : MvxColorValueConverter<bool>

    {

        protected override MvxColor Convert(bool value, object parameter, CultureInfo culture)
        {
            if (value)
            {
                return new MvxColor(0, 100, 0);
            }

            return new MvxColor(255, 0, 0);
            
        }
    }
}