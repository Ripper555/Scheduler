using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerHolder : IDaySelected, IWeekSelected
    {
        void SetDisplayedDate(string caption);

        SchedulerDisplayInfo DisplayInfo { get; }

        DateTime SelectedDate { get; set; }
    }
}
