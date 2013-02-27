using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public abstract class SchedulerBaseModel : BaseModel, ISchedulerBaseModel
    {
        #region protected fields

        protected readonly SchedulerDisplayInfo displayInfo;
        protected DateTime displayedDateFrom;
        protected DateTime displayedDateTo;

        #endregion

        #region constructors

        public SchedulerBaseModel(SchedulerDisplayInfo displayInfo)
        {
            this.displayInfo = displayInfo;
        }

        #endregion

        #region protected methods

        protected abstract void GetDateRange(DateTime date, out DateTime from, out DateTime to);

        protected DateTime FirstDayOfWeek(DateTime date)
        {
            // minus ((week - firstDay) mod 7)
            // ex.   week = Saturday = 6;                    week = Sunday = 0
            //       first week = Monday = 1;                first week = Monday = 1
            //       week difference = (6 - 1) + 7 = 12;     week difference = (0 - 1) + 7 = 6;
            //       days remove = 12 % 7 = 5;              days remove = 6 % 7 = 6;
            return date.AddDays(-((((int)date.DayOfWeek - (int)displayInfo.FirstDayOfWeek) + 7) % 7));
        }

        protected DateTime MondayOfWeek(DateTime date)
        {
            // minus ((week - monday) mod 7)
            // ex.   week = Saturday = 6;
            //       first week = Monday = 1;
            //       week difference = (6 - 1) + 7 = 12;
            //       days remove = 12 % 7 = 5;
            return date.AddDays(-((((int)date.DayOfWeek - (int)DayOfWeek.Monday) + 7) % 7));
        }

        #endregion

        #region public methods

        public void SetDisplayedDates(DateTime from, DateTime to)
        {
            lock (this)
            {
                DateTime dateFrom = from.Date;
                DateTime dateTo = to.Date;
                if ((displayedDateFrom != dateFrom) || (displayedDateTo != dateTo))
                {
                    displayedDateFrom = dateFrom;
                    displayedDateTo = dateTo;
                }
            }
        }

        public abstract void SetDate(DateTime date);
        public abstract void SetDate(DateTime date, DateTime from, DateTime to);

        public abstract void SetSelectedDate(DateTime selected);
        public abstract void SetToday(DateTime today);

        #endregion

        #region public properties

        public SchedulerDisplayInfo DisplayInfo
        {
            get { return displayInfo; }
        }

        public DateTime From
        {
            get { return displayedDateFrom; }
        }

        public DateTime To
        {
            get { return displayedDateTo; }
        }

        #endregion
    }
}
