using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Facturio.Creation
{
    /// <summary>
    /// Un convertisseur qui reçoit un booléen et retourne un objet de type Visibility
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convertie un booléen en objet de type Visibility
        /// </summary>
        /// <param name="value">Le booléen</param>
        /// <returns>Retourne un objet de type Visibility</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Retourne Visibility.Visible seulement si le booléen est vrai
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
