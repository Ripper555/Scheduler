using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    sealed public class SchedulerDisplayInfo : BaseModel, ISchedulerDisplayInfo
    {
        #region private fields

        private readonly CultureInfo culture;
        private DayOfWeek firstDayOfWeek;
        private CalendarWeekRule calendarWeekRule;
        private readonly bool[] workingDays;
        private TimeSpan workingHoursFrom;
        private TimeSpan workingHoursTo;

        #endregion

        #region contructors

        public SchedulerDisplayInfo(CultureInfo culture)
        {
            this.culture = culture;
            firstDayOfWeek = DayOfWeek.Monday;
            calendarWeekRule = CalendarWeekRule.FirstDay;

            workingDays = new bool[7];
            for(int i=0;i<7;i++)
                workingDays[i] = ((DayOfWeek)i != DayOfWeek.Saturday) && ((DayOfWeek)i != DayOfWeek.Sunday);
            workingHoursFrom = new TimeSpan(8, 0, 0);
            workingHoursTo = new TimeSpan(17, 0, 0);
        }

        #endregion

        #region public properties

        public CultureInfo Culture
        {
            get { return culture; }
        }

        public DayOfWeek FirstDayOfWeek
        {
            get { return firstDayOfWeek; }
            set
            {
                if (firstDayOfWeek != value)
                {
                    firstDayOfWeek = value;
                    NotifyPropertyChanged("FirstDayOfWeek");
                }
            }
        }

        public CalendarWeekRule CalendarWeekRule
        {
            get { return calendarWeekRule; }
            set
            {
                if (calendarWeekRule != value)
                {
                    calendarWeekRule = value;
                    NotifyPropertyChanged("CalendarWeekRule");
                }
            }
        }

        public bool[] WorkingDays
        {
            get { return workingDays; }
        }

        public TimeSpan WorkingHoursFrom
        {
            get { return workingHoursFrom; }
            set
            {
                if ((workingHoursFrom != value) && (value >= new TimeSpan(0, 0, 0)) && (value <= workingHoursTo))
                {
                    workingHoursFrom = value;
                    NotifyPropertyChanged("WorkingHoursFrom");
                }
            }
        }

        public TimeSpan WorkingHoursTo
        {
            get { return workingHoursTo; }
            set
            {
                if ((workingHoursTo != value) && (value <= new TimeSpan(24, 0, 0)) && (value >= workingHoursFrom))
                {
                    workingHoursTo = value;
                    NotifyPropertyChanged("WorkingHoursTo");
                }
            }
        }

        #endregion
    }
}
