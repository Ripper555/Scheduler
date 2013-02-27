using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerDayModel : SchedulerBaseModel, ISchedulerDayModel
    {
        #region private fields

        private DateTime date;
        private DateTime today;
        private DateTime selectedDate;

        private bool isToday;
        private bool isActive;
        private bool isSelected;
        private DayOfWeek dayOfWeek;
        private string month;

        private Category category;
        private List<Occurrence> dayOccurrences;

        #endregion

        #region constructors

        public SchedulerDayModel(SchedulerDisplayInfo displayInfo, DateTime today)
            : base(displayInfo)
        {
            this.today = today.Date;
        }

        #endregion

        #region private methods

        private void AnyDateChanged()
        {
            if (date.DayOfWeek != dayOfWeek)
            {
                dayOfWeek = date.DayOfWeek;
                NotifyPropertyChanged("DayOfWeek");
            }

            if ((date == today) != isToday)
            {
                isToday = (date == today);
                NotifyPropertyChanged("IsToday");
            }

            bool inRange = (date >= displayedDateFrom) && (date <= displayedDateTo);
            if (isActive != inRange)
            {
                isActive = inRange;
                NotifyPropertyChanged("IsActive");
            }

            if ((date == selectedDate) != isSelected)
            {
                isSelected = (date == selectedDate);
                NotifyPropertyChanged("IsSelected");
            }

            string month = date.ToString("MMMM", displayInfo.Culture);
            if (string.Compare(this.month, month) != 0)
            {
                this.month = month;
                NotifyPropertyChanged("Month");
            }
        }

        #endregion

        #region protected methods

        protected override void GetDateRange(DateTime date, out DateTime from, out DateTime to)
        {
            from = date;
            to = date;
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
            if (this.date.CompareTo(date.Date) != 0)
            {
                this.date = date.Date;
                NotifyPropertyChanged("Date");
            }
            AnyDateChanged();
        }

        public override void SetSelectedDate(DateTime selected)
        {
            DateTime selectedDate = selected.Date;
            if (this.selectedDate != selectedDate)
            {
                this.selectedDate = selectedDate;
                AnyDateChanged();
            }
        }

        public override void SetToday(DateTime today)
        {
            DateTime dateToday = today.Date;
            if (this.today != dateToday)
            {
                this.today = dateToday;
                AnyDateChanged();
            }
        }

        #endregion

        #region public properties

        public DateTime Date
        {
            get { return date; }
        }

        public bool IsToday
        {
            get { return isToday; }
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        public bool IsSelected
        {
            get { return isSelected; }
        }

        public string DayOfWeek
        {
            get { return date.ToString("dddd", displayInfo.Culture); }
        }

        public string Month
        {
            get { return month; }
        }

        public Category Category
        {
            get { return category; }
        }

        public List<Occurrence> DayOccurrences
        {
            get
            {
                if (dayOccurrences == null)
                    dayOccurrences = new List<Occurrence>();
                return dayOccurrences;
            }
        }

        #endregion
    }
}
