using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerBaseDayViewModel : SchedulerBaseElementViewModel
    {
        #region protected fields

        protected readonly ISchedulerDayModel day;

        #endregion

        #region construtors

        public SchedulerBaseDayViewModel(ISchedulerDayModel day)
        {
            this.day = day;
        }

        #endregion
    }
}
