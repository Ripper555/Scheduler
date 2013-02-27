using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerMonthModel : SchedulerBaseModel, ISchedulerMonthModel
    {
        #region private fields

        private SchedulerWeekModel[] weeks;
        private int displayedWeeks;

        #endregion

        #region constructors

        public SchedulerMonthModel(SchedulerDisplayInfo displayInfo, DateTime today)
            : base(displayInfo)
        {
            weeks = new SchedulerWeekModel[6];
            for (int i = 0; i < 6; i++)
                weeks[i] = new SchedulerWeekModel(displayInfo, today, DisplayedDays.Week);
       }

        #endregion

        #region protected methods

        protected override void GetDateRange(DateTime date, out DateTime from, out DateTime to)
        {
            from = new DateTime(date.Year, date.Month, 1);
            to = from.AddMonths(1).AddDays(-1);
        }

        #endregion

        #region public methods

        public override void SetDate(DateTime date)
        {
            DateTime from, to;
            GetDateRange(date, out from, out to);
            SetDate(date, from, to);
        }

        public override void SetDate(DateTime date, DateTime from, DateTime to)
        {
            SetDisplayedDates(from, to);

            DateTime firstDay = FirstDayOfWeek(new DateTime(date.Year, date.Month, 1));
            for (int i = 0; i < 6; i++)
                weeks[i].SetDate(firstDay.AddDays(i * 7), from, to);

            int weekCount = 6;
            if (weeks[5].Days[0].Date.Month != date.Month)
                weekCount = 5;
            if (weeks[4].Days[0].Date.Month != date.Month)
                weekCount = 4;
            DisplayedWeeks = weekCount;
        }

        public override void SetSelectedDate(DateTime selected)
        {
            foreach (SchedulerWeekModel week in weeks)
                week.SetSelectedDate(selected);
        }

        public override void SetToday(DateTime today)
        {
            foreach (SchedulerWeekModel week in weeks)
                week.SetToday(today);
        }

        #endregion

        #region public properties

        public SchedulerWeekModel[] Weeks
        {
            get { return weeks; }
        }

        public int DisplayedWeeks
        {
            get { return displayedWeeks; }
            set
            {
                if (displayedWeeks != value)
                {
                    displayedWeeks = value;
                    NotifyPropertyChanged("DisplayedWeeks");
                }
            }
        }

        #endregion
    }
}
