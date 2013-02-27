using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerDayHeaderViewModelTest and is intended
    ///to contain all SchedulerDayHeaderViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerDayHeaderViewModelTest : PropertyChangedTest
    {
        #region TestContext

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region Click header command

        private class DaySelected : IDaySelected
        {
            private ISchedulerDayModel day;

            public ISchedulerDayModel Day
            {
                get { return day; }
            }

            #region IDaySelected Members

            public void SelectDay(ISchedulerDayModel day)
            {
                this.day = day;
            }

            #endregion
        }

        /// <summary>
        ///A test for ClickHeader
        ///</summary>
        [TestMethod()]
        public void ClickHeaderTest()
        {
            DaySelected dayNotify = new DaySelected();
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(dayNotify, day);

            Assert.IsNull(dayNotify.Day, "Day should be null.");

            ICommand command = target.ClickHeaderCommand;
            command.Execute(null);

            Assert.IsNotNull(dayNotify.Day, "Day should be assigned.");
            Assert.AreEqual(date, dayNotify.Day.Date, "Date should be 1/1/2010.");
        }

        /// <summary>
        ///A test for ClickHeaderCommand
        ///</summary>
        [TestMethod()]
        public void ClickHeaderCommandTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(null, day);
            Assert.IsInstanceOfType(target.ClickHeaderCommand, typeof(ICommand), "ClickHeaderCommand should return ICommand object.");
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        ///A test for Date
        ///</summary>
        [TestMethod()]
        public void DateTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(null, day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetDate(date.AddDays(-1));
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 12/31/2009.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for IsToday
        ///</summary>
        [TestMethod()]
        public void IsTodayTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(null, day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetToday(date.AddDays(-1));
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to false.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for IsActive
        ///</summary>
        [TestMethod()]
        public void IsActiveTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(null, day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetDate(date.AddDays(-1), date, date);
                Assert.IsTrue(NotifiedProperties.Contains("IsActive"), "PropertyChanged event wasn't raised on property 'IsActive' changing to false.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for DayOfWeek
        ///</summary>
        [TestMethod()]
        public void DayOfWeekTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayHeaderViewModel target = new SchedulerDayHeaderViewModel(null, day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetDate(date.AddDays(-1), date, date);
                Assert.IsTrue(NotifiedProperties.Contains("DayOfWeek"), "PropertyChanged event wasn't raised on property 'DayOfWeek' changing to Thursday.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
