using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Basho.Toolkit.Scheduler
{
    public abstract class SchedulerBaseSubViewModel: SchedulerBaseViewModel
    {
        #region protected fields

        protected readonly ISchedulerHolder scheduler;
        protected readonly IEnumerable<Occurrence> occurrences;

        #endregion

        #region construtors

        public SchedulerBaseSubViewModel(ISchedulerHolder scheduler, IEnumerable<Occurrence> occurrences)
        {
            this.scheduler = scheduler;
            this.occurrences = occurrences;
        }

        #endregion

        #region abstract and virtual methods

        protected abstract void InitializeModel(DateTime date);

        protected abstract void CreateElements();

        protected abstract void SetDisplayedDateCaption();

        protected abstract void SetViewDate(DateTime date);

        protected abstract DateTime GetNextViewDate(DateTime date);

        protected abstract DateTime GetPreviousViewDate(DateTime date);

        public abstract void SetToday(DateTime today);

        #endregion

        #region public methods

        public void Initialize(DateTime date)
        {
            InitializeModel(date);
            CreateElements();
        }

        public void SetView(DateTime date)
        {
            SetViewDate(date);
            scheduler.SelectedDate = date;
            SetDisplayedDateCaption();
        }

        public void NextView()
        {
            scheduler.SelectedDate = GetNextViewDate(scheduler.SelectedDate);
            SetView(scheduler.SelectedDate);
        }

        public void PreviousView()
        {
            scheduler.SelectedDate = GetPreviousViewDate(scheduler.SelectedDate);
            SetView(scheduler.SelectedDate);
        }

        #endregion
    }
}