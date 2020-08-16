using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_ListString
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        string[] str= new string[10000];


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list.Add("Hi");
            list.Add("              ");
            list.Add("Nirut");
            list.Add("007");
            str = list.ToArray();
            //int i = 0;
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
        }
    }
}
