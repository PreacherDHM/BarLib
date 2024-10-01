using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
	/// Interaction logic for EfficiencyBar.xaml
	/// </summary>
	public partial class EfficiencyBarHorizontal : UserControl, INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler? PropertyChanged;
		private void NotifyPropertyChanged(string info) { 
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private double m_TargetLineHeight;
		public double TargetLineHeight
		{
			get { return m_targetLinePos; }
			set { m_targetLinePos = value; NotifyPropertyChanged("TargetLineHeight"); SetTargetLineHeight(); }
		}

		public string GetWidth
		{
			set { }
			get { return "0," + Y1 + ",0," + Y2; }
		}

		private double m_y1;
		public double Y1
		{
			get { return m_y1; }
			set { m_y1 = value; NotifyPropertyChanged("Y1"); }
		}
		private double m_y2;
		public double Y2
		{
			get { return m_y2; }
			set { m_y2 = value; NotifyPropertyChanged("Y2"); }
		}

		private double m_targetLinePos;
		public double TargetLinePos
		{
			get { return m_targetLinePos; }
			set
			{
				m_targetLinePos = value;
				NotifyPropertyChanged("TargetLinePos");
			}
		}

		private double m_maxValue = 100;
		public double MaxValue
		{
			get { return m_maxValue; }
			set
			{
				m_maxValue = value;
				UpdateBarWidth();
				NotifyPropertyChanged("MaxValue");
			}
		}

		private double m_value = 50;
		public double Value
		{
			get { return m_value; }
			set
			{
				m_value = value;
				UpdateBarWidth();
				NotifyPropertyChanged("Value");
			}
		}

		private double m_barHeight = 20;
		public double BarHeight
		{
			get { return m_barHeight; }
			set { m_barHeight = value; NotifyPropertyChanged("BarHeight");}
		}

		private double m_barWidth;
		public double BarWidth
		{
			get { return m_barWidth; } 
			private set
			{
				m_barWidth = value; NotifyPropertyChanged("BarWidth");
			}
		}

		private Brush m_color = Brushes.Lime;
		public Brush Color
		{
			get { return m_color; }
			set { m_color = value; NotifyPropertyChanged("Color"); }
		}

		public EfficiencyBarHorizontal()
		{
			InitializeComponent();
			this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.DataContext = this;
		}


		void UpdateBarWidth() {
			double barValue;
			double lineValue;
			if (m_maxValue > 0)
			{
				if(m_value > m_maxValue)
				{
					barValue = m_maxValue;
					lineValue = m_maxValue - m_value;
					lineValue += m_maxValue;
					if(lineValue < 0 )
					{
						lineValue = 0;
					}
				}else
				{
					barValue = m_value;
					lineValue = m_maxValue;
				}

				var percent = (barValue * 100) / m_maxValue;
				BarWidth = (percent * this.ActualWidth) / 100;

				var linePercent = (lineValue * 100) / m_maxValue;
				TargetLinePos = ((linePercent * this.ActualWidth) / 100) - 1;

				
			}
		}

		private void SetTargetLineHeight() {
			Y1 = 0;
			Y2 = this.ActualHeight;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			UpdateBarWidth();
			SetTargetLineHeight();
		}
		private void Grid_SizeChanged(object sender, SizeChangedEventArgs e) {
			UpdateBarWidth();
		}
	}
}
