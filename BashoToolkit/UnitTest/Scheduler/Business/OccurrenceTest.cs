using Basho.Toolkit.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Basho.Toolkit.UnitTests
{
    /// <summary>
    ///This is a test class for OccurrenceTest and is intended
    ///to contain all OccurrenceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OccurrenceTest : PropertyChangedTest
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

        #region IComparable Memebers

        /// <summary>
        ///A test for CompareTo
        ///</summary>
        [TestMethod()]
        public void CompareToTest()
        {
            Occurrence event1 = new Occurrence();
            Occurrence event2 = new Occurrence();

            DateTime startDate = new DateTime(2010, 1, 1, 12, 0, 0);
            event1.StartDate = startDate;
            event2.StartDate = startDate;

            int actual = event1.CompareTo(event2);
            Assert.AreEqual(0, actual, "Both events must be compared as same, because they start at the same time.");

            event2.StartDate = startDate.AddMinutes(1);
            actual = event1.CompareTo(event2);
            Assert.AreEqual(-1, actual, "'event1' must be compared as less, because it starts earlier than 'event2'");

            event2.StartDate = startDate.AddMinutes(-1);
            actual = event1.CompareTo(event2);
            Assert.AreEqual(1, actual, "'event1' must be compared as greater, because it starts later than 'event2'");
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        ///A test for NotifyPropertyChanged
        ///</summary>
        [TestMethod()]
        public void AllDayEventPropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.AllDayEvent = false;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'AllDayEvent' changing to false.");

                PreparePropertyChangedTest();
                target.AllDayEvent = true;
                Assert.IsTrue(NotifiedProperties.Contains("AllDayEvent"), "PropertyChanged event wasn't raised on property 'AllDayEvent' changing to true.");

                PreparePropertyChangedTest();
                target.AllDayEvent = true;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'AllDayEvent' changing to true.");

                PreparePropertyChangedTest();
                target.AllDayEvent = false;
                Assert.IsTrue(NotifiedProperties.Contains("AllDayEvent"), "PropertyChanged event wasn't raised on property 'AllDayEvent' changing to false.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for Category
        ///</summary>
        [TestMethod()]
        public void CategoryPropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.Category = Category.Blue;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Category' changing to Blue.");

                PreparePropertyChangedTest();
                target.Category = Category.Green;
                Assert.IsTrue(NotifiedProperties.Contains("Category"), "PropertyChanged event wasn't raised on property 'Category' changing to Green.");

                PreparePropertyChangedTest();
                target.Category = Category.Green;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Category' changing to Green.");

                PreparePropertyChangedTest();
                target.Category = Category.Red;
                Assert.IsTrue(NotifiedProperties.Contains("Category"), "PropertyChanged event wasn't raised on property 'Category' changing to Red.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for Duration
        ///</summary>
        [TestMethod()]
        public void StartDateAndDurationPropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'StartDate' changing to 1/1/2010 12:00:00PM.");

                PreparePropertyChangedTest();
                target.StartDate = new DateTime(2010, 1, 1, 12, 15, 0);
                Assert.IsTrue(NotifiedProperties.Contains("StartDate"), "PropertyChanged event wasn't raised on property 'StartDate' changing to 1/1/2010 12:15:00PM.");
                Assert.IsTrue(NotifiedProperties.Contains("Duration"), "PropertyChanged event wasn't raised on property 'Duration' changing due to 'StartDate' changed to' 1/1/2010 12:15:00PM.");

                PreparePropertyChangedTest();
                target.StartDate = new DateTime(2010, 1, 1, 12, 15, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'StartDate' changing to 1/1/2010 12:15:00PM.");

                PreparePropertyChangedTest();
                target.StartDate = new DateTime(2010, 1, 1, 12, 10, 0);
                Assert.IsTrue(NotifiedProperties.Contains("StartDate"), "PropertyChanged event wasn't raised on property 'StartDate' changing to 1/1/2010 12:10:00PM.");
                Assert.IsTrue(NotifiedProperties.Contains("Duration"), "PropertyChanged event wasn't raised on property 'Duration' changing due to 'StartDate' changed to' 1/1/2010 12:10:00PM.");

                PreparePropertyChangedTest();
                target.StartDate = new DateTime(2010, 1, 1, 12, 45, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'StartDate' changing to 1/1/2010 12:45:00PM.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for Duration
        ///</summary>
        [TestMethod()]
        public void EndDateAndDurationPropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'EndDate' changing to 1/1/2010 12:30:00PM.");

                PreparePropertyChangedTest();
                target.EndDate = new DateTime(2010, 1, 1, 12, 15, 0);
                Assert.IsTrue(NotifiedProperties.Contains("EndDate"), "PropertyChanged event wasn't raised on property 'EndDate' changing to 1/1/2010 12:15:00PM.");
                Assert.IsTrue(NotifiedProperties.Contains("Duration"), "PropertyChanged event wasn't raised on property 'Duration' changing due to 'EndDate' changed to' 1/1/2010 12:15:00PM.");

                PreparePropertyChangedTest();
                target.EndDate = new DateTime(2010, 1, 1, 12, 15, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'EndDate' changing to 1/1/2010 12:15:00PM.");

                PreparePropertyChangedTest();
                target.EndDate = new DateTime(2010, 1, 1, 12, 10, 0);
                Assert.IsTrue(NotifiedProperties.Contains("EndDate"), "PropertyChanged event wasn't raised on property 'EndDate' changing to 1/1/2010 12:10:00PM.");
                Assert.IsTrue(NotifiedProperties.Contains("Duration"), "PropertyChanged event wasn't raised on property 'Duration' changing due to 'EndDate' changed to' 1/1/2010 12:10:00PM.");

                PreparePropertyChangedTest();
                target.EndDate = new DateTime(2010, 1, 1, 11, 15, 0);
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'EndDate' changing to 1/1/2010 11:45:00PM.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for Importance
        ///</summary>
        [TestMethod()]
        public void ImportancePropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.Importance = Importance.Normal;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Importance' changing to Normal.");

                PreparePropertyChangedTest();
                target.Importance = Importance.Low;
                Assert.IsTrue(NotifiedProperties.Contains("Importance"), "PropertyChanged event wasn't raised on property 'Importance' changing to Low.");

                PreparePropertyChangedTest();
                target.Importance = Importance.Low;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Importance' changing to Low.");

                PreparePropertyChangedTest();
                target.Importance = Importance.High;
                Assert.IsTrue(NotifiedProperties.Contains("Importance"), "PropertyChanged event wasn't raised on property 'Importance' changing to High.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        [TestMethod()]
        public void TitlePropertyChangedTest()
        {
            Occurrence target = new Occurrence();
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.Title = string.Empty;
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Title' changing to empty string.");

                PreparePropertyChangedTest();
                target.Title = "TEST";
                Assert.IsTrue(NotifiedProperties.Contains("Title"), "PropertyChanged event wasn't raised on property 'Title' changing to 'TEST'.");

                PreparePropertyChangedTest();
                target.Title = "TEST";
                Assert.IsTrue(NotifiedProperties.Count == 0, "PropertyChanged event was incorectly raised on property 'Title' changing to 'TEST'.");

                PreparePropertyChangedTest();
                target.Title = "TITLE";
                Assert.IsTrue(NotifiedProperties.Contains("Title"), "PropertyChanged event wasn't raised on property 'Title' changing to 'TITLE'.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///A test for StartDate
        ///</summary>
        [TestMethod()]
        public void StartDateTest()
        {
            Occurrence target = new Occurrence();
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.StartDate, "StartDate is not set correctly.");
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 1);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.StartDate, "StartDate is not set or rounded to minutes correctly.");
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 59);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.StartDate, "StartDate is not set or rounded to minutes correctly.");
            target.StartDate = new DateTime(2010, 1, 1, 12, 29, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 29, 0), target.StartDate, "StartDate is not set or rounded to minutes correctly.");
            target.StartDate = new DateTime(2010, 1, 1, 12, 30, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 30, 0), target.StartDate, "StartDate should be changed to date equal to EndTime.");
            target.StartDate = new DateTime(2010, 1, 1, 12, 31, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 30, 0), target.StartDate, "StartDate can't be changed to date greater to EndTime.");
        }

        /// <summary>
        ///A test for EndDate
        ///</summary>
        [TestMethod()]
        public void EndDateTest()
        {
            Occurrence target = new Occurrence();
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 30, 0), target.EndDate, "EndDate is not set correctly.");
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 1);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 30, 0), target.EndDate, "EndDate is not set or rounded to minutes correctly.");
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 59);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 30, 0), target.EndDate, "EndDate is not set or rounded to minutes correctly.");
            target.EndDate = new DateTime(2010, 1, 1, 12, 1, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 1, 0), target.EndDate, "EndDate is not set or rounded to minutes correctly.");
            target.EndDate = new DateTime(2010, 1, 1, 12, 0, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.EndDate, "EndDate should be changed to date equal to StartTime.");
            target.EndDate = new DateTime(2010, 1, 1, 11, 59, 0);
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.EndDate, "EndDate can't be changed to date less to StartTime.");
        }

        #endregion

        #region Methods

        /// <summary>
        ///A test for RoundTime
        ///</summary>
        [TestMethod()]
        public void RoundToMinutesTest()
        {
            Occurrence_Accessor target = new Occurrence_Accessor();

            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.RoundToMinutes(new DateTime(2010, 1, 1, 12, 0, 1)));
            Assert.AreEqual(new DateTime(2010, 1, 1, 12, 0, 0), target.RoundToMinutes(new DateTime(2010, 1, 1, 12, 0, 59)));
        }

        /// <summary>
        ///A test for Shift
        ///</summary>
        [TestMethod()]
        public void ShiftTest()
        {
            Occurrence target = new Occurrence();
            target.StartDate = new DateTime(2010, 1, 1, 12, 0, 0);
            target.EndDate = new DateTime(2010, 1, 1, 12, 30, 0);
            try
            {
                target.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);

                PreparePropertyChangedTest();
                target.Shift(new TimeSpan(0, 15, 0));
                Assert.AreEqual(new DateTime(2010, 1, 1, 12, 15, 0), target.StartDate, "StartDate is not set correctly due to calling method 'ShiftOccurrence' with +15 minutes.");
                Assert.AreEqual(new DateTime(2010, 1, 1, 12, 45, 0), target.EndDate, "EndDate is not set correctly due to calling method 'ShiftOccurrence' with +15 minutes.");
                Assert.IsTrue(NotifiedProperties.Contains("StartDate"), "PropertyChanged event wasn't raised on property 'StartDate' changing due to calling method 'ShiftOccurrence' with +15 minutes.");
                Assert.IsTrue(NotifiedProperties.Contains("EndDate"), "PropertyChanged event wasn't raised on property 'EndDate' changing due to calling method 'ShiftOccurrence' with +15 minutes.");

                PreparePropertyChangedTest();
                target.Shift(new TimeSpan(0, -10, 0));
                Assert.AreEqual(new DateTime(2010, 1, 1, 12, 05, 0), target.StartDate, "StartDate is not set correctly due to calling method 'ShiftOccurrence' with -10 minutes.");
                Assert.AreEqual(new DateTime(2010, 1, 1, 12, 35, 0), target.EndDate, "EndDate is not set correctly due to calling method 'ShiftOccurrence' with -10 minutes.");
                Assert.IsTrue(NotifiedProperties.Contains("StartDate"), "PropertyChanged event wasn't raised on property 'StartDate' changing due to calling method 'ShiftOccurrence' with -10 minutes.");
                Assert.IsTrue(NotifiedProperties.Contains("EndDate"), "PropertyChanged event wasn't raised on property 'EndDate' changing due to calling method 'ShiftOccurrence' with -10 minutes.");
            }
            finally
            {
                target.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            }
        }

        #endregion
    }
}
