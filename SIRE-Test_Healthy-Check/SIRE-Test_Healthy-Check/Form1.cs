﻿using System;
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
        bool statusState_Delay = false; //Decare for check Function state_Delay is done?
        byte functionState = 0; //Initial State of Function state_Delay at state0
        double stateDownloadCsvFile = 0; //Initial State of Function download_CsvFile at state0
        double testShow = 10.0;
        int test = 0;
        bool switchStepRun = false; //Decare to test function by STEP Run
        bool switchDownloadCsvFile = false; //Decare for ON function download_CsvFile
        bool saveCsvFile = false; //Decare for ON function save_CsvFile
        bool readCsvFile = false; //Decare for ON function read_CsvFile
        bool searchDataInCsvFile = false; //Decare for ON function search_DataInCsvFile

        bool statusWebBrowser1DocumentCompleted = false; //Decare for check when webBrowser1_DocumentCompleted


        DataTable datatableWordWebCodeResponse = new DataTable(); //Decare to use Class DataTable to help checking
        AutoHand autoHand = new AutoHand();//Decare to use DLL File of AutoItX3
        //Point point = new Point(0, 0); //Decare point x=0, y=0
        Point point = new Point(0, 0); //Decare point x=0, y=0
        
        

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
            //textBox3.Text = testShow.ToString();
        }

        //##### Begin : My function Area #####
        //##### Begin : state_Delay
        public bool state_Delay(int intervalValue) //Delay function
        {
            switch(functionState)
            {
                case 0: //Initial variable
                    statusState_Delay = false;
                    functionState = 1;
                    break;
                case 1: //Set Interval and Enable timer1
                    timer1.Interval = intervalValue;
                    timer1.Enabled = true;
                    functionState = 2;
                    break;
                case 2: //Wait until timer1 will Tick
                    if(statusState_Delay == true)
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
            return statusState_Delay;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusState_Delay = true;
            timer1.Enabled = false;
        }
        //##### End : state_Delay

        //##### Begin : download_CsvFile
        private void download_CsvFile()  
        {
            if(switchDownloadCsvFile) 
            {
                switch(stateDownloadCsvFile)
                {
                    case 0: //Initial Variables
                        statusWebBrowser1DocumentCompleted = false;
                        stateDownloadCsvFile = 1;//Temp
                        break;
                    case 1: //State1 : Go URL, Index Page
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/index.jsp");
                        stateDownloadCsvFile = 2;
                        break;
                    case 2: //State2 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 3;
                        }
                        break;
                    case 3: //State3 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 4;
                        break;
                    case 4: //State4 : Go URL, Login Page
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/login");
                        stateDownloadCsvFile = 5;
                        break;
                    case 5: //State5 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Login Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 6;
                        }
                        break;
                    case 6: //State6 : Show WebCode Response from Server of Login Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 7;
                        break;
                    case 7: //State7 : Go URL, Entering Loging by Send Login UserName + Password
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On");
                        stateDownloadCsvFile = 8;
                        break;
                    case 8: //State8 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Entering Loging by Send Login UserName + Password
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 9;
                        }
                        break;
                    case 9: //State9 : Show WebCode Response from Server of Entering Loging by Send Login UserName + Password
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 10;
                        break;
                    case 10: //State10 : Show WebCode Response String Length from Server
                        textBoxWebCodeResponseStringLength.Text = textBoxWebCodeResponse.Text.Length.ToString();
                        stateDownloadCsvFile = 11;
                        break;
                    case 11: //State11 : Make SubString by Remove no need characters from Web Code Response
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(null); //SubState5.1 : Split null
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //SubState5.2
                        wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //SubState5.3 (InnerState5.1 to 5.3 = Remove no need characters)
                        stateDownloadCsvFile = 12;
                        break;
                    case 12: //State12 : Show WebCode Response SubString Length
                        textBoxWebCodeResponseSubStringLength.Text = wordWebCodeResponse.Length.ToString();
                        stateDownloadCsvFile = 13;
                        break;
                    case 13://State13 : Show WebCode Response Last SubString 
                        textBoxWebCodeResponseLastSubString.Text = wordWebCodeResponse.Last();
                        stateDownloadCsvFile = 14;
                        break;
                    case 14: //State14 : Clear all data in datatable
                        datatableWordWebCodeResponse.Clear();
                        stateDownloadCsvFile = 15;
                        break;
                    case 15: //State15 : Initial indexWordWebCodeResponse = 0
                        indexWordWebCodeResponse = 0;
                        stateDownloadCsvFile = 16;
                        break;
                    case 16: //State16 : Looping until last word in String Array wordWebCodeResponse
                        foreach (var word in wordWebCodeResponse) 
                        {
                            datatableWordWebCodeResponse.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                            indexWordWebCodeResponse++;
                        }
                        stateDownloadCsvFile = 17; 
                        break;
                    case 17: //State17 : Input dataGridView1 by datatableWordWebCodeResponse to show in Table
                        dataGridView1.DataSource = datatableWordWebCodeResponse;
                        stateDownloadCsvFile = 18;
                        break;
                    case 18: //State18 : Show wordWebCodeResponse[17] to textbox
                        textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17];
                        stateDownloadCsvFile = 19;
                        break;
                    case 19: //State19 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                        textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56);
                        stateDownloadCsvFile = 20;
                        break;
                    case 20: //State20 : Show ParametricDataRetrieveProductionDB URL to textbox
                        textBoxParametricDataRetrieveProductionDB.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56);
                        stateDownloadCsvFile = 21;
                        break;
                    case 21: //State22 : Test Open tabPage2 THEN Go ParametricDataRetrieveProductionDB Page
                        tabControl1.SelectedTab = tabPage2;
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56));
                        stateDownloadCsvFile = 22;
                        break;
                    case 22: //State23 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 23;
                        }
                        break;
                    case 23: //State24 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 24;
                        break;
                    case 100: //State16 : End This Function and Resetting variables
                        switchDownloadCsvFile = false;
                        stateDownloadCsvFile = 0;

                        

                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : download_CsvFile
        //##### End : My function Area #####

        private void Form1_Load(object sender, EventArgs e)
        {
            datatableWordWebCodeResponse.Columns.Add("INDEX");
            datatableWordWebCodeResponse.Columns.Add("WORD");
            switchDownloadCsvFile = true; //Start function : download_CsvFile()
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {   
            //this.webBrowser1.Navigate(textBoxUrlToGo.Text); //InnerState1 : Go URL
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusWebBrowser1DocumentCompleted = false; //Set status = false
        }

        public void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusWebBrowser1DocumentCompleted = true; //Set status = true
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
            download_CsvFile(); //Auto download CSV File
            textBox2.Text = stateDownloadCsvFile.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //autoHand.mouseMoveAndClick("LEFT", 196, 330, 1, 1);
            //autoHand.mouseScroll("DOWN", 1);
            //textBox1.Text = webBrowser1.Left.ToString();
            //textBox1.Left = 0;
            //textBox1.Top = 0;
            //Point p = new Point(0, 0); // Decare point x=0, y=0
            //Location = p; // Assign Location = point p
            //WindowState = FormWindowState.Maximized; //Assign Windows to Maximize
        }

    }
}


/* ##### Begin : Backup Code ######
 * 
 *                     case 25: //State25 : Set Window to Maximize
                        Location = point; //Assign Form1 Location = point(0, 0)
                        WindowState = FormWindowState.Maximized; //Assign Form1 Windows to Maximize
                        stateDownloadCsvFile = 100;
                        break;
                    case 26: //State26 : Test Clear Cache and Cookies
                                                
                        stateDownloadCsvFile = 26.1;
                        break;
                    case 26.1: //State26.1 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 26.2;
                        }
                        break;
                    case 26.2: //State26.2 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 26.3;
                        break;
                    case 26.3: //State26.3 : Delay a little bit
                        if (state_Delay(2000))
                        {
                            stateDownloadCsvFile = 27;
                        }
                        break;
                    case 27: //State27 : Select parameters in Parametric Data Retrieve(Production DB) Page
                        autoHand.mouseMoveAndClick("LEFT", 532, 167, 1, 10); //Move to Click at Tab, Standard Mode
                        autoHand.mouseMoveAndClick("LEFT", 472, 231, 1, 10); //Move to Click at M/T
                        stateDownloadCsvFile = 27.1;
                        break;
                    case 27.1: //State27.1 : Delay a little bit
                        if (state_Delay(1000))
                        {
                            stateDownloadCsvFile = 27.2;
                        }
                        break;
                    case 27.2: //State27.2 : Select parameters in Parametric Data Retrieve(Production DB) Page, Continue
                        autoHand.mouseDrag("LEFT", 472, 280, 472, 567, 5); //Drag to see PCM%
                        autoHand.mouseMoveAndClick("LEFT", 431, 449, 1, 5); //Move to Click at PCM%
                        autoHand.mouseMoveAndClick("LEFT", 834, 230, 1, 5); //Move to Click at Filter
                        stateDownloadCsvFile = 28;
                        break;
                    case 28: //State28 : Select parameters in Parametric Data Retrieve(Production DB) Page, continue
                        if (state_Delay(500))
                        {
                            autoHand.mouseMoveAndClick("LEFT", 577, 247, 1, 5); //Move to Click at PCM-ALL
                            stateDownloadCsvFile = 100;
                        }
                        break;
                    case 29: //State29 : Click at Retrieve Button
                        autoHand.mouseMoveAndClick("LEFT", 273, 760, 1, 5); //Move to Click at Retrieve Button
                        stateDownloadCsvFile = 30;
                        break;
                    case 30: //State30 : Delay a little bit
                        if (state_Delay(500))
                        {
                            stateDownloadCsvFile = 100;
                        }
                        break;
                    case 100: //State16 : End This Function and Resetting variables
                        switchDownloadCsvFile = false;
                        stateDownloadCsvFile = 0;

                        

                        break;
                    default:
                        break;
    ##### End : Backup Code ######

    */
