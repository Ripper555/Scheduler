using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerWeekModel : SchedulerBaseModel, ISchedulerWeekModel
    {
        #region private fields

        private readonly DisplayedDays displayedDays;

        private int week;
        private SchedulerDayModel[] days;

        #endregion

        #region constructors

        public SchedulerWeekModel(SchedulerDisplayInfo displayInfo, DateTime today, DisplayedDays displayedDays)
            : base(displayInfo)
        {
            this.displayedDays = displayedDays;

            days = new SchedulerDayModel[(int)displayedDays];
            for (int i = 0; i < days.Length; i++)
                days[i] = new SchedulerDayModel(displayInfo, today);
        }

        #endregion

        #region protected methods

        protected override void GetDateRange(DateTime date, out DateTime from, out DateTime to)
        {
            from = to = date;
            switch (displayedDays)
            {
                case DisplayedDays.WorkWeek:
                    from = MondayOfWeek(date);
                    to = from.AddDays((int)displayedDays - 1);
                    break;
                case DisplayedDays.Week:
                    from = FirstDayOfWeek(date);
                    to = from.AddDays((int)displayedDays - 1);
                    break;
            }
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

            Week = displayInfo.Culture.Calendar.GetWeekOfYear(date, displayInfo.CalendarWeekRule, displayInfo.FirstDayOfWeek);
            DateTime firstDay;
            switch (displayedDays)
            {
                case DisplayedDays.Day:
                    days[0].SetDate(date, from, to);
                    break;
                case DisplayedDays.WorkWeek:
                    firstDay = MondayOfWeek(date);
                    for (int i = 0; i < days.Length; i++)
                        days[i].SetDate(firstDay.AddDays(i), from, to);
                    break;
                case DisplayedDays.Week:
                    firstDay = FirstDayOfWeek(date);
                    for (int i = 0; i < days.Length; i++)
                        days[i].SetDate(firstDay.AddDays(i), from, to);
                    break;
            }
        }

        public override void SetSelectedDate(DateTime selected)
        {
            foreach (SchedulerDayModel day in days)
                day.SetSelectedDate(selected);
        }

        public override void SetToday(DateTime today)
        {
            foreach (SchedulerDayModel day in days)
                day.SetToday(today);
        }

        #endregion

        #region public properties

        public int Week
        {
            get { return week; }
            set
            {
                if (week != value)
                {
                    week = value;
                    NotifyPropertyChanged("Week");
                }
            }
        }

        public SchedulerDayModel[] Days
        {
            get { return days; }
        }

        public DisplayedDays DisplayedDays
        {
            get { return displayedDays; }
        }

        #endregion
    }
}
