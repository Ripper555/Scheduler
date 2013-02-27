using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Basho.Toolkit.Scheduler
{
    public class SchedulerBaseViewModel : BaseModel
    {
        #region private fields

        private IBaseModel model;
        private List<string> properties;

        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (model != null)
                model.PropertyChanged -= new PropertyChangedEventHandler(OnPropertyChanged);
            base.Dispose(disposing);
        }

        #endregion

        #region INotifyPropertyChanged Members

        protected void SetModel(IBaseModel model, params string[] properties)
        {
            if (model == null)
                throw new ArgumentNullException("model", "Parameter can't be null.");

            this.properties = new List<string>();
            if (properties != null)
                this.properties.AddRange(properties);

            this.model = model;
            model.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (properties.Contains(e.PropertyName))
                NotifyPropertyChanged(e.PropertyName);
        }

        #endregion
    }
}
