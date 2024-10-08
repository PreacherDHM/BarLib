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
		public enum LabelOrientationEnum
		{
			Vertical,
			Horizontal
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		private void NotifyPropertyChanged(string info) { 
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		private double m_labelAngle = 0;
		public double LabelAngle
		{
			get { return m_labelAngle; } set
			{
				m_labelAngle = value;
				NotifyPropertyChanged("LabelAngle");
			}
		}

		private double m_labelSize = 0;
		public double LabelSize
		{
			get { return m_labelSize; } set
			{
				m_labelSize = value;
				NotifyPropertyChanged("LabelSize");
			}
		}

		private LabelOrientationEnum m_orientation;
		public LabelOrientationEnum LabelOrientation
		{
			get { return m_orientation; }
			set 
			{ 
				m_orientation = value;
				NotifyPropertyChanged("LabelOrientation");
				UpdateLabel();
			}
		}

		private string m_label;
		public string Label
		{
			get { return m_label; }
			set
			{
				m_label = value;
				NotifyPropertyChanged("Label");
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

		private double m_targetValue = 100;
		public double TargetValue
		{
			get { return m_targetValue; }
			set
			{
				m_targetValue = value;
				UpdateBarWidth();
				NotifyPropertyChanged("TargetValue");
			}
		}

		private double m_maxValue = 120;
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
			Grid_Base.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			ValueText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.DataContext = this;
			
		}

		void UpdateLabel()
		{
			if (LabelOrientation == LabelOrientationEnum.Vertical)
			{
				LabelAngle = -90;
			}else
			{
				LabelAngle = 0;
			}
		}

		void UpdateBarWidth() {
			double barValue;
			double lineValue;
			if (m_maxValue > 0)
			{
				if(m_value > m_maxValue)
				{
					barValue = m_maxValue;
					lineValue = (m_maxValue - m_value) - (m_maxValue - m_targetValue);
					lineValue += m_maxValue;
					if(lineValue < 0 )
					{
						lineValue = 0;
					}
				}else
				{
					barValue = m_value;
					lineValue = m_targetValue;
				}

				var target = m_maxValue / m_targetValue;
				var percent = (barValue * 100) / m_targetValue;
				percent = percent / target;
				BarWidth = (percent * (Grid_Base.ActualWidth - ValueText.ActualWidth - (ValueText.Margin.Left))) / 100;

				
				var linePercent = (lineValue * 100) / m_maxValue;
				TargetLinePos = ((linePercent * (Grid_Base.ActualWidth - ValueText.ActualWidth - (ValueText.Margin.Left))) / 100) - 1;

				
			}
		}

		private void SetTargetLineHeight() {
			Y1 = 0;
			Y2 = Grid_Base.ActualHeight;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e) {
			UpdateBarWidth();
			SetTargetLineHeight();
		}
		private void Grid_SizeChanged(object sender, SizeChangedEventArgs e) {
			UpdateBarWidth();
			SetTargetLineHeight();
		}
	}
}
