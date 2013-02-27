using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerDayBodyBorderViewModel : SchedulerBaseDayViewModel
    {
        #region construtors

        public SchedulerDayBodyBorderViewModel(ISchedulerDayModel day)
            : base(day)
        {
            SetModel(day, "IsActive", "IsToday");
        }

        #endregion

        #region public properties

        public bool IsActive
        {
            get { return day.IsActive; }
        }

        public bool IsToday
        {
            get { return day.IsToday; }
        }

        #endregion
    }
}
