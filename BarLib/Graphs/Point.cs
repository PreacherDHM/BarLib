using System;
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
	///  Point is a object that contains a value and a X and Y position 
	///  so that it may be ploted on a graph.
	/// </summary>
	public class Point : Control
	{
		public string Value { get; set; }
		public double XPosition { get; set; }
		public double YPosition { get; set; }
		static Point()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Point), new FrameworkPropertyMetadata(typeof(Point)));
		}
	}
}
