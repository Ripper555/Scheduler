using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerWeekViewModelTest and is intended
    ///to contain all SchedulerWeekViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerWeekViewModelTest
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

        #region Initialize view model

        /// <summary>
        ///A test for InitializeModel
        ///</summary>
        [TestMethod()]
        public void InitializeModelTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(scheduler, null, DisplayedDays.Week);
            DateTime date = new DateTime(2010, 1, 1);

            Assert.IsNull(target.week, "week should be null.");

            target.InitializeModel(date);

            Assert.IsNotNull(target.week, "day should be initialized.");
            Assert.AreEqual(new DateTime(2009, 12, 28), target.week.Days[0].Date, "Date should be 12/28/2009.");
        }

        /// <summary>
        ///A test for CreateElements
        ///</summary>
        [TestMethod()]
        public void CreateElementsTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(scheduler, null, DisplayedDays.Week);

            Assert.IsNull(target.HeaderElements, "HeaderElements should be null.");
            Assert.IsNull(target.BorderElements, "BorderElements should be null.");
            Assert.IsNull(target.BodyElements, "BodyElements should be null.");

            target.InitializeModel(new DateTime(2010, 1, 1));
            target.CreateElements();

            Assert.IsNotNull(target.HeaderElements, "HeaderElements should be initialized.");
            Assert.IsNotNull(target.BorderElements, "BorderElements should be initialized.");
            Assert.IsNotNull(target.BodyElements, "BodyElements should be initialized.");
        }

        #endregion

        #region Date methods

        /// <summary>
        ///A test for SetDisplayedDateCaption
        ///</summary>
        [TestMethod()]
        public void SetDisplayedDateCaptionTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(scheduler, null, DisplayedDays.Week);
            target.InitializeModel(new DateTime(2010, 1, 1));

            Assert.IsNull(scheduler.DisplayedDate, "DisplayedDate should be null.");

            target.SetDisplayedDateCaption();

            Assert.IsNotNull(scheduler.DisplayedDate, "DisplayedDate should be set.");
        }

        /// <summary>
        ///A test for SetViewDate
        ///</summary>
        [TestMethod()]
        public void SetViewDateTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(scheduler, null, DisplayedDays.Week);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeModel(date);

            Assert.AreEqual(new DateTime(2009, 12, 28), target.week.Days[0].Date, "Date should be 12/28/2009.");

            target.SetViewDate(date.AddDays(-7));

            Assert.AreEqual(new DateTime(2009, 12, 21), target.week.Days[0].Date, "Date should be 12/21/2009.");
        }

        /// <summary>
        ///A test for GetPreviousViewDate
        ///</summary>
        [TestMethod()]
        public void GetPreviousViewDateTest()
        {
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(null, null, DisplayedDays.Week);
            DateTime date = new DateTime(2010, 1, 1);
            Assert.AreEqual(date.AddDays(-7), target.GetPreviousViewDate(date), "Date should be 12/25/2009.");
        }

        /// <summary>
        ///A test for GetNextViewDate
        ///</summary>
        [TestMethod()]
        public void GetNextViewDateTest()
        {
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(null, null, DisplayedDays.Week);
            DateTime date = new DateTime(2010, 1, 1);
            Assert.AreEqual(date.AddDays(7), target.GetNextViewDate(date), "Date should be 1/8/2010.");
        }

        /// <summary>
        ///A test for SetToday
        ///</summary>
        [TestMethod()]
        public void SetTodayTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekViewModel_Accessor target = new SchedulerWeekViewModel_Accessor(scheduler, null, DisplayedDays.Week);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeModel(date);

            Assert.IsTrue(target.week.Days[4].IsToday, "Today should be 1/1/2010.");

            target.SetViewDate(date.AddDays(-7));

            Assert.IsFalse(target.week.Days[4].IsToday, "Today should be 1/1/2010.");
        }

        #endregion
    }
}
