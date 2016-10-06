using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using EQ_Dev.Classes;
using EQ_Dev.Enums;

namespace EQ_Dev.Converters
{
    public class ToleranceToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (MyStock) value;
            switch (temp.Type)
            {
                case TypeOfStock.Bond:
                    return temp.TransactionCost > 100000 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.WhiteSmoke);
                case TypeOfStock.Equity:
                    return temp.TransactionCost > 200000 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.WhiteSmoke);
                default:
                    return new SolidColorBrush(Colors.WhiteSmoke);
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}