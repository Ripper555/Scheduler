using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerBaseElementViewModel : SchedulerBaseViewModel
    {
        #region private fields

        private int column;
        private int row;

        #endregion

        #region public properties

        public int Column
        {
            get { return column; }
            set
            {
                if (column != value)
                {
                    column = value;
                    NotifyPropertyChanged("Column");
                }
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                if (row != value)
                {
                    row = value;
                    NotifyPropertyChanged("Row");
                }
            }
        }

        #endregion
    }
}
