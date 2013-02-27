using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empemont
{
    public class LocationSpeaker : Location
    {
        #region private fields

        private bool enabled;

        #endregion

        #region constructors

        public LocationSpeaker(string title, int locationCode, bool enabled)
            : base(title, locationCode)
        {
            this.enabled = enabled;
        }

        #endregion

        #region public methods

        public override Location Clone()
        {
            return new LocationSpeaker(Title, LocationCode, enabled);
        }

        #endregion

        #region public properties

        public override Nullable<bool> Enabled
        {
            get { return enabled; }
            set
            {
                if ((value != null) && (value != enabled))
                {
                    enabled = (bool)value;
                    NotifyPropertyChanged("Enabled");
                }
            }
        }

        #endregion
    }
}
