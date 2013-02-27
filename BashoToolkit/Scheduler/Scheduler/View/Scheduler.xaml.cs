using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.Globalization;

namespace Basho.Toolkit.Scheduler
{
	/// <summary>
	/// Interaction logic for Scheduler.xaml
	/// </summary>
	public partial class Scheduler : UserControl
	{
		public Scheduler()
		{
			this.InitializeComponent();

            this.DataContext = new SchedulerViewModel(null, new CultureInfo("cs-CZ"));
        }
	}
}