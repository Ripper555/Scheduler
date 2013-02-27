using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerMonthModel : ISchedulerBaseModel
    {
        SchedulerWeekModel[] Weeks { get; }

        int DisplayedWeeks { get; set; }
    }
}
