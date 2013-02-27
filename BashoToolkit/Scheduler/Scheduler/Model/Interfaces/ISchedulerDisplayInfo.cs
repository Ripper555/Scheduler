using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerDisplayInfo : INotifyPropertyChanged, IDisposable
    {
        CultureInfo Culture { get; }

        DayOfWeek FirstDayOfWeek { get; set; }

        CalendarWeekRule CalendarWeekRule { get; set; }

        bool[] WorkingDays { get; }

        TimeSpan WorkingHoursFrom { get; set; }

        TimeSpan WorkingHoursTo { get; set; }
    }
}
