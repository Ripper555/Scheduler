using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerMonthDayNameHeaderViewModel : SchedulerBaseDayViewModel
    {
        #region construtors

        public SchedulerMonthDayNameHeaderViewModel(ISchedulerDayModel day)
            : base(day)
        {
            SetModel(day, "DayOfWeek");
        }

        #endregion

        #region public properties

        public string DayOfWeek
        {
            get { return day.DayOfWeek; }
        }

        #endregion
    }
}
