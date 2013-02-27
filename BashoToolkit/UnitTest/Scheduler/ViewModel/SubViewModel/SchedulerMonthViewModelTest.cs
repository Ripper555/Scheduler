using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthViewModelTest and is intended
    ///to contain all SchedulerMonthViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthViewModelTest : PropertyChangedTest
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
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(scheduler, null);
            DateTime date = new DateTime(2010, 1, 1);

            Assert.IsNull(target.month, "week should be null.");

            target.InitializeModel(date);

            Assert.IsNotNull(target.month, "day should be initialized.");
            Assert.AreEqual(new DateTime(2009, 12, 28), target.month.Weeks[0].Days[0].Date, "Date should be 12/28/2009.");
        }

        /// <summary>
        ///A test for CreateElements
        ///</summary>
        [TestMethod()]
        public void CreateElementsTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(scheduler, null);

            Assert.IsNull(target.Elements, "HeaderElements should be null.");

            target.InitializeModel(new DateTime(2010, 1, 1));
            target.CreateElements();

            Assert.IsNotNull(target.Elements, "HeaderElements should be initialized.");
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
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(scheduler, null);
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
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(scheduler, null);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeModel(date);

            Assert.AreEqual(new DateTime(2009, 12, 28), target.month.Weeks[0].Days[0].Date, "Date should be 12/28/2009.");

            target.SetViewDate(date.AddMonths(-1));

            Assert.AreEqual(new DateTime(2009, 11, 30), target.month.Weeks[0].Days[0].Date, "Date should be 11/30/2009.");
        }

        /// <summary>
        ///A test for GetPreviousViewDate
        ///</summary>
        [TestMethod()]
        public void GetPreviousViewDateTest()
        {
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(null, null);
            DateTime date = new DateTime(2010, 1, 1);
            Assert.AreEqual(date.AddMonths(-1), target.GetPreviousViewDate(date), "Date should be 12/1/2009.");
        }

        /// <summary>
        ///A test for GetNextViewDate
        ///</summary>
        [TestMethod()]
        public void GetNextViewDateTest()
        {
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(null, null);
            DateTime date = new DateTime(2010, 1, 1);
            Assert.AreEqual(date.AddMonths(1), target.GetNextViewDate(date), "Date should be 2/1/2010.");
        }

        /// <summary>
        ///A test for SetToday
        ///</summary>
        [TestMethod()]
        public void SetTodayTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerMonthViewModel_Accessor target = new SchedulerMonthViewModel_Accessor(scheduler, null);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeModel(date);

            Assert.IsTrue(target.month.Weeks[0].Days[4].IsToday, "Today should be 1/1/2010.");

            target.SetViewDate(date.AddDays(-7));

            Assert.IsFalse(target.month.Weeks[0].Days[4].IsToday, "Today should be 1/1/2010.");
        }

        #endregion

        #region DisplayedWeeks property

        /// <summary>
        ///A test for DisplayedWeeks
        ///</summary>
        [TestMethod()]
        public void DisplayedWeeksCaptionTest()
        {
            SchedulerViewModel scheduler = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            SchedulerMonthViewModel target = new SchedulerMonthViewModel(scheduler, null);
            DateTime date = new DateTime(2010, 1, 1);
            target.Initialize(new DateTime(2010, 2, 1));

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetView(date);
                Assert.AreEqual(5, target.DisplayedWeeks, "DisplayedWeeks must be set 5.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 5.");

                PreparePropertyChangedTest();
                target.SetView(date.AddDays(40));
                Assert.AreEqual(4, target.DisplayedWeeks, "DisplayedWeeks must be set 4.");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedWeeks"), "PropertyChanged event wasn't raised on property 'DisplayedWeeks' changing to 4.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
