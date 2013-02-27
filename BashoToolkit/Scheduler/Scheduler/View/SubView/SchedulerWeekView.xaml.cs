using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Basho.Toolkit.Scheduler
{
    /// <summary>
    /// Interaction logic for SchedulerWeekView.xaml
    /// </summary>
    internal partial class SchedulerWeekView : UserControl
    {
        public SchedulerWeekView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            GridLength hourHeaderSize = (GridLength)this.FindResource("HourHeaderSize");
            SchedulerWeekViewModel viewModel = (SchedulerWeekViewModel)DataContext;

            viewerBody.ScrollToVerticalOffset(hourHeaderSize.Value * viewModel.TopDisplayedHour);
        }
    }
}
