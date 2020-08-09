using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIRE_HEALTHY_CHECK_V1._0._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Titles.Add("Pie Chart");
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Points.AddXY("1", "50");
            chart1.Series["Series1"].Points.AddXY("2", "10");
            chart1.Series["Series1"].Points.AddXY("3", "10");
            chart1.Series["Series1"].Points.AddXY("4", "15");
            chart1.Series["Series1"].Points.AddXY("5", "15");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxDate.Text = "Date 15/04/2020";

            textBoxL_Input.Text = "Input 4000 HSA";
            textBoxL_OcrFail.Text = "OCR fail 2.00%";
            textBoxL_ReadabilityFail.Text = "Readability fail 2.00%";
            textBoxL_EtestFail.Text = "Etest Fail 5.00%";

            textBoxR_Input.Text = "Input 4000 HSA";
            textBoxR_OcrFail.Text = "OCR fail 2.00%";
            textBoxR_ReadabilityFail.Text = "Readability fail 2.00%";
            textBoxR_EtestFail.Text = "Etest Fail 5.00%";
        }
    }
}
