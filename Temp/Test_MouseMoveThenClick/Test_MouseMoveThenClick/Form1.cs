using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_MouseMoveThenClick
{
    public partial class Form1 : Form
    {
        AutoIt AutoHand = new AutoIt();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoHand.mClick("LEFT", 1520, 427, 1, 1); //Mouse move then click, x=___, y=____
            AutoHand.mScroll("DOWN", 10);
        }

    }
}
