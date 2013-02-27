using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public interface ISchedulerDayModel : ISchedulerBaseModel
    {
        DateTime Date { get; }

        bool IsToday { get; }

        bool IsActive { get; }

        bool IsSelected { get; }

        string DayOfWeek { get; }

        string Month { get; }

        Category Category { get; }

        List<Occurrence> DayOccurrences { get; }
    }
}
