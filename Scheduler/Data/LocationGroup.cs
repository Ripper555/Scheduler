using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empemont
{
    public class LocationGroup : Location
    {
        #region private fields

        private readonly List<Location> childLocations;

        #endregion

        #region constructors

        public LocationGroup(string title, int locationCode)
            : base(title, locationCode)
        {
            childLocations = new List<Location>();
        }

        #endregion

        #region public methods

        public override Location Clone()
        {
            LocationGroup groups = new LocationGroup(Title, LocationCode);
            foreach (Location location in childLocations)
                groups.ChildLocations.Add(location.Clone());
            return groups;
        }

        #endregion

        #region public properties

        public override Nullable<bool> Enabled
        {
            get
            {
                Nullable<bool> enabled = null;
                foreach (Location location in childLocations)
                {
                    Nullable<bool> childEnabled = location.Enabled;
                    if (((enabled != null) && (childEnabled != enabled)) ||
                        (childEnabled == null))
                        return null;
                    enabled = childEnabled;
                }
                if (enabled != null)
                    return enabled;
                return false;
            }
            set
            {
                if (Enabled != value)
                {
                    foreach (Location location in childLocations)
                        location.Enabled = value;
                    NotifyPropertyChanged("Enabled");
                }
            }
        }

        public override List<Location> ChildLocations
        {
            get { return childLocations; }
        }

        #endregion
    }
}
