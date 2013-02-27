using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empemont
{
    public abstract class Location : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private fields

        private readonly string title;
        private readonly int locationCode;

        #endregion

        #region constructors

        public Location(string title, int locationCode)
        {
            this.title = title;
            this.locationCode = locationCode;
        }

        #endregion

        #region protected methods

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventHandler propertyChanged = PropertyChanged;
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region public methods

        public abstract Location Clone();

        #endregion

        #region public properties

        public string Title
        {
            get { return title; }
        }

        public int LocationCode
        {
            get { return locationCode; }
        }

        public abstract Nullable<bool> Enabled { get; set; }

        public virtual List<Location> ChildLocations
        {
            get { return null; }
        }

        #endregion
    }
}
