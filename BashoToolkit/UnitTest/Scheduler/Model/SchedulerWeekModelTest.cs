using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerWeekModelTest and is intended
    ///to contain all SchedulerWeekModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerWeekModelTest : PropertyChangedTest
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

        private SchedulerDisplayInfo displayInfo;
        private DateTime date;

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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            displayInfo = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            date = new DateTime(2010, 1, 1);
        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region Constructors

        /// <summary>
        ///A test for SchedulerWeekModel
        ///</summary>
        [TestMethod()]
        public void SchedulerWeekModelCtorTest()
        {
            SchedulerWeekModel target = new SchedulerWeekModel(displayInfo, date, DisplayedDays.Week);
            Assert.AreEqual((int)target.DisplayedDays, target.Days.Length, "Days array must have " + (int)target.DisplayedDays + " items.");
        }

        #endregion

        #region Methods

        /// <summary>
        ///A test for GetDateRange
        ///</summary>
        [TestMethod()]
        public void GetDateRangeTest()
        {
            SchedulerWeekModel_Accessor target = new SchedulerWeekModel_Accessor(displayInfo, date, DisplayedDays.Week);
            DateTime from;
            DateTime to;
            target.GetDateRange(date, out from, out to);
            Assert.AreEqual(new DateTime(2009, 12, 28), from, "'from' must be set to 12/28/2009.");
            Assert.AreEqual(new DateTime(2010, 1, 3), to, "'to' must be set to 1/3/2010.");
        }

        /// <summary>
        ///A test for SetDate
        ///</summary>
        [TestMethod()]
        public void SetWeekTest()
        {
            SchedulerWeekModel target = new SchedulerWeekModel(displayInfo, date, DisplayedDays.Week);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date);
                Assert.AreEqual(1, target.Week, "Week must be set 1.");
                Assert.IsTrue(NotifiedProperties.Contains("Week"), "PropertyChanged event wasn't raised on property 'Week' changing to 1.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(-7));
                Assert.AreEqual(52, target.Week, "Week must be set 52.");
                Assert.IsTrue(NotifiedProperties.Contains("Week"), "PropertyChanged event wasn't raised on property 'Week' changing to 52.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for SetDate
        ///</summary>
        [TestMethod()]
        public void SetWeekRangeTest()
        {
            SchedulerWeekModel target = new SchedulerWeekModel(displayInfo, date, DisplayedDays.Week);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date, date.AddDays(-1), date.AddDays(1));
                Assert.AreEqual(1, target.Week, "Week must be set 1.");
                Assert.IsTrue(NotifiedProperties.Contains("Week"), "PropertyChanged event wasn't raised on property 'Week' changing to 1.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(-7), date.AddDays(-1), date.AddDays(1));
                Assert.AreEqual(52, target.Week, "Week must be set 52.");
                Assert.IsTrue(NotifiedProperties.Contains("Week"), "PropertyChanged event wasn't raised on property 'Week' changing to 52.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for SetToday
        ///</summary>
        [TestMethod()]
        public void SetTodayTest()
        {
            SchedulerWeekModel target = new SchedulerWeekModel(displayInfo, date, DisplayedDays.Week);
            target.SetToday(date.AddDays(1));
            Assert.IsFalse(target.Days[0].IsToday, "IsToday must be set to false.");
        }

        #endregion
    }
}
