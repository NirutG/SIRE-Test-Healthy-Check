using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_dataGridView
{

    public partial class Form1 : Form
    {
        int[] errorCodeQuantity = new int[1000]; //Decare for Store ErrorCode Quantity in dataGridView4
        int errorCodeIndex = 0; //Decare for separate ErrorCode count how many difference ErrorCode in dataGridView4
        DataTable datatableTest = new DataTable();
        public Form1()
        {
            InitializeComponent();
            datatableTest.Columns.Add("ErrorCodeNumber");
            datatableTest.Columns.Add("Q'ty");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            datatableTest.Rows.Add("0010", 1);
            datatableTest.Rows.Add("0095", 1);
            dataGridView1.DataSource = datatableTest;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            datatableTest.Rows[0][1] = 2;
            datatableTest.Rows[1][1] = "Hello NirutG";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorCodeIndex = 0;
            errorCodeQuantity[errorCodeIndex] = 1;
            //button1.Text = errorCodeQuantity[errorCodeIndex].ToString();
            button1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
        }
    }
}
