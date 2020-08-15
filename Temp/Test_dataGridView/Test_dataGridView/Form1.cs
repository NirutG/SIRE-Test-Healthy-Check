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
        string checkCode = "";
        string[] errorCode = new string[5];
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            datatableTest.Columns.Add("ErrorCodeNumber");
            datatableTest.Columns.Add("Q'ty");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            datatableTest.Rows.Add("0010", 1);
            datatableTest.Rows.Add("0010", 1);
            datatableTest.Rows.Add("0005", 1);
            datatableTest.Rows.Add("0010", 2);
            datatableTest.Rows.Add("1234", 17);
            dataGridView3.DataSource = datatableTest;
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
            button1.Text = dataGridView3.Rows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow code in dataGridView3.Rows)
            {
                checkCode += code.Cells["ErrorCodeNumber"].Value + " ";
            }
            textBox1.Text = checkCode;
            foreach (var check in checkCode)
            {
                errorCode = checkCode.Split(' ');
                textBox2.Text = errorCode[0] + " " + errorCode[1] + " " + errorCode[2] + " " + errorCode[3] + " " + errorCode[4];
            }
            
        }
    }
}
