using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIRE_Test_Healthy_Check
{
    public partial class Form1 : Form
    {
        //##### Begin : Decare variable in Form1 #####
        string[] wordWebCodeResponse; //Decare String Array to check Word in textBoxWebCodeResponse
        int indexWordWebCodeResponse = 0; //Decare to check Index of string array, wordWebCodeResponse
        bool fgState_Delay = false; //Decare for check Function state_Delay is done?
        byte functionState = 0; //Decare functionState for state_Delay Function
        int test = 0;

        DataTable datatableWordWebCodeResponse = new DataTable(); //Decare to use Class DataTable to help checking

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
        }

        //##### Begin : My function Area
        public bool state_Delay(int intervalValue) //Delay function
        {
            switch(functionState)
            {
                case 0: //Initial variable
                    fgState_Delay = false;
                    functionState = 1;
                    break;
                case 1: //Set Interval and Enable timer1
                    timer1.Interval = intervalValue;
                    timer1.Enabled = true;
                    functionState = 2;
                    break;
                case 2: //Wait until timer1 will Tick
                    if(fgState_Delay == true)
                    {
                        functionState = 0;
                    }
                    else
                    {
                        functionState = 2;
                    }
                    break;
                default:
                    break;
            }
            return fgState_Delay;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            fgState_Delay = true;
            timer1.Enabled = false;
        }

        //##### End : My function Area
        private void Form1_Load(object sender, EventArgs e)
        {
            datatableWordWebCodeResponse.Columns.Add("INDEX");
            datatableWordWebCodeResponse.Columns.Add("WORD");
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {   
            this.webBrowser1.Navigate(textBoxUrlToGo.Text); //InnerState1 : Go URL
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBoxUrlResponse.Text = "" + webBrowser1.Url; //InnerState2 : Show URL Response from Server
            textBoxWebCodeResponse.Text = webBrowser1.DocumentText; //InnerState3 : Show WebCode Response from Server
            textBoxWebCodeResponseStringLength.Text = textBoxWebCodeResponse.Text.Length.ToString(); //InnerState4 : Show WebCode Response String Length from Server
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(null); //InnerState5.1 : Split null
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //InnerState5.2
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //InnerState5.3 (InnerState5.1 to 5.3 = Remove no need characters)
            textBoxWebCodeResponseSubStringLength.Text = wordWebCodeResponse.Length.ToString(); //InnerState6 : Show WebCode Response SubString Length
            textBoxWebCodeResponseLastSubString.Text = wordWebCodeResponse.Last(); //InnerState7 : Show WebCode Response Last SubString
            datatableWordWebCodeResponse.Clear(); //InnerState8 : Clear all data in datatable
            indexWordWebCodeResponse = 0; //InnerState9 : Initial indexWordWebCodeResponse = 0
            foreach (var word in wordWebCodeResponse) //InnerState10 : Looping until last word in String Array wordWebCodeResponse
            {
                datatableWordWebCodeResponse.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                indexWordWebCodeResponse++;
            }
            dataGridView1.DataSource = datatableWordWebCodeResponse; //InnerState11 : Input dataGridView1 by datatableWordWebCodeResponse to show in Table
        }

        private void buttonTestTrim_Click(object sender, EventArgs e) //Must Do After Login completed
        {
            textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17]; //InnerState12 : Show wordWebCodeResponse[17] to textbox
            textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56); //InnerState13 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
            textBoxParametricUrl1.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56); //InnerState14 : Show Parametric URL 1 to textbox
        }

        private void buttonTestGoParametricUrl1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56)); //InnerState15 : Go Parametric URL 1
            
        }

        private void timerStateCyclic_Tick(object sender, EventArgs e)
        {

        }

    }
}
