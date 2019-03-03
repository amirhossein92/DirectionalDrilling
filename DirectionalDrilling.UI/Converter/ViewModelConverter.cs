using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DirectionalDrilling.UI.Base;

namespace DirectionalDrilling.UI.Converter
{
    public class ViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((UserControlViewModelBase) value).UserControlView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((UserControlViewBase) value).UserControlViewModel;
        }
    }
}