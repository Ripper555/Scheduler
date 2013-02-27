using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basho.Toolkit.Scheduler
{
    public interface IWeekSelected
    {
        void SelectWeek(ISchedulerWeekModel week);
    }
}
