using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_CheckStringInStr__
{
    public partial class Form1 : Form
    {
        string[] errorCode = { "0010", "0010" };
        string errorCheck = "1550";
        List<string> list = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (errorCode.Contains(errorCheck)) //Check string in string array
            {
                button1.BackColor = Color.LawnGreen;
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string check in errorCode)
            {
                if (errorCheck.Contains(check))
                {
                    button2.BackColor = Color.SkyBlue;
                    button2.Text = "Congraturation !";
                }
            }
        }

        private void buttonJoinString_Click(object sender, EventArgs e)
        {
            list.Add(errorCode[0]);
            list.Add(errorCheck);
            list.Add(errorCode[1]);
            errorCode = list.ToArray();
            foreach (string print in errorCode)
            {
                Console.WriteLine(print);
            }
        }
    }
}
