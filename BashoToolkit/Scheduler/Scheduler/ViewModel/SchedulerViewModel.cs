using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Timers;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerViewModel : BaseModel, ISchedulerHolder
    {
        #region private fields

        private readonly IEnumerable<Occurrence> occurrences;

        private readonly SchedulerDisplayInfo displayInfo;
        private string displayedDate;
        private DisplayMode displayMode = DisplayMode.Unspecified;
        private DateTime selectedDate;
        private DateTime today;
        private DateTime now;

        private SchedulerBaseSubViewModel viewModel;
        private SchedulerBaseSubViewModel[] viewModels;

        private BaseCommand dayCommand;
        private BaseCommand workWeekCommand;
        private BaseCommand weekCommand;
        private BaseCommand monthCommand;

        private BaseCommand previousCommand;
        private BaseCommand nextCommand;

        protected readonly Timer timer;

        #endregion

        #region constructors

        public SchedulerViewModel(IEnumerable<Occurrence> occurrences, CultureInfo cultureInfo)
            : this(occurrences, cultureInfo, true, true) { }

        public SchedulerViewModel(IEnumerable<Occurrence> occurrences, CultureInfo cultureInfo, bool initializeViewModel, bool initilizeTimer)
        {
            this.occurrences = occurrences;

            displayInfo = new SchedulerDisplayInfo(cultureInfo);

            if (initializeViewModel)
            {
                SetNowAndToday();
                selectedDate = today;
                InitializeViewModel(DisplayMode.Week, today);
            }

            if (initilizeTimer)
            {
                timer = new Timer(60000); // each minute
                timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
                timer.Start();
            }
        }

        #endregion

        #region private methods - today's timer

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (this)
            {
                SetNowAndToday();
            }
        }

        private void SetNowAndToday()
        {
            DateTime nowTime = DateTime.Now;
            now = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, 0);
            DateTime todayDate = now.Date;
            if (today != todayDate)
            {
                today = todayDate;

                for (int i = 0; i < ViewModels.Length; i++)
                    if (ViewModels[i] != null)
                        ViewModels[i].SetToday(today);
            }
        }

        #endregion

        #region private methods - commands

        private void DisplayDay()
        {
            InitializeViewModel(DisplayMode.Day);
        }

        private bool CanDisplayDay
        {
            get { return true; }
        }

        private void DisplayWorkWeek()
        {
            InitializeViewModel(DisplayMode.WorkWeek);
        }

        private bool CanDisplayWorkWeek
        {
            get { return true; }
        }

        private void DisplayWeek()
        {
            InitializeViewModel(DisplayMode.Week);
        }

        private bool CanDisplayWeek
        {
            get { return true; }
        }

        private void DisplayMonth()
        {
            InitializeViewModel(DisplayMode.Month);
        }

        private bool CanDisplayMonth
        {
            get { return true; }
        }

        private void DisplayPrevious()
        {
            if (viewModel != null)
                viewModel.PreviousView();
        }

        private bool CanDisplayPrevious
        {
            get { return true; }
        }

        private void DisplayNext()
        {
            if (viewModel != null)
                viewModel.NextView();
        }

        private bool CanDisplayNext
        {
            get { return true; }
        }

        #endregion

        #region private methods - SubViewModels

        private SchedulerBaseSubViewModel[] ViewModels
        {
            get
            {
                if (viewModels == null)
                    viewModels = new SchedulerBaseSubViewModel[Enum.GetValues(typeof(DisplayMode)).Length];
                return viewModels;
            }
        }

        private void CreateViewModel(DisplayMode displayMode, DateTime date)
        {
            lock (this)
            {
                switch (displayMode)
                {
                    case DisplayMode.Day:
                        ViewModels[(int)displayMode] = new SchedulerWeekViewModel(this, occurrences, DisplayedDays.Day);
                        break;
                    case DisplayMode.WorkWeek:
                        ViewModels[(int)displayMode] = new SchedulerWeekViewModel(this, occurrences, DisplayedDays.WorkWeek);
                        break;
                    case DisplayMode.Week:
                        ViewModels[(int)displayMode] = new SchedulerWeekViewModel(this, occurrences, DisplayedDays.Week);
                        break;
                    case DisplayMode.Month:
                        ViewModels[(int)displayMode] = new SchedulerMonthViewModel(this, occurrences);
                        break;
                }
                if (ViewModels[(int)displayMode] != null)
                    ViewModels[(int)displayMode].Initialize(date);
            }
        }

        private void InitializeViewModel(DisplayMode displayMode, DateTime date)
        {
            if (displayMode == DisplayMode.Unspecified)
                return;

            if (this.displayMode != displayMode)
            {
                this.displayMode = displayMode;

                CreateViewModel(displayMode, today);
                ViewModel = ViewModels[(int)displayMode];
            }
            ViewModels[(int)displayMode].SetView(date);
        }

        private void InitializeViewModel(DisplayMode displayMode)
        {
            InitializeViewModel(displayMode, selectedDate);
        }

        #endregion

        #region public properties

        public SchedulerBaseSubViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel != value)
                {
                    viewModel = value;
                    NotifyPropertyChanged("ViewModel");
                }
            }
        }

        public string DisplayedDate
        {
            get { return displayedDate; }
        }

        public ICommand DayCommand
        {
            get
            {
                if (dayCommand == null)
                    dayCommand = new BaseCommand(param => this.DisplayDay(), param => this.CanDisplayDay);
                return dayCommand;
            }
        }

        public ICommand WorkWeekCommand
        {
            get
            {
                if (workWeekCommand == null)
                    workWeekCommand = new BaseCommand(param => this.DisplayWorkWeek(), param => this.CanDisplayWorkWeek);
                return workWeekCommand;
            }
        }

        public ICommand WeekCommand
        {
            get
            {
                if (weekCommand == null)
                    weekCommand = new BaseCommand(param => this.DisplayWeek(), param => this.CanDisplayWeek);
                return weekCommand;
            }
        }

        public ICommand MonthCommand
        {
            get
            {
                if (monthCommand == null)
                    monthCommand = new BaseCommand(param => this.DisplayMonth(), param => this.CanDisplayMonth);
                return monthCommand;
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                if (previousCommand == null)
                    previousCommand = new BaseCommand(param => this.DisplayPrevious(), param => this.CanDisplayPrevious);
                return previousCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (nextCommand == null)
                    nextCommand = new BaseCommand(param => this.DisplayNext(), param => this.CanDisplayNext);
                return nextCommand;
            }
        }

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Stop();
                timer.Dispose();

                foreach (SchedulerBaseSubViewModel viewModel in ViewModels)
                    viewModel.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region IDaySelected Members

        public void SelectDay(ISchedulerDayModel day)
        {
            if (day == null)
                throw new ArgumentNullException("day");
            InitializeViewModel(DisplayMode.Day, day.Date);
        }

        #endregion

        #region IWeekSelected Members

        public void SelectWeek(ISchedulerWeekModel week)
        {
            if (week == null)
                throw new ArgumentNullException("week");
            InitializeViewModel(DisplayMode.Week, week.Days[0].Date);
        }

        #endregion

        #region ISchedulerHolder Members

        public SchedulerDisplayInfo DisplayInfo
        {
            get { return displayInfo; }
        }

        public void SetDisplayedDate(string caption)
        {
            if (string.Compare(displayedDate, caption) != 0)
            {
                displayedDate = caption;
                NotifyPropertyChanged("DisplayedDate");
            }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; }
        }

        #endregion
    }
}
