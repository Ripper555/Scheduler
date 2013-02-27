using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Timers;
using System.Windows.Input;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerViewModelTest and is intended
    ///to contain all SchedulerViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerViewModelTest : PropertyChangedTest
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

        #region Today's timer

        /// <summary>
        ///A test for SetNowAndToday
        ///</summary>
        [TestMethod()]
        public void SetNowAndTodayTest()
        {
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for TimerElapsed
        ///</summary>
        [TestMethod()]
        public void TimerElapsedTest()
        {
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        #endregion

        #region Subview models

        /// <summary>
        ///A test for ViewModels
        ///</summary>
        [TestMethod()]
        public void ViewModelsTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsNull(target.viewModels, "private field viewModel is not null.");
            int length = target.ViewModels.Length;
            Assert.IsNotNull(target.viewModels, "private field viewModel is null.");
        }

        /// <summary>
        ///A test for CreateViewModel
        ///</summary>
        [TestMethod()]
        public void CreateViewModelTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            DateTime date = new DateTime(2001, 1, 1); 
            target.CreateViewModel(DisplayMode.Day, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Day], "CreateViewModel doesn't create view model for Day.");
            target.CreateViewModel(DisplayMode.Week, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Week], "CreateViewModel doesn't create view model for Week.");
            target.CreateViewModel(DisplayMode.Month, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Month], "CreateViewModel doesn't create view model for Month.");
            target.CreateViewModel(DisplayMode.Unspecified, date);
            Assert.IsNull(target.ViewModels[(int)DisplayMode.Unspecified], "CreateViewModel does create view model for Unspecified.");
        }

        /// <summary>
        ///A test for InitializeViewModel
        ///</summary>
        [TestMethod()]
        public void InitializeViewModelTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            target.InitializeViewModel(DisplayMode.Day);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Day], "InitializeViewModel doesn't create view model for Day.");
            target.InitializeViewModel(DisplayMode.Week);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Week], "InitializeViewModel doesn't create view model for Week.");
            target.InitializeViewModel(DisplayMode.Month);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Month], "InitializeViewModel doesn't create view model for Month.");
            target.InitializeViewModel(DisplayMode.Unspecified);
            Assert.IsNull(target.ViewModels[(int)DisplayMode.Unspecified], "InitializeViewModel does create view model for Unspecified.");
        }

        /// <summary>
        ///A test for InitializeViewModel
        ///</summary>
        [TestMethod()]
        public void InitializeViewModelWithDateTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            DateTime date = new DateTime(2001, 1, 1);
            target.InitializeViewModel(DisplayMode.Day, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Day], "InitializeViewModel doesn't create view model for Day.");
            target.InitializeViewModel(DisplayMode.Week, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Week], "InitializeViewModel doesn't create view model for Week.");
            target.InitializeViewModel(DisplayMode.Month, date);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Month], "InitializeViewModel doesn't create view model for Month.");
            target.InitializeViewModel(DisplayMode.Unspecified, date);
            Assert.IsNull(target.ViewModels[(int)DisplayMode.Unspecified], "InitializeViewModel does create view model for Unspecified.");
        }

        #endregion

        #region Porperty ViewModel

        /// <summary>
        ///A test for ViewModel
        ///</summary>
        [TestMethod()]
        public void ViewModelTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            target.InitializeViewModel(DisplayMode.Day);
            Assert.IsInstanceOfType(target.ViewModel, typeof(SchedulerWeekViewModel), "ViewModel isn't instance DayViewModel.");
            target.InitializeViewModel(DisplayMode.WorkWeek);
            Assert.IsInstanceOfType(target.ViewModel, typeof(SchedulerWeekViewModel), "ViewModel isn't instance WeekViewModel.");
            target.InitializeViewModel(DisplayMode.Week);
            Assert.IsInstanceOfType(target.ViewModel, typeof(SchedulerWeekViewModel), "ViewModel isn't instance WeekViewModel.");
            target.InitializeViewModel(DisplayMode.Month);
            Assert.IsInstanceOfType(target.ViewModel, typeof(SchedulerMonthViewModel), "ViewModel isn't instance MonthViewModel.");
        }

        #endregion

        #region Commands

        /// <summary>
        ///A test for DisplayDay
        ///</summary>
        [TestMethod()]
        public void DisplayDayTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            target.DisplayDay();
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Day], "DisplayDay doesn't create view model for Day.");
        }

        /// <summary>
        ///A test for CanDisplayDay
        ///</summary>
        [TestMethod()]
        public void CanDisplayDayTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsTrue(target.CanDisplayDay, "Should return true.");
        }

        /// <summary>
        ///A test for DisplayWeek
        ///</summary>
        [TestMethod()]
        public void DisplayWeekTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            target.DisplayWeek();
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Week], "DisplayWeek doesn't create view model for Week.");
        }

        /// <summary>
        ///A test for CanDisplayWeek
        ///</summary>
        [TestMethod()]
        public void CanDisplayWeekTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsTrue(target.CanDisplayWeek, "Should return true.");
        }

        /// <summary>
        ///A test for DisplayMonth
        ///</summary>
        [TestMethod()]
        public void DisplayMonthTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            target.DisplayMonth();
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Month], "DisplayMonth doesn't create view model for Month.");
        }

        /// <summary>
        ///A test for CanDisplayMonth
        ///</summary>
        [TestMethod()]
        public void CanDisplayMonthTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsTrue(target.CanDisplayMonth, "Should return true.");
        }

        /// <summary>
        ///A test for DisplayPrevious
        ///</summary>
        [TestMethod()]
        public void DisplayPreviousTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeViewModel(DisplayMode.Day, date);
            Assert.AreEqual(date, target.selectedDate);
            target.DisplayPrevious();
            Assert.AreEqual(date.AddDays(-1), target.selectedDate);
        }

        /// <summary>
        ///A test for CanDisplayPrevious
        ///</summary>
        [TestMethod()]
        public void CanDisplayPreviousTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsTrue(target.CanDisplayPrevious, "Should return true.");
        }

        /// <summary>
        ///A test for DisplayNext
        ///</summary>
        [TestMethod()]
        public void DisplayNextTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            DateTime date = new DateTime(2010, 1, 1);
            target.InitializeViewModel(DisplayMode.Day, date);
            Assert.AreEqual(date, target.selectedDate);
            target.DisplayNext();
            Assert.AreEqual(date.AddDays(1), target.selectedDate);
        }

        /// <summary>
        ///A test for CanDisplayNext
        ///</summary>
        [TestMethod()]
        public void CanDisplayNextTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            Assert.IsTrue(target.CanDisplayNext, "Should return true.");
        }

        #endregion

        #region Command's properties

        /// <summary>
        ///A test for DayCommand
        ///</summary>
        [TestMethod()]
        public void DayCommandTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsInstanceOfType(target.DayCommand, typeof(ICommand), "DayCommand should return ICommand object.");
        }

        /// <summary>
        ///A test for WeekCommand
        ///</summary>
        [TestMethod()]
        public void WeekCommandTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsInstanceOfType(target.WeekCommand, typeof(ICommand), "WeekCommand should return ICommand object.");
        }

        /// <summary>
        ///A test for MonthCommand
        ///</summary>
        [TestMethod()]
        public void MonthCommandTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsInstanceOfType(target.MonthCommand, typeof(ICommand), "MonthCommand should return ICommand object.");
        }

        /// <summary>
        ///A test for PreviousCommand
        ///</summary>
        [TestMethod()]
        public void PreviousCommandTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsInstanceOfType(target.PreviousCommand, typeof(ICommand), "PreviousCommand should return ICommand object.");
        }

        /// <summary>
        ///A test for NextCommand
        ///</summary>
        [TestMethod()]
        public void NextCommandTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsInstanceOfType(target.NextCommand, typeof(ICommand), "NextCommand should return ICommand object.");
        }

        #endregion

        #region IDayNotification Members

        /// <summary>
        ///A test for SelectDay
        ///</summary>
        [TestMethod()]
        public void SelectDayTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            SchedulerDayModel day = new SchedulerDayModel(target.displayInfo, new DateTime(2010, 1, 1));
            target.SelectDay(day);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Day], "SelectDay doesn't create view model for Day.");
        }

        #endregion

        #region IWeekNotification Members

        /// <summary>
        ///A test for SelectWeek
        ///</summary>
        [TestMethod()]
        public void SelectWeekTest()
        {
            SchedulerViewModel_Accessor target = new SchedulerViewModel_Accessor(null, new CultureInfo("en-US"), false, false);
            SchedulerWeekModel week = new SchedulerWeekModel(target.displayInfo, new DateTime(2010, 1, 1), DisplayedDays.Week);
            target.SelectWeek(week);
            Assert.IsNotNull(target.ViewModels[(int)DisplayMode.Week], "SelectWeek doesn't create view model for Week.");
        }

        #endregion

        #region ISchedulerNotification Members

        /// <summary>
        ///A test for DisplayInfo
        ///</summary>
        [TestMethod()]
        public void DisplayInfoTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            Assert.IsNotNull(target.DisplayInfo, "DisplayInfo is null.");
        }

        /// <summary>
        ///A test for SetDisplayedDate
        ///</summary>
        [TestMethod()]
        public void SetDisplayedDateTest()
        {
            SchedulerViewModel target = new SchedulerViewModel(null, new CultureInfo("en-US"), false, false);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.SetDisplayedDate("TEST");
                Assert.IsTrue(NotifiedProperties.Contains("DisplayedDate"), "PropertyChanged event wasn't raised on property 'DisplayedDate' changing to TEST.");

                PreparePropertyChangedTest();
                target.SetDisplayedDate("TEST");
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'DisplayedDate' changing to TEST.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
