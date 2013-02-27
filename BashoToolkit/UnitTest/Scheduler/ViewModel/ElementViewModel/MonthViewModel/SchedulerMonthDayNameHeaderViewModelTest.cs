using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerMonthDayNameHeaderViewModelTest and is intended
    ///to contain all SchedulerMonthDayNameHeaderViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerMonthDayNameHeaderViewModelTest : PropertyChangedTest
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

        #region DayOfWeek property

        /// <summary>
        ///A test for DayOfWeek
        ///</summary>
        [TestMethod()]
        public void DayOfWeekTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel model = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("en-US")), date);
            model.SetDate(date);
            SchedulerMonthDayNameHeaderViewModel target = new SchedulerMonthDayNameHeaderViewModel(model);
            Assert.AreEqual("Friday", target.DayOfWeek, "DayOfWeek isn't Friday.");

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                model.SetDate(date.AddDays(1));
                Assert.IsTrue(NotifiedProperties.Contains("DayOfWeek"), "PropertyChanged event wasn't raised on property 'DayOfWeek' changing to Saturday.");
                Assert.AreEqual("Saturday", target.DayOfWeek, "DayOfWeek isn't Saturday.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
