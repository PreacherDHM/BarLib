using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarLib.Bars
{
    /// <summary>
    /// Interaction logic for EventBarHorizontal.xaml
    /// </summary>
    public partial class EventBarHorizontal : UserControl, INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler? PropertyChanged;
		private List<EventBarDataItem> m_dataItems = new List<EventBarDataItem>();
		public List<EventBarDataItem> DataItems
		{
			get { return m_dataItems; }
			set { value = m_dataItems; }
		}

		public double BarHeight {  get; set; }

		private double m_maxValue;
		public double MaxValue
		{
			get { return m_maxValue; }
			set
			{
				m_maxValue = value;
			}
		}

        public EventBarHorizontal()
        {
            InitializeComponent();
			IC_Data.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			IC_Data.ItemsSource = m_dataItems;
        }

		public void AddEvent(EventBarDataItem eventBarDataItem)
		{
			m_dataItems.Add(eventBarDataItem);
		}
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{

			IC_Data.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

			// Test Data
			m_dataItems.Add(EventBarDataItems.AlarmEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.AlarmEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.AlarmEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.AlarmEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.AlarmEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.GoodToGoEvent(5000, IC_Data.ActualWidth, this.ActualHeight));
			m_dataItems.Add(EventBarDataItems.MiscEvent(100, IC_Data.ActualWidth, this.ActualHeight));
			
			for(int i = 0; i < m_dataItems.Count; i++) {
					m_dataItems[i].UpdateBarData(IC_Data.ActualWidth);
			}
			IC_Data.Items.Refresh();
		}
		private void Grid_SizeChanged(object sender, RoutedEventArgs e)
		{

			IC_Data.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			for(int i = 0; i < m_dataItems.Count; i++) {
					m_dataItems[i].UpdateBarData(IC_Data.ActualWidth);
			}
			IC_Data.Items.Refresh();
		}


    }

	public class EventBarDataItem
	{
		public double BarWidth { get; set; }

		private double m_barHeight;
		public double BarHeight { get { return m_barHeight; } set { m_barHeight = value; } }

		private double m_value;
		public double Value {
			get
			{
				UpdateBarData(BarWidth);
				return m_value;
			}
			set
			{
				m_value = value;
			}
		}

		private double m_barSize = 10;
		public double BarSize { get 
			{
				return m_barSize;
			}
			set {
				value = m_barSize;
			} 
		}
		public string DataType { get; set; }
		public string Description { get; set; }
		public Brush Color { get; set; }

		public void UpdateBarData(double barWidth) {
			double maxValue = 8640;
			double percent = m_value/maxValue;
			m_barSize = percent * barWidth;
		}

	}

	public class EventBarDataItems {
		public static EventBarDataItem AlarmEvent(double value, double barSize, double barHeight) { return new EventBarDataItem() {BarHeight=barHeight, BarWidth = barSize, Value = value, DataType = "AlarmEvent", Description = "The Machine is in the state of Alarm!", Color = Brushes.Red }; }
		public static EventBarDataItem MiscEvent(double value, double barSize, double barHeight) { return new EventBarDataItem() { BarHeight=barHeight,BarWidth = barSize, Value = value, DataType = "MiscEvent", Description = "The Machine is in a unknown state!", Color = Brushes.Purple }; }
		public static EventBarDataItem GoodToGoEvent(double value, double barSize, double barHeight) { return new EventBarDataItem() {BarHeight=barHeight, BarWidth = barSize,Value = value, DataType = "GoodToGoEvent", Description = "The Machine is running!", Color = Brushes.Lime }; }
		public static EventBarDataItem NoEvent(double value, double barSize, double barHeight) { return new EventBarDataItem() {BarHeight=barHeight, BarWidth = barSize,Value = value, DataType = "NoEvent", Description = "The Machine is in No Event!",Color = Brushes.Black }; }
	}
}
