using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerMonthViewModel : SchedulerBaseSubViewModel
    {
        #region private fields

        private ISchedulerMonthModel month;

        private ObservableCollection<SchedulerBaseElementViewModel> elements;

        #endregion

        #region constructors

        public SchedulerMonthViewModel(ISchedulerHolder scheduler, IEnumerable<Occurrence> occurrences)
            : base(scheduler, occurrences) { }

        #endregion

        #region private methods - Element's ViewModels

        private void InitWeekNumberCells(List<SchedulerBaseElementViewModel> elementList)
        {
            int row = 2;
            foreach (SchedulerWeekModel week in month.Weeks)
            {
                SchedulerMonthWeekHeaderViewModel header = new SchedulerMonthWeekHeaderViewModel(scheduler, week);
                header.Row = row;
                elementList.Add(header);
                row += 2;
            }
        }

        private void InitDayOfWeekCells(List<SchedulerBaseElementViewModel> elementList)
        {
            int col = 1;
            foreach (SchedulerDayModel day in month.Weeks[0].Days)
            {
                SchedulerMonthDayNameHeaderViewModel header = new SchedulerMonthDayNameHeaderViewModel(day);
                header.Column = col;
                elementList.Add(header);
                col += 1;
            }
        }

        private void InitDayCells(List<SchedulerBaseElementViewModel> elementList)
        {
            int row = 1;
            foreach (SchedulerWeekModel week in month.Weeks)
            {
                int col = 1;
                foreach (SchedulerDayModel day in week.Days)
                {
                    SchedulerMonthDayHeaderViewModel header = new SchedulerMonthDayHeaderViewModel(scheduler, day);
                    header.Column = col;
                    header.Row = row;
                    elementList.Add(header);

                    SchedulerMonthDayBodyViewModel body = new SchedulerMonthDayBodyViewModel(day);
                    body.Column = col;
                    body.Row = row + 1;
                    elementList.Add(body);

                    col += 1;
                }
                row += 2;
            }
        }

        #endregion

        #region override methods

        protected override void InitializeModel(DateTime date)
        {
            month = new SchedulerMonthModel(scheduler.DisplayInfo, date);
            month.SetDate(date);
            SetModel(month, "DisplayedWeeks");
        }

        protected override void CreateElements()
        {
            List<SchedulerBaseElementViewModel> elementList = new List<SchedulerBaseElementViewModel>();

            InitWeekNumberCells(elementList);
            InitDayOfWeekCells(elementList);
            InitDayCells(elementList);

            elements = new ObservableCollection<SchedulerBaseElementViewModel>(elementList);
        }

        protected override void SetDisplayedDateCaption()
        {
            scheduler.SetDisplayedDate(month.From.ToString("Y", scheduler.DisplayInfo.Culture));
        }

        protected override void SetViewDate(DateTime date)
        {
            if ((date < month.From) || (date > month.To))
                month.SetDate(date);
        }

        protected override DateTime GetNextViewDate(DateTime date)
        {
            return date.AddMonths(1);
        }

        protected override DateTime GetPreviousViewDate(DateTime date)
        {
            return date.AddMonths(-1);
        }

        public override void SetToday(DateTime today)
        {
            month.SetToday(today);
        }

        #endregion

        #region public properties

        public int DisplayedWeeks
        {
            get { return month.DisplayedWeeks; }
        }

        public ObservableCollection<SchedulerBaseElementViewModel> Elements
        {
            get { return elements; }
        }

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (SchedulerBaseElementViewModel element in elements)
                    element.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}