using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basho.Toolkit.Scheduler
{
    public interface IDaySelected
    {
        void SelectDay(ISchedulerDayModel day);
    }
}
