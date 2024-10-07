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

namespace BarLib.Bars
{
    /// <summary>
    /// Interaction logic for EfficiencyGroup.xaml
    /// </summary>
    public partial class EfficiencyGroup : UserControl
    {
		public enum OreantationEnum
		{
			Vertical , Horizontal
		}

		public OreantationEnum Oreantation { get; set; }
        public EfficiencyGroup()
        {
            InitializeComponent();
        }

		private void UpdateSize()
		{
			
		}
		public void UserControl_Loaded()
		{

		}
		public void Grid_SizeUpdated() { 
		}
    }
}
