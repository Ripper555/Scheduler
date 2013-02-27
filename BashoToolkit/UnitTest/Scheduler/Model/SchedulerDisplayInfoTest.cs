using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerDisplayInfoTest and is intended
    ///to contain all SchedulerDisplayInfoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerDisplayInfoTest : PropertyChangedTest
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
        ///A test for FirstDayOfWeek
        ///</summary>
        [TestMethod()]
        public void FirstDayOfWeekTest()
        {
            SchedulerDisplayInfo target = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.FirstDayOfWeek = DayOfWeek.Monday;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'FirstDayOfWeek' changing to Monday.");

                PreparePropertyChangedTest();
                target.FirstDayOfWeek = DayOfWeek.Tuesday;
                Assert.IsTrue(NotifiedProperties.Contains("FirstDayOfWeek"), "PropertyChanged event wasn't raised on property 'FirstDayOfWeek' changing to Tuesday.");

                PreparePropertyChangedTest();
                target.FirstDayOfWeek = DayOfWeek.Tuesday;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'FirstDayOfWeek' changing to Tuesday.");

                PreparePropertyChangedTest();
                target.FirstDayOfWeek = DayOfWeek.Wednesday;
                Assert.IsTrue(NotifiedProperties.Contains("FirstDayOfWeek"), "PropertyChanged event wasn't raised on property 'FirstDayOfWeek' changing to Wednesday.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for CalendarWeekRule
        ///</summary>
        [TestMethod()]
        public void CalendarWeekRuleTest()
        {
            SchedulerDisplayInfo target = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.CalendarWeekRule = CalendarWeekRule.FirstDay;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'CalendarWeekRule' changing to FirstDay.");

                PreparePropertyChangedTest();
                target.CalendarWeekRule = CalendarWeekRule.FirstFourDayWeek;
                Assert.IsTrue(NotifiedProperties.Contains("CalendarWeekRule"), "PropertyChanged event wasn't raised on property 'CalendarWeekRule' changing to FirstFourDayWeek.");

                PreparePropertyChangedTest();
                target.CalendarWeekRule = CalendarWeekRule.FirstFourDayWeek;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'CalendarWeekRule' changing to FirstFourDayWeek.");

                PreparePropertyChangedTest();
                target.CalendarWeekRule = CalendarWeekRule.FirstFullWeek;
                Assert.IsTrue(NotifiedProperties.Contains("CalendarWeekRule"), "PropertyChanged event wasn't raised on property 'CalendarWeekRule' changing to FirstFullWeek.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for WorkingHoursFrom
        ///</summary>
        [TestMethod()]
        public void WorkingHoursFromTest()
        {
            SchedulerDisplayInfo target = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(8, 0, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursFrom' changing to 8:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(7, 0, 0);
                Assert.IsTrue(NotifiedProperties.Contains("WorkingHoursFrom"), "PropertyChanged event wasn't raised on property 'WorkingHoursFrom' changing to 7:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(7, 0, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursFrom' changing to 7:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(6, 0, 0);
                Assert.IsTrue(NotifiedProperties.Contains("WorkingHoursFrom"), "PropertyChanged event wasn't raised on property 'WorkingHoursFrom' changing to 6:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(0, 0, -1);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursFrom' changing to -0:0:1.");

                PreparePropertyChangedTest();
                target.WorkingHoursFrom = new TimeSpan(17, 0, 1);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursFrom' changing to 17:0:1.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for WorkingHoursTo
        ///</summary>
        [TestMethod()]
        public void WorkingHoursToTest()
        {
            SchedulerDisplayInfo target = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(17, 0, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursTo' changing to 17:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(16, 0, 0);
                Assert.IsTrue(NotifiedProperties.Contains("WorkingHoursTo"), "PropertyChanged event wasn't raised on property 'WorkingHoursTo' changing to 16:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(16, 0, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursTo' changing to 16:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(15, 0, 0);
                Assert.IsTrue(NotifiedProperties.Contains("WorkingHoursTo"), "PropertyChanged event wasn't raised on property 'WorkingHoursTo' changing to 15:0:0.");

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(7, 59, 59);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursTo' changing to 7:59:59.");

                PreparePropertyChangedTest();
                target.WorkingHoursTo = new TimeSpan(24, 0, 1);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'WorkingHoursTo' changing to 24:0:1.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///A test for WorkingDays
        ///</summary>
        [TestMethod()]
        public void WorkingDaysTest()
        {
            SchedulerDisplayInfo target = new SchedulerDisplayInfo(new CultureInfo("en-US"));
            Assert.IsTrue(target.WorkingDays.Length == 7, "'WorkingDays' array must have 7 items.");
        }

        #endregion
    }
}
