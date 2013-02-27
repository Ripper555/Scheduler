using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerWeekViewModel : SchedulerBaseSubViewModel
    {
        #region private fields

        private ISchedulerWeekModel week;

        private DisplayedDays displayedDays;
        private int movingDays;

        private double topDisplayedHour;

        private ObservableCollection<SchedulerBaseElementViewModel> headerElements;
        private ObservableCollection<SchedulerBaseElementViewModel> bodyElements;
        private ObservableCollection<SchedulerBaseElementViewModel> borderElements;

        #endregion

        #region constructors

        public SchedulerWeekViewModel(ISchedulerHolder scheduler, IEnumerable<Occurrence> occurrences, DisplayedDays displayedDays)
            : base(scheduler, occurrences)
        {
            this.displayedDays = displayedDays;

            movingDays = 1;
            switch (displayedDays)
            {
                case DisplayedDays.WorkWeek:
                case DisplayedDays.Week:
                    movingDays = 7;
                    break;
            }
        }

        #endregion

        #region private methods - Element's ViewModels

        private void InitDayHeaderCells(List<SchedulerBaseElementViewModel> headerList)
        {
            int col = 1;
            foreach (SchedulerDayModel day in week.Days)
            {
                SchedulerDayHeaderViewModel header = new SchedulerDayHeaderViewModel(scheduler, day);
                header.Column = col;
                headerList.Add(header);
                col += 1;
            }
        }

        private void InitAllDayBodyCells(List<SchedulerBaseElementViewModel> headerList)
        {
            int col = 1;
            foreach (SchedulerDayModel day in week.Days)
            {
                SchedulerAllDayBodyViewModel body = new SchedulerAllDayBodyViewModel(day);
                body.Column = col;
                body.Row = 1;
                headerList.Add(body);
                col += 1;
            }
        }

        private void InitHourHeaderCells(List<SchedulerBaseElementViewModel> bodyList, List<SchedulerBaseElementViewModel> borderList)
        {
            SchedulerDayHourHeaderViewModel header = new SchedulerDayHourHeaderViewModel();
            bodyList.Add(header);
            SchedulerDayHourHeaderBorderViewModel border = new SchedulerDayHourHeaderBorderViewModel();
            borderList.Add(border);
        }

        private void InitDayBodyCells(List<SchedulerBaseElementViewModel> bodyList, List<SchedulerBaseElementViewModel> borderList)
        {
            int col = 1;
            foreach (SchedulerDayModel day in week.Days)
            {
                SchedulerDayBodyViewModel body = new SchedulerDayBodyViewModel(day);
                body.Column = col;
                bodyList.Add(body);

                SchedulerDayBodyBorderViewModel border = new SchedulerDayBodyBorderViewModel(day);
                border.Column = col;
                borderList.Add(border);

                col += 1;
            }
            //viewerBody.ScrollToVerticalOffset(48 * week.DisplayInfo.WorkingHoursFrom.TotalHours);
            topDisplayedHour = week.DisplayInfo.WorkingHoursFrom.TotalHours;
        }

        #endregion

        #region override methods

        protected override void InitializeModel(DateTime date)
        {
            week = new SchedulerWeekModel(scheduler.DisplayInfo, date, displayedDays);
            week.SetDate(date);
            SetModel(week, "DisplayedDays");
        }

        protected override void CreateElements()
        {
            List<SchedulerBaseElementViewModel> headerList = new List<SchedulerBaseElementViewModel>();
            List<SchedulerBaseElementViewModel> bodyList = new List<SchedulerBaseElementViewModel>();
            List<SchedulerBaseElementViewModel> borderList = new List<SchedulerBaseElementViewModel>();

            InitDayHeaderCells(headerList);
            InitAllDayBodyCells(headerList);
            InitHourHeaderCells(bodyList, borderList);
            InitDayBodyCells(bodyList, borderList);

            headerElements = new ObservableCollection<SchedulerBaseElementViewModel>(headerList);
            bodyElements = new ObservableCollection<SchedulerBaseElementViewModel>(bodyList);
            borderElements = new ObservableCollection<SchedulerBaseElementViewModel>(borderList);
        }

        protected override void SetDisplayedDateCaption()
        {
            switch (displayedDays)
            {
                case DisplayedDays.Day:
                    scheduler.SetDisplayedDate(week.Days[0].Date.ToString("D", scheduler.DisplayInfo.Culture));
                    break;
                default:
                    scheduler.SetDisplayedDate(week.Days[0].Date.ToString("D", scheduler.DisplayInfo.Culture) + " - " +
                        week.Days[week.Days.Length - 1].Date.ToString("D", scheduler.DisplayInfo.Culture));
                    break;
            }
        }

        protected override void SetViewDate(DateTime date)
        {
            if ((date < week.Days[0].Date) || (date > week.Days[week.Days.Length - 1].Date))
                week.SetDate(date);
        }

        protected override DateTime GetNextViewDate(DateTime date)
        {
            return date.AddDays(movingDays);
        }

        protected override DateTime GetPreviousViewDate(DateTime date)
        {
            return date.AddDays(-movingDays);
        }

        public override void SetToday(DateTime today)
        {
            week.SetToday(today);
        }

        #endregion

        #region public properties

        public DisplayedDays DisplayedDays
        {
            get { return week.DisplayedDays; }
        }

        public double TopDisplayedHour
        {
            get { return topDisplayedHour; }
        }

        public ObservableCollection<SchedulerBaseElementViewModel> HeaderElements
        {
            get { return headerElements; }
        }

        public ObservableCollection<SchedulerBaseElementViewModel> BodyElements
        {
            get { return bodyElements; }
        }

        public ObservableCollection<SchedulerBaseElementViewModel> BorderElements
        {
            get { return borderElements; }
        }

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (SchedulerBaseElementViewModel element in headerElements)
                    element.Dispose();
                headerElements.Clear();
                foreach (SchedulerBaseElementViewModel element in bodyElements)
                    element.Dispose();
                bodyElements.Clear();
                foreach (SchedulerBaseElementViewModel element in borderElements)
                    element.Dispose();
                borderElements.Clear();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}