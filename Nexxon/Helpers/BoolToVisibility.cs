using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Nexxon.Helpers
{
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is bool))
            {
                return Visibility.Collapsed;
            }
            else
            {
                bool objValue = (bool)value;

                if (objValue)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if ((bool)value)
                {
                    return Visibility.Visible;
                }
            }
            catch
            { }

            return Visibility.Collapsed;
        }
    }
}
