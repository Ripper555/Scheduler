using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace Basho.Toolkit.Scheduler
{
    internal class SchedulerHourFromRowConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //DateTime week = (DateTime)values[0];
            //SchedulerDisplayInfo displayInfo = (SchedulerDisplayInfo)values[1];

            return 0; // always row 0
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
