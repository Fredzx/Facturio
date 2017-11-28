using System;
using System.Globalization;
using System.Windows.Data;

namespace Facturio.Clients
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
                return value = "Actif";
            return value = "Inactif";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
