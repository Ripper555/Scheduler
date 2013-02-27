using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerDayHeaderViewModel : SchedulerBaseDayViewModel
    {
        #region private fields

        private readonly IDaySelected daySelected;
        private ICommand clickHeaderCommand;

        #endregion

        #region construtors

        public SchedulerDayHeaderViewModel(IDaySelected daySelected, ISchedulerDayModel day)
            : base(day)
        {
            this.daySelected = daySelected;
            SetModel(day, "Date", "IsToday", "IsActive", "DayOfWeek");
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

        public string DayOfWeek
        {
            get { return day.DayOfWeek; }
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
