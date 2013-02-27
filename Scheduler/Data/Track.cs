using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Windows.Media;

namespace Empemont
{
    public class Track : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region private fields

        private readonly string title;
        private readonly TrackType trackType;
        private readonly string trackPath;
        private TimeSpan duration;

        #endregion

        #region constructors

        public Track(string title, TrackType trackType, string trackPath)
            : this(title, trackType, trackPath, TimeSpan.Zero) { }

        public Track(string title, TrackType trackType, string trackPath, TimeSpan duration)
        {
            this.title = title;
            this.trackType = trackType;
            this.trackPath = trackPath;
            if (duration != TimeSpan.Zero)
                this.duration = duration;
            else
            {
                this.duration = TimeSpan.Zero;
                if (File.Exists(trackPath))
                {
                    Thread thread = new Thread(new ThreadStart(GetDuration));
                    thread.Start();
                }
            }
        }

        #endregion

        #region private methods

        private void GetDuration()
        {
            try
            {
                MediaPlayer mp = new MediaPlayer();
                mp.Open(TrackUri);
                int cnt = 0; // protect neverending loop
                while ((!mp.NaturalDuration.HasTimeSpan) && (cnt < 10000))
                    Thread.Sleep(10);
                if (mp.NaturalDuration.HasTimeSpan)
                    duration = mp.NaturalDuration.TimeSpan;
                mp.Close();

                if ((duration != TimeSpan.Zero) && (PropertyChanged != null))
                    PropertyChanged(this, new PropertyChangedEventArgs("Duration"));
            }
            catch { }
        }

        #endregion

        #region public properties

        public string Title
        {
            get { return title; }
        }

        public TrackType TrackType
        {
            get { return trackType; }
        }

        public string TrackPath
        {
            get { return trackPath; }
        }

        public Uri TrackUri
        {
            get { return new Uri(trackPath); }
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }

        #endregion
    }
}
