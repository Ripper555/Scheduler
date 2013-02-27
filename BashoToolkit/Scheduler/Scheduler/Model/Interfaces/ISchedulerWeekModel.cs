using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerWeekModel : ISchedulerBaseModel
    {
        int Week { get; set; }

        SchedulerDayModel[] Days { get; }

        DisplayedDays DisplayedDays { get; }
    }
}
