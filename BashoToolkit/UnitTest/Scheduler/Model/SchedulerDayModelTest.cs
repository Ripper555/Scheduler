using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerDayModelTest and is intended
    ///to contain all SchedulerDayModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerDayModelTest : PropertyChangedTest
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

        #region Methods

        /// <summary>
        ///A test for GetDateRange
        ///</summary>
        [TestMethod()]
        public void GetDateRangeTest()
        {
            SchedulerDayModel_Accessor target = new SchedulerDayModel_Accessor(displayInfo, date);
            DateTime from;
            DateTime to;
            target.GetDateRange(date, out from, out to);
            Assert.AreEqual(date, from, "'from' must be same as 'date'.");
            Assert.AreEqual(date, to, "'to' must be same as 'date'.");
        }

        /// <summary>
        ///A test for SetDate
        ///</summary>
        [TestMethod()]
        public void SetDateTest()
        {
            SchedulerDayModel target = new SchedulerDayModel(displayInfo, date);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date);
                Assert.AreEqual(date, target.Date, "Date must be set.");
                Assert.AreEqual("Friday", target.DayOfWeek, "DayOfWeek must be set to Friday.");
                Assert.IsTrue(target.IsToday, "IsToday must be set to true.");
                Assert.IsTrue(target.IsActive, "IsActive must be set to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("DayOfWeek"), "PropertyChanged event wasn't raised on property 'DayOfWeek' changing to Friday 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("IsActive"), "PropertyChanged event wasn't raised on property 'IsActive' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Month"), "PropertyChanged event wasn't raised on property 'Month' changing to January.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(-7));
                Assert.AreEqual(date.AddDays(-7), target.Date, "Date must be set.");
                Assert.AreEqual("Friday", target.DayOfWeek, "DayOfWeek must be set to Friday.");
                Assert.IsFalse(target.IsToday, "IsToday must be set to false.");
                Assert.IsTrue(target.IsActive, "IsActive must be set to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Month"), "PropertyChanged event wasn't raised on property 'Month' changing to January.");
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
        public void SetDateRangeTest()
        {
            SchedulerDayModel target = new SchedulerDayModel(displayInfo, date);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDate(date, date.AddDays(-1), date.AddDays(1));
                Assert.AreEqual(date, target.Date, "Date must be set.");
                Assert.AreEqual("Friday", target.DayOfWeek, "DayOfWeek must be set to Friday.");
                Assert.IsTrue(target.IsToday, "IsToday must be set to true.");
                Assert.IsTrue(target.IsActive, "IsActive must be set to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("DayOfWeek"), "PropertyChanged event wasn't raised on property 'DayOfWeek' changing to Friday 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("IsActive"), "PropertyChanged event wasn't raised on property 'IsActive' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Month"), "PropertyChanged event wasn't raised on property 'Month' changing to January.");

                PreparePropertyChangedTest();
                target.SetDate(date.AddDays(-7), date.AddDays(-1), date.AddDays(1));
                Assert.AreEqual(date.AddDays(-7), target.Date, "Date must be set.");
                Assert.AreEqual("Friday", target.DayOfWeek, "DayOfWeek must be set to Friday.");
                Assert.IsFalse(target.IsToday, "IsToday must be set to false.");
                Assert.IsFalse(target.IsActive, "IsActive must be set to false.");
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 1/1/2010.");
                Assert.IsTrue(NotifiedProperties.Contains("IsActive"), "PropertyChanged event wasn't raised on property 'IsActive' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to true.");
                Assert.IsTrue(NotifiedProperties.Contains("Month"), "PropertyChanged event wasn't raised on property 'Month' changing to January.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for SetSelectedDate
        ///</summary>
        [TestMethod()]
        public void SetSelectedDateTest()
        {
            SchedulerDayModel target = new SchedulerDayModel(displayInfo, date);
            target.SetDate(date);
            Assert.IsFalse(target.IsSelected, "IsSelected must be set to false.");

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetSelectedDate(date);
                Assert.IsTrue(target.IsSelected, "IsSelected must be set to true.");
                Assert.IsTrue(NotifiedProperties.Contains("IsSelected"), "PropertyChanged event wasn't raised on property 'IsSelected' changing to true.");

                PreparePropertyChangedTest();
                target.SetSelectedDate(date.AddDays(1));
                Assert.IsFalse(target.IsSelected, "IsSelected must be set to false.");
                Assert.IsTrue(NotifiedProperties.Contains("IsSelected"), "PropertyChanged event wasn't raised on property 'IsSelected' changing to false.");
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
        [DeploymentItem("Basho.Toolkit.dll")]
        public void SetTodayTest()
        {
            SchedulerDayModel target = new SchedulerDayModel(displayInfo, date);
            target.SetDate(date);
            Assert.IsTrue(target.IsToday, "IsToday must be set to true.");

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetToday(date.AddDays(1));
                Assert.IsFalse(target.IsToday, "IsToday must be set to false.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to false.");

                PreparePropertyChangedTest();
                target.SetToday(date);
                Assert.IsTrue(target.IsToday, "IsToday must be set to false.");
                Assert.IsTrue(NotifiedProperties.Contains("IsToday"), "PropertyChanged event wasn't raised on property 'IsToday' changing to true.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
