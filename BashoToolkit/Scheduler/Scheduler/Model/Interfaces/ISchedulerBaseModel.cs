using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerBaseModel : IBaseModel
    {
        void SetDisplayedDates(DateTime from, DateTime to);

        void SetDate(DateTime date);
        void SetDate(DateTime date, DateTime from, DateTime to);

        void SetSelectedDate(DateTime selected);
        void SetToday(DateTime today);

        SchedulerDisplayInfo DisplayInfo { get; }

        DateTime From { get; }
        DateTime To { get; }
    }
}
