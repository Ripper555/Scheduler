using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;

namespace Basho.Toolkit.Scheduler
{
    public class Occurrence : INotifyPropertyChanged, IComparable
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventHandler propertyChanged = PropertyChanged;
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            if (obj is Occurrence)
            {
                Occurrence o2 = obj as Occurrence;
                return startDate.CompareTo(o2.StartDate);
            }
            else
                throw new ArgumentException("Object is not a Event.", "obj");
        }

        #endregion

        #region private fields

        private string title;
        private Category category;
        private Importance importance;
        private DateTime startDate;
        private DateTime endDate;
        private bool allDayEvent;

        #endregion

        #region constructors

        public Occurrence()
        {
            title = string.Empty;
            category = Category.Blue;
            importance = Importance.Normal;
            startDate = DateTime.MinValue;
            endDate = DateTime.MaxValue;
            allDayEvent = false;
        }

        #endregion

        #region protected methods

        protected DateTime RoundToMinutes(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
        }

        public void Shift(TimeSpan time)
        {
            startDate = startDate.AddMinutes(time.TotalMinutes);
            endDate = endDate.AddMinutes(time.TotalMinutes);
            NotifyPropertyChanged("StartDate");
            NotifyPropertyChanged("EndDate");
        }

        #endregion

        #region public properties

        public string Title
        {
            get { return title; }
            set
            {
                if (string.Compare(title, value) != 0)
                {
                    title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public Category Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        public Importance Importance
        {
            get { return importance; }
            set
            {
                if (importance != value)
                {
                    importance = value;
                    NotifyPropertyChanged("Importance");
                }
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                value = RoundToMinutes(value);
                if ((startDate != value) && (value <= endDate))
                {
                    startDate = value;
                    NotifyPropertyChanged("StartDate");
                    NotifyPropertyChanged("Duration");
                }
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                value = RoundToMinutes(value);
                if ((endDate != value) && (startDate <= value))
                {
                    endDate = value;
                    NotifyPropertyChanged("EndDate");
                    NotifyPropertyChanged("Duration");
                }
            }
        }

        public TimeSpan Duration
        {
            get { return endDate - startDate; }
        }

        public bool AllDayEvent
        {
            get { return allDayEvent; }
            set
            {
                if (allDayEvent != value)
                {
                    allDayEvent = value;
                    NotifyPropertyChanged("AllDayEvent");
                }
            }
        }

        #endregion
    }
}
