﻿using System;
using System.Collections.Generic;
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

namespace BarLib.Graphs
{
	/// <summary>
	/// Interaction logic for LineChart.xaml
	/// </summary>
	public partial class LineChart : UserControl
	{
		public List<Point> Points { get; set; } = new List<Point>();
		public Point Point { set { Points.Add(value); } }

		public LineChart()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{

			int sizeOfPoints = Points.Count;
			MessageBox.Show(Points[sizeOfPoints - 1].Value);
		}
	}
}
