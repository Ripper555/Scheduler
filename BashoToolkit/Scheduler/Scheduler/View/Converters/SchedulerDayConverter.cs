using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace Basho.Toolkit.Scheduler
{
    internal class SchedulerDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException("value", "value is null.");

            DateTime date = (DateTime)value;
            
            if (date == null)
                throw new ArgumentNullException("value", "value is not DateTime.");

            return date.Day.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
