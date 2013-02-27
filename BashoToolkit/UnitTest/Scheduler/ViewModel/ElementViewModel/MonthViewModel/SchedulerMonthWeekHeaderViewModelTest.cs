using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Input;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthWeekHeaderViewModelTest and is intended
    ///to contain all SchedulerMonthWeekHeaderViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthWeekHeaderViewModelTest : PropertyChangedTest
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

        private class WeekSelected : IWeekSelected
        {
            private ISchedulerWeekModel week;

            public ISchedulerWeekModel Week
            {
                get { return week; }
            }

            #region IWeekSelected Members

            public void SelectWeek(ISchedulerWeekModel week)
            {
                this.week = week;
            }

            #endregion
        }

        /// <summary>
        ///A test for ClickHeaderCommand
        ///</summary>
        [TestMethod()]
        public void ClickHeaderTest()
        {
            WeekSelected weekNotify = new WeekSelected();
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerWeekModel week = new SchedulerWeekModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date, DisplayedDays.Week);
            week.SetDate(date);
            SchedulerMonthWeekHeaderViewModel target = new SchedulerMonthWeekHeaderViewModel(weekNotify, week);

            Assert.IsNull(weekNotify.Week, "Week should be null.");

            ICommand command = target.ClickHeaderCommand;
            command.Execute(null);

            Assert.IsNotNull(weekNotify.Week, "Week should be assigned.");
            Assert.AreEqual(1, weekNotify.Week.Week, "Date should be 1.");
        }

        /// <summary>
        ///A test for ClickHeaderCommand
        ///</summary>
        [TestMethod()]
        public void ClickHeaderCommandTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerWeekModel week = new SchedulerWeekModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date, DisplayedDays.Week);
            SchedulerMonthWeekHeaderViewModel target = new SchedulerMonthWeekHeaderViewModel(null, week);
            Assert.IsInstanceOfType(target.ClickHeaderCommand, typeof(ICommand), "ClickHeaderCommand should return ICommand object.");
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        ///A test for Week
        ///</summary>
        [TestMethod()]
        public void WeekTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerWeekModel model = new SchedulerWeekModel(new SchedulerDisplayInfo(new CultureInfo("en-US")), date, DisplayedDays.Week);
            model.SetDate(date);
            SchedulerMonthWeekHeaderViewModel target = new SchedulerMonthWeekHeaderViewModel(null, model);
            Assert.AreEqual(1, target.Week, "Week isn't 1.");

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                model.SetDate(date.AddDays(7));
                Assert.IsTrue(NotifiedProperties.Contains("Week"), "PropertyChanged event wasn't raised on property 'Week' changing to 2.");
                Assert.AreEqual(2, target.Week, "Week isn't 2.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
