using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthDayBodyViewModelTest and is intended
    ///to contain all SchedulerMonthDayBodyViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthDayBodyViewModelTest : PropertyChangedTest
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

        #region INotifyPropertyChanged Members

        /// <summary>
        ///A test for IsToday
        ///</summary>
        [TestMethod()]
        public void IsTodayTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerMonthDayBodyViewModel target = new SchedulerMonthDayBodyViewModel(day);

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
            SchedulerMonthDayBodyViewModel target = new SchedulerMonthDayBodyViewModel(day);

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

        #endregion
    }
}
