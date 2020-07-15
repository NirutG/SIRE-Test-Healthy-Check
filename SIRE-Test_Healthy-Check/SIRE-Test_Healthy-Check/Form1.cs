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
        byte functionState = 0; //Initial State of Function state_Delay at state0
        byte stateCsvFileDownload = 0; //Initial State of Function csvFile_Download at state0
        int test = 0;
        bool switchCsvFileDownload = false; //Decare for ON function csvFile_Download
        bool fgWebBrowser1_Navigated = false; //Decare for check when webBrowser1_Navigated


        DataTable datatableWordWebCodeResponse = new DataTable(); //Decare to use Class DataTable to help checking

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
        }

        //##### Begin : My function Area #####
        //##### Begin : state_Delay
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
        //##### End : state_Delay

        //##### Begin : csvFile_Download
        private void csvFile_Download()
        {
            if(switchCsvFileDownload) 
            {
                switch(stateCsvFileDownload)
                {
                    case 0: //Initial Variables
                        fgWebBrowser1_Navigated = false;
                        stateCsvFileDownload = 1;
                        break;
                    case 1: //State1 : Go URL, Index Page
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/index.jsp");
                        stateCsvFileDownload = 2;
                        break;
                    case 2: //State2 : After webBrowser1_Navigated, Show URL Response from Server of Index Page
                        if (fgWebBrowser1_Navigated)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateCsvFileDownload = 3;
                        }
                        break;
                    case 3: //State3 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateCsvFileDownload = 4;
                        break;
                    case 4: //State4 : Go URL, Login Page
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/login");
                        stateCsvFileDownload = 5;
                        break;
                    case 5: //State5 : After webBrowser1_Navigated, Show URL Response from Server of Login Page
                        if (fgWebBrowser1_Navigated)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateCsvFileDownload = 6;
                        }
                        break;
                    case 6: //State6 : Show WebCode Response from Server of Login Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateCsvFileDownload = 7;
                        break;
                    case 7: //State7 : Go URL, Entering Loging by Send Login UserName + Password
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On");
                        stateCsvFileDownload = 8;
                        break;
                    case 8: //State8 : After webBrowser1_Navigated, Show URL Response from Server of Entering Loging by Send Login UserName + Password
                        if (fgWebBrowser1_Navigated)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateCsvFileDownload = 9;
                        }
                        break;
                    case 9: //State9 : Show WebCode Response from Server of Entering Loging by Send Login UserName + Password
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateCsvFileDownload = 10;
                        break;


                    case 10: //State10 : Show WebCode Response String Length from Server
                        textBoxWebCodeResponseStringLength.Text = textBoxWebCodeResponse.Text.Length.ToString();
                        stateCsvFileDownload = 11;
                        break;
                    case 11: //State11 : Make SubString by Remove no need characters from Web Code Response
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(null); //SubState5.1 : Split null
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //SubState5.2
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //SubState5.3 (InnerState5.1 to 5.3 = Remove no need characters)
                        stateCsvFileDownload = 12;
                        break;
                    case 12: //State12 : Show WebCode Response SubString Length
                        textBoxWebCodeResponseSubStringLength.Text = wordWebCodeResponse.Length.ToString();
                        stateCsvFileDownload = 13;
                        break;
                    case 13://State13 : Show WebCode Response Last SubString 
                        textBoxWebCodeResponseLastSubString.Text = wordWebCodeResponse.Last();
                        stateCsvFileDownload = 14;
                        break;
                    case 14: //State14 : Clear all data in datatable
                        datatableWordWebCodeResponse.Clear();
                        stateCsvFileDownload = 15;
                        break;
                    case 15: //State15 : Initial indexWordWebCodeResponse = 0
                        indexWordWebCodeResponse = 0;
                        stateCsvFileDownload = 16;
                        break;
                    case 16: //State16 : Looping until last word in String Array wordWebCodeResponse
                        foreach (var word in wordWebCodeResponse) 
                        {
                            datatableWordWebCodeResponse.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                            indexWordWebCodeResponse++;
                        }
                        stateCsvFileDownload = 17; 
                        break;
                    case 17: //State17 : Input dataGridView1 by datatableWordWebCodeResponse to show in Table
                        dataGridView1.DataSource = datatableWordWebCodeResponse;
                        stateCsvFileDownload = 18;
                        break;
                    case 18: //State18 : Show wordWebCodeResponse[17] to textbox
                        textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17];
                        stateCsvFileDownload = 19;
                        break;
                    case 19: //State19 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                        textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56);
                        stateCsvFileDownload = 20;
                        break;
                    case 20: //State20 : Show Parametric URL 1 to textbox
                        textBoxParametricUrl1.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56);
                        stateCsvFileDownload = 21;
                        break;
                    case 21: //State21 : Go Parametric URL1
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56));
                        stateCsvFileDownload = 100;
                        break;

                    //Test
                    //case 22: //StateXX : Go Parametric URL2&3

                    case 100: //State16 : End This Function and Resetting variables
                        switchCsvFileDownload = false;
                        stateCsvFileDownload = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : csvFile_Download
        //##### End : My function Area #####

        private void Form1_Load(object sender, EventArgs e)
        {
            datatableWordWebCodeResponse.Columns.Add("INDEX");
            datatableWordWebCodeResponse.Columns.Add("WORD");
            switchCsvFileDownload = true; //Start function : csvFile_Download()
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {   
            //this.webBrowser1.Navigate(textBoxUrlToGo.Text); //InnerState1 : Go URL
        }

        public void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //textBoxUrlResponse.Text = "" + webBrowser1.Url; //InnerState2 : Show URL Response from Server
            //textBoxWebCodeResponse.Text = webBrowser1.DocumentText; //InnerState3 : Show WebCode Response from Server
            //textBoxWebCodeResponseStringLength.Text = textBoxWebCodeResponse.Text.Length.ToString(); //InnerState4 : Show WebCode Response String Length from Server
            /*
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(null); //InnerState5.1 : Split null
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //InnerState5.2
            wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //InnerState5.3 (InnerState5.1 to 5.3 = Remove no need characters)
            */
            //textBoxWebCodeResponseSubStringLength.Text = wordWebCodeResponse.Length.ToString(); //InnerState6 : Show WebCode Response SubString Length
            //textBoxWebCodeResponseLastSubString.Text = wordWebCodeResponse.Last(); //InnerState7 : Show WebCode Response Last SubString
            //datatableWordWebCodeResponse.Clear(); //InnerState8 : Clear all data in datatable
            //indexWordWebCodeResponse = 0; //InnerState9 : Initial indexWordWebCodeResponse = 0
            /*
            foreach (var word in wordWebCodeResponse) //InnerState10 : Looping until last word in String Array wordWebCodeResponse
            {
                datatableWordWebCodeResponse.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                indexWordWebCodeResponse++;
            }
            */
            //dataGridView1.DataSource = datatableWordWebCodeResponse; //InnerState11 : Input dataGridView1 by datatableWordWebCodeResponse to show in Table
            fgWebBrowser1_Navigated = true; //ON Flag after webBrowser1_Navigated
        }

        private void buttonTestTrim_Click(object sender, EventArgs e) //Must Do After Login completed
        {
            //textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17]; //InnerState12 : Show wordWebCodeResponse[17] to textbox
            //textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56); //InnerState13 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
            //textBoxParametricUrl1.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56); //InnerState14 : Show Parametric URL 1 to textbox
        }

        private void buttonTestGoParametricUrl1_Click(object sender, EventArgs e)
        {
            //this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56)); //InnerState15 : Go Parametric URL 1
        }

        private void timerStateCyclic_Tick(object sender, EventArgs e)
        {
            csvFile_Download(); //Auto download CSV File
        }

    }
}
