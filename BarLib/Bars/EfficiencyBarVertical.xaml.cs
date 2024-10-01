using System;
using System.Collections.Generic;
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
	/// Interaction logic for EfficiencyBarVertical.xaml
	/// </summary>
	public partial class EfficiencyBarVertical : UserControl, INotifyPropertyChanged
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
			get { return "0," + X1 + ",0," + X2; }
		}

		private double m_x1;
		public double X1
		{
			get { return m_x1; }
			set { m_x1 = value; NotifyPropertyChanged("Y1"); }
		}
		private double m_x2;
		public double X2
		{
			get { return m_x2; }
			set { m_x2 = value; NotifyPropertyChanged("Y2"); }
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

		private double m_maxValue;
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

		private double m_value;
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

		private double m_barHeight;
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

		private Brush m_color;
		public Brush Color
		{
			get { return m_color; }
			set { m_color = value; NotifyPropertyChanged("Color"); }
		}

		public EfficiencyBarVertical()
		{
			InitializeComponent();
			this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.DataContext = this;
			m_color = Brushes.Black;
		}


		void UpdateBarWidth() {
			double barValue;
			double lineValue;
			if (m_maxValue > 0)
			{
				if(m_value > m_maxValue)
				{
					barValue = m_maxValue;
					lineValue =m_value - m_maxValue;
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
				BarWidth = (percent * this.ActualHeight) / 100;

				var linePercent = (lineValue * 100) / m_maxValue;
				TargetLinePos = ((linePercent * this.ActualHeight) / 100);

				TargetLinePos = TargetLineHeight - this.ActualHeight;
				
			}
		}

		private void SetTargetLineHeight() {
			X1 = 0;
			X2 = this.ActualWidth;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			UpdateBarWidth();
			SetTargetLineHeight();
		}
		private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			UpdateBarWidth();
		}
	
	}
}
