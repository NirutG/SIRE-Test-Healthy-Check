using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_SaveFile
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            openFileDialog1.DefaultExt = "*.txt";
            openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("เปิดไฟล์ "+openFileDialog1.FileName.ToString()+" เสร็จแล้ว");
            }
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.DefaultExt = "*.txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("คุณได้บันทึกไฟล์ "+saveFileDialog1.FileName.ToString()+" เสร็จแล้ว");
            }
            
            if (saveFileDialog1.CreatePrompt == true)
            {
                buttonSave.BackColor = Color.Pink;
            }
        }
        
        private void buttonTest_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Dropbox\NirutG\Clients\Temp ";
            saveFileDialog.FileName = "Goob";
        }
    }
}
