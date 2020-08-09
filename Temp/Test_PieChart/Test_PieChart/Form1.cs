using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_PieChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("ETEST FAIL");
            chart1.Series["s1"].IsValueShownAsLabel = true;
            chart1.Series["s1"].Points.AddXY("1", "10");
            chart1.Series["s1"].Points.AddXY("2", "26");
            chart1.Series["s1"].Points.AddXY("3", "300");
            chart1.Series["s1"].Points.AddXY("4", "300");
            chart1.Series["s1"].Points.AddXY("5", "45");
            chart1.Series["s1"].Points.AddXY("6", "45");
            chart1.Series["s1"].Points.AddXY("7", "45");
            chart1.Series["s1"].Points.AddXY("8", "45");

        }
    }
}
