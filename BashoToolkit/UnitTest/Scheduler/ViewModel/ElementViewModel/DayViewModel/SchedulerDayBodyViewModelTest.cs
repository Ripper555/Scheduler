using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for SchedulerDayBodyViewModelTest and is intended
    ///to contain all SchedulerDayBodyViewModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SchedulerDayBodyViewModelTest : PropertyChangedTest
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
        ///A test for Date
        ///</summary>
        [TestMethod()]
        public void DateTest()
        {
            DateTime date = new DateTime(2010, 1, 1);
            SchedulerDayModel day = new SchedulerDayModel(new SchedulerDisplayInfo(new CultureInfo("cs-CZ")), date);
            day.SetDate(date);
            SchedulerDayBodyViewModel target = new SchedulerDayBodyViewModel(day);

            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                day.SetDate(date.AddDays(-1));
                Assert.IsTrue(NotifiedProperties.Contains("Date"), "PropertyChanged event wasn't raised on property 'Date' changing to 12/31/2009.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
