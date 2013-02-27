using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basho.Toolkit.UnitTests
{
    public abstract class PropertyChangedTest
    {
        private List<string> notifiedProperties;

        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            notifiedProperties.Add(e.PropertyName);
        }

        protected void PreparePropertyChangedTest()
        {
            notifiedProperties = new List<string>();
        }

        protected List<string> NotifiedProperties
        {
            get { return notifiedProperties; }
        }
    }
}
