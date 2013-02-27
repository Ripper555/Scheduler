using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthDayHeaderViewModelTest and is intended
    ///to contain all SchedulerMonthDayHeaderViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthDayHeaderViewModelTest : PropertyChangedTest
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
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(dayNotify, day);

            Assert.IsNull(dayNotify.Day, "Day should be null.");

            ICommand command = target.ClickHeaderCommand;
            command.Execute(null);

            Assert.IsNotNull(dayNotify.Day, "Day should be assigned.");
            Assert.AreEqual(date, dayNotify.Day.Date, "Date should be 1/1/2010.");
        }

        /// <summary>
        ///A test for CanClickHeader
        ///</summary>
        [TestMethod()]
        public void CanClickHeaderTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerMonthDayHeaderViewModel_Accessor target = new SchedulerMonthDayHeaderViewModel_Accessor(null, day);

            Assert.IsTrue(target.CanClickHeader, "Should be able to click header.");

            day.SetDate(date, date.AddDays(1), date.AddDays(2));

            Assert.IsFalse(target.CanClickHeader, "Should not be able to click header.");
        }

        /// <summary>
        ///A test for ClickHeaderCommand
        ///</summary>
        [TestMethod()]
        public void ClickHeaderCommandTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(null, day);
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
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(null, day);

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
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(null, day);

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
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(null, day);

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
        ///A test for Month
        ///</summary>
        [TestMethod()]
        public void MonthTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerMonthDayHeaderViewModel target = new SchedulerMonthDayHeaderViewModel(null, day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetDate(date.AddDays(-1));
                Assert.IsTrue(NotifiedProperties.Contains("Month"), "PropertyChanged event wasn't raised on property 'Month' changing to December.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
