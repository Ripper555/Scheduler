using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerAllDayBodyViewModel : SchedulerBaseDayViewModel
    {
        #region construtors

        public SchedulerAllDayBodyViewModel(ISchedulerDayModel day)
            : base(day)
        {
            SetModel(day, "IsToday", "IsActive", "Category");
        }

        #endregion

        #region public properties

        public bool IsToday
        {
            get { return day.IsToday; }
        }

        public bool IsActive
        {
            get { return day.IsActive; }
        }

        public Category Category
        {
            get { return day.Category; }
        }

        #endregion
    }
}
