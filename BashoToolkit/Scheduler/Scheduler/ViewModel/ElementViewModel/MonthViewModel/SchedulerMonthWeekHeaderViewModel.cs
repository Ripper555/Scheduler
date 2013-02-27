using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerMonthWeekHeaderViewModel : SchedulerBaseElementViewModel
    {
        #region private fields

        private readonly ISchedulerWeekModel week;

        private readonly IWeekSelected weekSelected;
        private ICommand clickHeaderCommand;

        #endregion

        #region construtors

        public SchedulerMonthWeekHeaderViewModel(IWeekSelected weekSelected, ISchedulerWeekModel week)
        {
            this.weekSelected = weekSelected;
            this.week = week;
            SetModel(week, "Week");
        }

        #endregion

        #region private methods - click header command

        private void ClickHeader()
        {
            if (weekSelected != null)
            {
                weekSelected.SelectWeek(week);
            }
        }

        #endregion

        #region public properties

        public int Week
        {
            get { return week.Week; }
        }

        public ICommand ClickHeaderCommand
        {
            get
            {
                if (clickHeaderCommand == null)
                    clickHeaderCommand = new BaseCommand(param => ClickHeader());
                return clickHeaderCommand;
            }
        }

        #endregion
    }
}
