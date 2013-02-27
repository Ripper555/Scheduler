using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerDayBodyViewModel : SchedulerBaseDayViewModel
    {
        #region construtors

        public SchedulerDayBodyViewModel(ISchedulerDayModel day)
            : base(day)
        {
            SetModel(day, "Date", "Category");
        }

        #endregion

        #region public properties

        public SchedulerDisplayInfo DisplayInfo
        {
            get { return day.DisplayInfo; }
        }

        public DateTime Date
        {
            get { return day.Date; }
        }

        public Category Category
        {
            get { return day.Category; }
        }

        #endregion
    }
}
