using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerMonthDayHeaderViewModel : SchedulerBaseDayViewModel
    {
        #region private fields

        private readonly IDaySelected daySelected;
        private ICommand clickHeaderCommand;

        #endregion

        #region construtors

        public SchedulerMonthDayHeaderViewModel(IDaySelected daySelected, ISchedulerDayModel day)
            : base(day)
        {
            this.daySelected = daySelected;
            SetModel(day, "Date", "IsToday", "IsActive", "Month");
        }

        #endregion

        #region private methods - click header command

        private void ClickHeader()
        {
            if (daySelected != null)
            {
                daySelected.SelectDay(day);
            }
        }

        private bool CanClickHeader
        {
            get { return day.IsActive; }
        }

        #endregion

        #region public properties

        public DateTime Date
        {
            get { return day.Date; }
        }

        public bool IsToday
        {
            get { return day.IsToday; }
        }

        public bool IsActive
        {
            get { return day.IsActive; }
        }

        public string Month
        {
            get { return day.Month; }
        }

        public ICommand ClickHeaderCommand
        {
            get
            {
                if (clickHeaderCommand == null)
                    clickHeaderCommand = new BaseCommand(param => ClickHeader(), param => CanClickHeader);
                return clickHeaderCommand;
            }
        }

        #endregion
    }
}
