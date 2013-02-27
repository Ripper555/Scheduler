using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace Basho.Toolkit.Scheduler
{
    internal class SchedulerMonthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)values[0];
            bool isActive = (bool)values[1];
            string month = (string)values[2];

            if ((date.Day == 1) || ((date.DayOfWeek == DayOfWeek.Monday) && !isActive))
                return month;
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
