using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace Basho.Toolkit.Scheduler
{
    internal class SchedulerHourToRowConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)values[0];
            SchedulerDisplayInfo displayInfo = (SchedulerDisplayInfo)values[1];

            if (displayInfo.WorkingDays[(int)date.DayOfWeek])
                return (2 * displayInfo.WorkingHoursTo.Hours) + (displayInfo.WorkingHoursTo.Minutes / 30);
            return 24; // 00:00 - 12:00
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
