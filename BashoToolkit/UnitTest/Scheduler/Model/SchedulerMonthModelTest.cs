using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthModelTest and is intended
    ///to contain all SchedulerMonthModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthModelTest : PropertyChangedTest
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
        ///A test for SchedulerMonthModel Constructor
        ///</summary>
        [TestMethod()]
        public void SchedulerMonthModelConstructorTest()
        {
            SchedulerMonthModel target = new SchedulerMonthModel(displayInfo, date);
            Assert.AreEqual(6, target.Weeks.Length, "Weeks array must have 6 items.");
        }

        #endregion

        #region Methods

        /// <summary>
        ///A test for GetDateRange
        ///</summary>
        [TestMethod()]
        public void GetDateRangeTest()
        {
            SchedulerMonthModel_Accessor target = new SchedulerMonthModel_Accessor(displayInfo, date);
            DateTime from;
            DateTime to;
            target.GetDateRange(date, out from, out to);
            Assert.AreEqual(new DateTime(2010, 1, 1), from, "'from' must be set to 1/1/2010.");
            Assert.AreEqual(new DateTime(2010, 1, 31), to, "'to' must be set to 1/31/2010.");
        }

        /// <summary>
        ///A test for SetDate
        ///</summary>
        [TestMethod()]
        public void SetMonthTest()
        {
            SchedulerMonthModel target = new SchedulerMonthModel(displayInfo, date);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date);
                Assert.AreEqual(5, target.DisplayedWeeks, "DisplayedWeeks must be set 5.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 5.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(40));
                Assert.AreEqual(4, target.DisplayedWeeks, "DisplayedWeeks must be set 4.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 4.");
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
        public void SetMonthRangeTest()
        {
            SchedulerMonthModel target = new SchedulerMonthModel(displayInfo, date);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date, date, date);
                Assert.AreEqual(5, target.DisplayedWeeks, "DisplayedWeeks must be set 5.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 5.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(40), date, date);
                Assert.AreEqual(4, target.DisplayedWeeks, "DisplayedWeeks must be set 4.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 4.");
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
            SchedulerMonthModel target = new SchedulerMonthModel(displayInfo, date);
            target.SetToday(date.AddDays(1));
            Assert.IsFalse(target.Weeks[0].Days[0].IsToday, "IsToday must be set to false.");
        }

        #endregion
    }
}
