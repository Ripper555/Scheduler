using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using Basho.Toolkit.Scheduler;

namespace Empemont
{
    public class Broadcast : Occurrence
    {
        #region private fields

        private readonly ObservableCollection<Track> tracks;
        private readonly Location locations;

        #endregion

        #region constructors

        public Broadcast(Location locations)
            : base()
        {
            tracks = new ObservableCollection<Track>();
            this.locations = locations.Clone();
        }

        #endregion

        #region public properties

        public ObservableCollection<Track> Tracks
        {
            get { return tracks; }
        }

        public IList<Location> Locations
        {
            get { return locations.ChildLocations; }
        }

        #endregion
    }
}
