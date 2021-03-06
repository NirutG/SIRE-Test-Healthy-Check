﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIRE_Test_Healthy_Check
{
    public partial class Form1 : Form
    {
        //##### Begin : Decare variable in Form1 #####
        string[] wordWebCodeResponseA; //Check Word in textBoxWebCodeResponseA
        string[] wordWebCodeResponseB; //Check Word in textBoxWebCodeResponseB
        int indexWordWebCodeResponseA = 0; //Index of string array, wordWebCodeResponseA
        int indexWordWebCodeResponseB = 0; //Index of string array, wordWebCodeResponseB

        bool statusWebBrowser1DocumentCompleted = false; //Decare for check when webBrowser1_DocumentCompleted
        bool statusWebBrowser2DocumentCompleted = false; //Decare for check when webBrowser2_DocumentCompleted
        bool statusDelayA = false; //Check Function delay_StateA is done?
        bool statusDelayB = false; //Check Function delay_StateB is done?
        bool statusAddWordInRowTableA = false; //Check Function addword_InRowTableA is done?
        bool statusAddWordInRowTableB = false; //Check Function addword_InRowTableB is done?
        bool statusFindWordIndexA = false; //Check Function find_WordIndexA is done?
        bool statusFindWordIndexB = false; //Check Function find_WordIndexB is done?
        bool statusGoUrlA = false; //Check Function go_UrlA is done?
        bool statusGoUrlB = false; //Check Function go_UrlB is done?
        bool statusShowUrlToRetrieveProcessA = false; //Check Function show_UrlToRetrieveProcessA
        bool statusShowUrlToRetrieveProcessB = false; //Check Function show_UrlToRetrieveProcessB
        bool statusShowUrlToRetrieveParamA = false; //Check Function show_UrlToRetrieveParamA
        bool statusShowUrlToRetrieveParamB = false; //Check Function show_UrlToRetrieveParamB
        bool statusShow_UrlToGetCsvDataA = false; //Check Function show_UrlToGetCsvDataA
        bool statusShow_UrlToGetCsvDataB = false; //Check Function show_UrlToGetCsvDataB

        byte stateDelayA = 0; //Initial State of Function delay at state0
        byte stateDelayB = 0; //Initial State of Function delay at state0
        byte stateAddWordInRowTableA = 0; //Initial State of Function addword_InRowTableA
        byte stateAddWordInRowTableB = 0; //Initial State of Function addword_InRowTableB
        byte stateFindWordIndexA = 0; //Initial State of Function find_WordIndexA
        byte stateFindWordIndexB = 0; //Initial State of Function find_WordIndexB
        byte stateGoUrlA = 0; //Initial State of Function go_UrlA
        byte stateGoUrlB = 0; //Initial State of Function go_UrlB
        byte stateShowUrlToRetrieveProcessA = 0; //Initial State of Function show_UrlToRetrieveProcessA
        byte stateShowUrlToRetrieveProcessB = 0; //Initial State of Function show_UrlToRetrieveProcessB
        double stateShowUrlToRetrieveParamA = 0; //Initial State of Function show_UrlToRetrieveParamA
        double stateShowUrlToRetrieveParamB = 0; //Initial State of Function show_UrlToRetrieveParamB
        double stateShow_UrlToGetCsvDataA = 0; //Initial State of Function show_UrlToGetCsvDataA
        double stateShow_UrlToGetCsvDataB = 0; //Initial State of Function show_UrlToGetCsvDataB


        string[] wordSplitA; //Decare String array to use in Function split_TextA()
        string[] wordSplitB; //Decare String array to use in Function split_TextB()
        string urlToRetrieveParamA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParamA
        string urlToRetrieveParamB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParamB
        string urlToGetCsvDataA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParamA
        string urlToGetCsvDataB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParamB
        string wordTarget = ""; //Initial to use with Function fine_Word()
        string[] wordCsvDataRowA; //Decare String array to receive CSV Data separate by Row
        string[] wordCsvDataRowB; //Decare String array to receive CSV Data separate by Row
        string[] wordCsvDataColumnA; //Decare String array to receive CSV Data separate by Column
        string[] wordCsvDataColumnB; //Decare String array to receive CSV Data separate by Column
        int indexCsvDataRowA = 0; //Decare to be Row index of CsvDataA
        int indexCsvDataRowB = 0; //Decare to be Row index of CsvDataB
        int indexCsvDataColumnA = 0; //Decare to be Column index of CsvDataA
        int indexCsvDataColumnB = 0; //Decare to be Column index of CsvDataB

        string wordRunningA = ""; //Initial to use in Function find_WordIndexA
        string wordRunningB = ""; //Initial to use in Function find_WordIndexB
        int indexRunningA = 0; //Initial to use in Function find_WordIndexA
        int indexRunningB = 0; //Initial to use in Function find_WordIndexB

        int indexParam1800HeadA = 0; //Initial to use in Function show_UrlToGetCsvDataA()
        int indexParam1800UnitA = 0; //Initial to use in Function show_UrlToGetCsvDataA()
        int indexParam1800HeadValueA = 0; //Initial to use in Function show_UrlToGetCsvDataA()
        int indexParam1800UnitValueA = 0; //Initial to use in Function show_UrlToGetCsvDataA()

        int indexParam1800HeadB = 0; //Initial to use in Function show_UrlToGetCsvDataB()
        int indexParam1800UnitB = 0; //Initial to use in Function show_UrlToGetCsvDataB()
        int indexParam1800HeadValueB = 0; //Initial to use in Function show_UrlToGetCsvDataB()
        int indexParam1800UnitValueB = 0; //Initial to use in Function show_UrlToGetCsvDataB()

        double testShow = 10.0;
        int test = 0;
        bool switchStepRun = false; //Decare to test function by STEP Run
        bool switchDownloadCsvDataA = false; //Decare for ON function download_CsvDataA
        bool switchDownloadCsvDataB = false; //Decare for ON function download_CsvDataB
        bool switchDisplayData = false; //Decare for ON function display_Data
        bool switchDisplayDataA = false; //Decare for ON function display_DataA
        bool switchDisplayDataB = false; //Decare for ON function display_DataB

        double stateDownloadCsvDataA = 0; //Initial State of Function download_CsvDataA at state0
        double stateDownloadCsvDataB = 0; //Initial State of Function download_CsvDataB at state0
        byte stateDisplayData = 0; //Initial State of Function display_Data at state0
        byte subStateDisplayData1 = 0; //Initial subStateDisplayData1 of Function display_Data at State2
        byte stateDisplayDataA = 0; //Initial State of Function display_DataA
        byte stateDisplayDataB = 0; //Initial State of Function display_DataB

        int errorCodeTotal = 0; //Initial Count Total Error Code
        int errorCodePass = 0; //Initial Count Pass Error Coded
        int errorCodeFail = 0; //Initial Count Fail Error Code
        int countErrorCodeLoop = 0; //Initial errorCodeFail counting 
        string checkColumnPfcd = ""; //Initial for check Column Name : PFCD

        int indexDataGridView3 = 0;
        int indexDataGridView4 = 0; //Decare for separate ErrorCode count how many difference ErrorCode in dataGridView4
        string[] errorCode = new string[100000000]; //Decare for store ErrorCode 
        int[] errorCodeQuantity = new int[10000]; //Decare for Store ErrorCode Quantity in dataGridView4
        int errorCodeShiftRow = 0; //Decare for shift row down to work together with errorCodeQuantity
        string errorCodeInColumn = "";
        string errorCodeCheck = "";
        string[] errorCodeNumber = new string[10000]; //Decare for inside loop to remember difference ErrorCodeNumber
        List<string> list = new List<string>(); //Decare for add each difference ErrorCode into errorCodeNumber[]

        DataTable dataTable1A = new DataTable(); //Decare to use Class DataTable to help checking
        DataTable dataTable1B = new DataTable(); //Decare to use Class DataTable to help checking
        DataTable dataTable2A = new DataTable(); //Decare to use Class DataTable to help checking CSV Data
        DataTable dataTable2B = new DataTable(); //Decare to use Class DataTable to help checking CSV Data
        DataTable dataTable3A = new DataTable(); //Decare to use Class DataTable to display_DataA
        DataTable dataTable3B = new DataTable(); //Decare to use Class DataTable to display_DataToday

        //AutoHand autoHand = new AutoHand();//Decare to use DLL File of AutoItX3
        //Point point = new Point(0, 0); //Decare point x=0, y=0
        Point point = new Point(0, 0); //Decare point x=0, y=0
        WebClient webClient1 = new WebClient();

        int timeA = 0; //Initial Check Time of ProcessA
        int timeB = 0; //Initial Check Time of ProcessB
        bool switchB = false; //Initial switch of ProcessB
        int inputHSA = 0; //Initial to count HSA
        byte lineHeadL_A = 1; //Initial for G2_(L) of ProcessA
        byte lineHeadR_A = 2; //Initial for G2_(R) of ProcessA
        int inputLineHeadL_A = 0; //Initial to count HSA Head L of ProcessA
        int inputLineHeadR_A = 0; //Initial to count HSA Head L of ProcessA
        double readabilityFailTarget_A = 0.50; //Initial to check HGA Read Target of ProcessA
        double etesterFailTarget_A = 5.00; //Initial to check HSA ETEST Fail Target of ProcessA
        double badOCRTarget_A = 0.50; //Initial to check HGA BAD OCR Target of ProcessA
        double readabilityFailLineHeadL_A = 0; //Initial to check HGA Head L of ProcessA
        double readabilityFailLineHeadR_A = 0; //Initial to check HGA Head R of ProcessA
        double etesterFailLineHeadL_A = 0; //Initial to check HSA Head L of ProcessA
        double etesterFailLineHeadR_A = 0; //Initial to check HSA Head R of ProcessA
        double badOCRLineHeadL_A = 0; //Initial to check HGA Head L of ProcessA
        double badOCRLineHeadR_A = 0; //Initial to check HGA Head R of ProcessA
        string softwareVersionL_A = ""; //Initial to check Software Version Head L of ProcessA
        string softwareVersionR_A = ""; //Initial to check Software Version Head R of ProcessA

        byte lineHeadL_B = 1; //Initial for G2_(L) of ProcessB
        byte lineHeadR_B = 2; //Initial for G2_(R) of ProcessB
        int inputLineHeadL_B = 0; //Initial to count HSA Head L of ProcessB
        int inputLineHeadR_B = 0; //Initial to count HSA Head L of ProcessB
        double readabilityFailTarget_B = 0.50; //Initial to check HGA Read Target of ProcessB
        double etesterFailTarget_B = 5.00; //Initial to check HSA ETEST Fail Target of ProcessB
        double badOCRTarget_B = 0.50; //Initial to check HGA BAD OCR Target of ProcessB
        double readabilityFailLineHeadL_B = 0; //Initial to check HGA Head L of ProcessB
        double readabilityFailLineHeadR_B = 0; //Initial to check HGA Head R of ProcessB
        double etesterFailLineHeadL_B = 0; //Initial to check HSA Head L of ProcessB
        double etesterFailLineHeadR_B = 0; //Initial to check HSA Head R of ProcessB
        double badOCRLineHeadL_B = 0; //Initial to check HGA Head L of ProcessB
        double badOCRLineHeadR_B = 0; //Initial to check HGA Head R of ProcessB
        string softwareVersionL_B = ""; //Initial to check Software Version Head L of ProcessB
        string softwareVersionR_B = ""; //Initial to check Software Version Head R of ProcessB

        string[] genesis = {"G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP" }; //genesis[0] to genesis[23]
        //G2_(L) = Column1, G2_(R) = Column2
        //G3_(L) = Column3, G3_(R) = Column4
        //G4_(L) = Column5, G4_(R) = Column6
        //G5_(L) = Column7, G5_(R) = Column8
        //G6_(L) = Column9, G6_(R) = Column10
        //G7_(L) = Column11, G7_(R) = Column12
        //G8_(L) = Column13, G8_(R) = Column14
        //G9_(L) = Column15, G9_(R) = Column16
        //GA_(L) = Column17, GA_(R) = Column18
        //GB_(L) = Column19, GB_(R) = Column20
        //GC_(L) = Column21, GC_(R) = Column22
        //GD_(L) = Column23, GD_(R) = Column24
        //GE_(L) = Column25, GE_(R) = Column26
        //GF_(L) = Column27, GF_(R) = Column28
        //GG_(L) = Column29, GG_(R) = Column30
        //GH_(L) = Column31, GH_(R) = Column32
        //GI_(L) = Column33, GI_(R) = Column34
        //GJ_(L) = Column35, GJ_(R) = Column36
        //GK_(L) = Column37, GK_(R) = Column38
        //GL_(L) = Column39, GL_(R) = Column40
        //GM_(L) = Column41, GM_(R) = Column42
        //GN_(L) = Column43, GN_(R) = Column44
        //GO_(L) = Column45, GO_(R) = Column46
        //GP_(L) = Column47, GP_(R) = Column48

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
            timerStateCyclic.Start(); //Add new
        }

        //##### Begin : My function Area #####

        //##### Begin : check_Time
        private void check_Time()
        {
            textBoxTimeA.Text = DateTime.Now.ToString("HH:mm:ss").Replace(":", ""); //Get Time form computer
            textBoxTimeB.Text = DateTime.Now.ToString("HH:mm:ss").Replace(":", ""); //Get Time form computer
            timeB = int.Parse(textBoxTimeB.Text);

            if((timeB >= 090000)&&(timeB < 235500)) //Check Time to use Function download_CsvDataB() must between 09:00 to 23:54
            {
                switchB = true;
                textBoxTimeB.BackColor = Color.LawnGreen;
            }
            else
            {
                switchB = false;
                textBoxTimeB.BackColor = Color.Red;
            }
        }
        //##### End : check_Time

        //##### Begin : delay_StateA
        public bool delay_StateA(int intervalValue) //Delay function
        {
            switch(stateDelayA)
            {
                case 0: //Initial variable
                    statusDelayA = false;
                    stateDelayA = 1;
                    break;
                case 1: //Set Interval and Enable timer1
                    timer1.Interval = intervalValue;
                    timer1.Enabled = true;
                    timer1.Start(); //Added new
                    stateDelayA = 2;
                    break;
                case 2: //Wait until timer1 will Tick
                    if(statusDelayA == true)
                    {
                        stateDelayA = 0;
                    }
                    else
                    {
                        stateDelayA = 2;
                    }
                    break;
                default:
                    break;
            }
            return statusDelayA;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusDelayA = true;
            timer1.Stop(); //Added new
            timer1.Enabled = false;
        }
        //##### End : delay_StateA

        //##### Begin : delay_StateB
        public bool delay_StateB(int intervalValue) //Delay function
        {
            switch (stateDelayB)
            {
                case 0: //Initial variable
                    statusDelayB = false;
                    stateDelayB = 1;
                    break;
                case 1: //Set Interval and Enable timer2
                    timer2.Interval = intervalValue;
                    timer2.Enabled = true;
                    timer2.Start(); //Added new
                    stateDelayB = 2;
                    break;
                case 2: //Wait until timer2 will Tick
                    if (statusDelayB == true)
                    {
                        stateDelayB = 0;
                    }
                    else
                    {
                        stateDelayB = 2;
                    }
                    break;
                default:
                    break;
            }
            return statusDelayA;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            statusDelayB = true;
            timer2.Stop(); //Added new
            timer2.Enabled = false;
        }
        //##### End : delay_StateB

        //##### Begin : go_UrlA
        private bool go_UrlA(string url)
        {
            switch (stateGoUrlA)
            {
                case 0: //State0 : Initial Variables
                    statusGoUrlA = false;
                    stateGoUrlA = 1;
                    break;
                case 1: //State1 : Go URL
                    this.webBrowser1.Navigate(url);
                    stateGoUrlA = 2;
                    break;
                case 2: //State2 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                    if (statusWebBrowser1DocumentCompleted)
                    {
                        textBoxUrlResponseA.Text = "" + webBrowser1.Url;
                        stateGoUrlA = 3;
                    }
                    break;
                case 3: //State3 : Show WebCode Response from Server of Index Page
                    textBoxWebCodeResponseA.Text = webBrowser1.DocumentText;
                    stateGoUrlA = 4;
                    break;
                case 4: //State4 : Clear Variables
                    statusGoUrlA = true;
                    stateGoUrlA = 0;
                    break;
                default:
                    break;
            }
        return statusGoUrlA;
        }
        //##### End : go_UrlA

        //##### Begin : go_UrlB
        private bool go_UrlB(string url)
        {
            switch (stateGoUrlB)
            {
                case 0: //State0 : Initial Variables
                    statusGoUrlB = false;
                    stateGoUrlB = 1;
                    break;
                case 1: //State1 : Go URL
                    this.webBrowser2.Navigate(url);
                    stateGoUrlB = 2;
                    break;
                case 2: //State2 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                    if (statusWebBrowser2DocumentCompleted)
                    {
                        textBoxUrlResponseB.Text = "" + webBrowser2.Url;
                        stateGoUrlB = 3;
                    }
                    break;
                case 3: //State3 : Show WebCode Response from Server of Index Page
                    textBoxWebCodeResponseB.Text = webBrowser2.DocumentText;
                    stateGoUrlB = 4;
                    break;
                case 4: //State4 : Clear Variables
                    statusGoUrlB = true;
                    stateGoUrlB = 0;
                    break;
                default:
                    break;
            }
            return statusGoUrlB;
        }
        //##### End : go_UrlB

        //##### Begin : addWordInRow_TableA
        private bool addword_InRowTableA()
        {
            switch (stateAddWordInRowTableA)
            {
                case 0: //Initial Variables
                    statusAddWordInRowTableA = false;
                    stateAddWordInRowTableA = 1;
                    break;
                case 1: //State1 : Show WebCode Response String Length from Server
                    textBoxWebCodeResponseStringLengthA.Text = textBoxWebCodeResponseA.Text.Length.ToString();
                    stateAddWordInRowTableA = 2;
                    break;
                case 2: //State2 : Make SubString by Remove no need characters from Web Code Response
                    textBoxWebCodeResponseA.Text = Regex.Replace(textBoxWebCodeResponseA.Text, "\t|\n|\r", ""); //Test1 = OK
                    //textBoxWebCodeResponse.Text = Regex.Replace(textBoxWebCodeResponse.Text, @"\\s+", ""); //Test2 = Not OK

                    wordWebCodeResponseA = textBoxWebCodeResponseA.Text.Split(null); //SubState2.1 : Split null
                    wordWebCodeResponseA = textBoxWebCodeResponseA.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //SubState2.2
                    wordWebCodeResponseA = textBoxWebCodeResponseA.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //SubState2.3 (InnerState2.1 to 2.3 = Remove no need characters)

                    stateAddWordInRowTableA = 3;
                    break;
                case 3: //State3 : Show WebCode Response SubString Length
                    textBoxWebCodeResponseSubStringLengthA.Text = wordWebCodeResponseA.Length.ToString();
                    stateAddWordInRowTableA = 4;
                    break;
                case 4://State4 : Show WebCode Response Last SubString 
                    textBoxWebCodeResponseLastSubStringA.Text = wordWebCodeResponseA.Last();
                    stateAddWordInRowTableA = 5;
                    break;
                case 5: //State5 : Clear all data in datatable
                    dataTable1A.Clear(); //Clear datatable
                    stateAddWordInRowTableA = 6;
                    break;
                case 6: //State6 : Initial indexWordWebCodeResponseA = 0
                    indexWordWebCodeResponseA = 0;
                    stateAddWordInRowTableA = 7;
                    break;
                case 7: //State7 : Looping until last word in String Array wordWebCodeResponseA
                    foreach (var word in wordWebCodeResponseA)
                    {
                        dataTable1A.Rows.Add(indexWordWebCodeResponseA.ToString(), wordWebCodeResponseA[indexWordWebCodeResponseA]); //Add Data to new Row in Table
                        indexWordWebCodeResponseA++;
                    }
                    stateAddWordInRowTableA = 8;
                    break;
                case 8: //State8 : Input dataGridViewA1 by dataTable1A to show in Table
                    dataGridView1A_Birth(); //dataGridView1A Birth
                    dataGridView1A.DataSource = dataTable1A;
                    dataGridView1A_Die(); //dataGridView1A Die
                    stateAddWordInRowTableA = 9;
                    break;
                case 9: //State9 : Clear Variable
                    stateAddWordInRowTableA = 0;
                    statusAddWordInRowTableA = true;
                    break;
                default:
                    break;
            }
            return statusAddWordInRowTableA;
        }
        //##### End : addWordInRow_TableA

        //##### Begin : addWordInRow_TableB
        private bool addword_InRowTableB()
        {
            switch (stateAddWordInRowTableB)
            {
                case 0: //Initial Variables
                    statusAddWordInRowTableB = false;
                    stateAddWordInRowTableB = 1;
                    break;
                case 1: //State1 : Show WebCode Response String Length from Server
                    textBoxWebCodeResponseStringLengthB.Text = textBoxWebCodeResponseB.Text.Length.ToString();
                    stateAddWordInRowTableB = 2;
                    break;
                case 2: //State2 : Make SubString by Remove no need characters from Web Code Response
                    textBoxWebCodeResponseB.Text = Regex.Replace(textBoxWebCodeResponseB.Text, "\t|\n|\r", ""); //Test1 = OK
                    //textBoxWebCodeResponse.Text = Regex.Replace(textBoxWebCodeResponse.Text, @"\\s+", ""); //Test2 = Not OK

                    wordWebCodeResponseB = textBoxWebCodeResponseB.Text.Split(null); //SubState2.1 : Split null
                    wordWebCodeResponseB = textBoxWebCodeResponseB.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //SubState2.2
                    wordWebCodeResponseB = textBoxWebCodeResponseB.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //SubState2.3 (InnerState2.1 to 2.3 = Remove no need characters)

                    stateAddWordInRowTableB = 3;
                    break;
                case 3: //State3 : Show WebCode Response SubString Length
                    textBoxWebCodeResponseSubStringLengthB.Text = wordWebCodeResponseB.Length.ToString();
                    stateAddWordInRowTableB = 4;
                    break;
                case 4://State4 : Show WebCode Response Last SubString 
                    textBoxWebCodeResponseLastSubStringB.Text = wordWebCodeResponseB.Last();
                    stateAddWordInRowTableB = 5;
                    break;
                case 5: //State5 : Clear all data in datatable
                    //dataTable1B.Clear();
                    dataTable1B.Clear(); //Clear datatable
                    //dataTable1B.Columns.Clear(); //Clear Columns of datatable
                    //dataTable1B.Rows.Clear(); //Clear Rows of datatable
                    stateAddWordInRowTableB = 6;
                    break;
                case 6: //State6 : Initial indexWordWebCodeResponseB = 0
                    indexWordWebCodeResponseB = 0;
                    stateAddWordInRowTableB = 7;
                    break;
                case 7: //State7 : Looping until last word in String Array wordWebCodeResponseB
                    foreach (var word in wordWebCodeResponseB)
                    {
                        dataTable1B.Rows.Add(indexWordWebCodeResponseB.ToString(), wordWebCodeResponseB[indexWordWebCodeResponseB]); //Add Data to new Row in Table
                        indexWordWebCodeResponseB++;
                    }
                    stateAddWordInRowTableB = 8;
                    break;
                case 8: //State8 : Input dataGridViewB1 by dataTable1B to show in Table
                    dataGridView1B_Birth(); //dataGridView1B Birth
                    dataGridView1B.DataSource = dataTable1B;
                    dataGridView1B_Die(); //dataGridView1B Die
                    stateAddWordInRowTableB = 9;
                    break;
                case 9: //State9 : Clear Variable
                    stateAddWordInRowTableB = 0;
                    statusAddWordInRowTableB = true;
                    break;
                default:
                    break;
            }
            return statusAddWordInRowTableB;
        }
        //##### End : addWordInRow_TableB

        //##### Begin : show_UrlToRetrieveProcessA
        private bool show_UrlToRetrieveProcessA()
        {
            switch (stateShowUrlToRetrieveProcessA)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveProcessA = false;
                    stateShowUrlToRetrieveProcessA = 1;
                    break;
                case 1: //State1 : Show wordWebCodeResponse[17] to textbox
                    textBoxWebCodeResponseSubStringIndex17A.Text = wordWebCodeResponseA[17];
                    //Console.WriteLine(wordWebCodeResponseA[17]); //Debug
                    tabControl1.SelectedTab = tabPage3; //Open tabPage3 to Debug
                    stateShowUrlToRetrieveProcessA = 2;
                    break;
                case 2: //State2 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                    textBoxWebCodeResponseSubStringIndex17AfterTrimmedA.Text = wordWebCodeResponseA[17].Substring(7, 56);
                    //Console.WriteLine(wordWebCodeResponseA[17].Substring(7, 56)); //Debug
                    //tabControl1.SelectedTab = tabPage2; //Open tabPage3 to normal
                    stateShowUrlToRetrieveProcessA = 3;
                    break;
                case 3: //State3 : Show ParametricDataRetrieveProductionDB URL to textbox
                    textBoxParametricDataRetrieveProductionDB_A.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponseA[17].Substring(7, 56);
                    stateShowUrlToRetrieveProcessA = 4;
                    break;
                case 4: //State4 : Clear Variable
                    statusShowUrlToRetrieveProcessA = true;
                    stateShowUrlToRetrieveProcessA = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveProcessA;
        }
        //##### End : show_UrlToRetrieveProcessA

        //##### Begin : show_UrlToRetrieveProcessB
        private bool show_UrlToRetrieveProcessB()
        {
            switch (stateShowUrlToRetrieveProcessB)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveProcessB = false;
                    stateShowUrlToRetrieveProcessB = 1;
                    break;
                case 1: //State1 : Show wordWebCodeResponse[17] to textbox
                    textBoxWebCodeResponseSubStringIndex17B.Text = wordWebCodeResponseB[17];
                    //Console.WriteLine(wordWebCodeResponseB[17]); //Debug
                    tabControl1.SelectedTab = tabPage3; //Open tabPage3 to Debug
                    stateShowUrlToRetrieveProcessB = 2;
                    break;
                case 2: //State2 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                    textBoxWebCodeResponseSubStringIndex17AfterTrimmedB.Text = wordWebCodeResponseB[17].Substring(7, 56);
                    //Console.WriteLine(wordWebCodeResponseB[17].Substring(7, 56)); //Debug
                    //tabControl1.SelectedTab = tabPage2; //Open tabPage3 to normal
                    stateShowUrlToRetrieveProcessB = 3;
                    break;
                case 3: //State3 : Show ParametricDataRetrieveProductionDB URL to textbox
                    textBoxParametricDataRetrieveProductionDB_B.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponseB[17].Substring(7, 56);
                    stateShowUrlToRetrieveProcessB = 4;
                    break;
                case 4: //State4 : Clear Variable
                    statusShowUrlToRetrieveProcessB = true;
                    stateShowUrlToRetrieveProcessB = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveProcessB;
        }
        //##### End : show_UrlToRetrieveProcessB

        //##### Begin : split_TextA
        private string split_TextA(string textInput)
        {
            if(textInput == "<option>PCM-ALL</option>") // For only Item8 : <option>PCM-ALL</option>
            {
                wordSplitA = textInput.Split('<','>');
                return wordSplitA[2];
            }
            else
            {
                wordSplitA = textInput.Split('\'');
                return wordSplitA[1];
            }
        }
        //##### End : split_TextA

        //##### Begin : split_TextB
        private string split_TextB(string textInput)
        {
            if (textInput == "<option>PCM-ALL</option>") // For only Item8 : <option>PCM-ALL</option>
            {
                wordSplitB = textInput.Split('<', '>');
                return wordSplitB[2];
            }
            else
            {
                wordSplitB = textInput.Split('\'');
                return wordSplitB[1];
            }
        }
        //##### End : split_TextB

        //##### Begin : find_WordIndexA
        private bool find_WordIndexA(string wordToCompare, int indexInitial)
        {
            switch (stateFindWordIndexA)
            {
                case 0: //State0 : Initial Variables
                    statusFindWordIndexA = false;
                    stateFindWordIndexA = 1;
                    break;
                case 1: //State1 : Initial wordRunning
                    indexRunningA = indexInitial;
                    textBoxIndexRunningA.Text = indexRunningA.ToString(); // Check index
                    wordRunningA = wordWebCodeResponseA[indexRunningA];
                    textBoxWordRunningA.Text = wordRunningA; //Check Word Running
                    stateFindWordIndexA = 2;
                    break;
                case 2: //State2 : Compare Words
                    if(wordWebCodeResponseA[indexRunningA] != wordToCompare)
                    {
                        textBoxIndexRunningA.Text = indexRunningA.ToString(); // Check index

                        wordRunningA = wordWebCodeResponseA[indexRunningA];
                        textBoxWordRunningA.Text = wordRunningA; //Check Word Running

                        indexRunningA++;
                    }
                    else
                    {
                        textBoxIndexRunningA.Text = indexRunningA.ToString(); // Check index
                        wordRunningA = wordWebCodeResponseA[indexRunningA];
                        textBoxWordRunningA.Text = wordRunningA; //Check Word Running
                        stateFindWordIndexA = 3;
                    }
                    break;
                case 3: //State3 : Clear Variables
                    statusFindWordIndexA = true;
                    stateFindWordIndexA = 0;
                    break;
                default:
                    break;
            }
            return statusFindWordIndexA;
        }
        //##### End : find_WordIndexA

        //##### Begin : find_WordIndexB
        private bool find_WordIndexB(string wordToCompare, int indexInitial)
        {
            switch (stateFindWordIndexB)
            {
                case 0: //State0 : Initial Variables
                    statusFindWordIndexB = false;
                    stateFindWordIndexB = 1;
                    break;
                case 1: //State1 : Initial wordRunning
                    indexRunningB = indexInitial;
                    textBoxIndexRunningB.Text = indexRunningB.ToString(); // Check index
                    wordRunningB = wordWebCodeResponseB[indexRunningB];
                    textBoxWordRunningB.Text = wordRunningB; //Check Word Running
                    stateFindWordIndexB = 2;
                    break;
                case 2: //State2 : Compare Words
                    if (wordWebCodeResponseB[indexRunningB] != wordToCompare)
                    {
                        textBoxIndexRunningB.Text = indexRunningB.ToString(); // Check index

                        wordRunningB = wordWebCodeResponseB[indexRunningB];
                        textBoxWordRunningB.Text = wordRunningB; //Check Word Running

                        indexRunningB++;
                    }
                    else
                    {
                        textBoxIndexRunningB.Text = indexRunningB.ToString(); // Check index
                        wordRunningB = wordWebCodeResponseB[indexRunningB];
                        textBoxWordRunningB.Text = wordRunningB; //Check Word Running
                        stateFindWordIndexB = 3;
                    }
                    break;
                case 3: //State3 : Clear Variables
                    statusFindWordIndexB = true;
                    stateFindWordIndexB = 0;
                    break;
                default:
                    break;
            }
            return statusFindWordIndexB;
        }
        //##### End : find_WordIndexB

        //##### Begin : show_UrlToRetrieveParamA(Yesterday 07:00 to Today 06:59)
        private bool show_UrlToRetrieveParamA()
        {
            switch (stateShowUrlToRetrieveParamA)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveParamA = false;
                    urlToRetrieveParamA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Added new
                    indexRunningA = 0;
                    stateShowUrlToRetrieveParamA = 1;
                    break;
                case 1: //State1 : Show URL to RetrieveParam
                    if (find_WordIndexA("name='action'", indexRunningA))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item1 : name='action'
                        urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item2 : value='retrieveProcess'><div
                        indexRunningA += 1; // Update value
                        stateShowUrlToRetrieveParamA = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='location'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item3 : name='location'>
                        stateShowUrlToRetrieveParamA = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='0'>PRB</option>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item4 : value='0'>PRB</option>
                        stateShowUrlToRetrieveParamA = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mtype'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item5 : name='mtype'
                        stateShowUrlToRetrieveParamA = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='PCM%'>PCM%</option>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "25" + "&"; //Item6 : value='PCM%'>PCM%</option>
                        stateShowUrlToRetrieveParamA = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='modelid'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item7 : name='modelid'>
                        stateShowUrlToRetrieveParamA = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("<option>PCM-ALL</option>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item8 : <option>PCM-ALL</option>
                        stateShowUrlToRetrieveParamA = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='datekey'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item9 : name='datekey'
                        urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item10 : value='test'
                        indexRunningA += 1; // Update value
                        stateShowUrlToRetrieveParamA = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='enddate0'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item11 : name='enddate0'>
                        //urlToRetrieveParam += split_TextA(wordWebCodeResponseA[indexRunningA + 2]) + "&"; //Item12 : value= current date
                        urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 5]) + "&"; //Item12 : value= Yesterday date
                        indexRunningA += 2; // Update value
                        stateShowUrlToRetrieveParamA = 2;
                    }
                    break;


                case 2: //State2 : Show URL to RetrieveParam(Continue)
                    if(find_WordIndexA("name='endtime0'", (indexRunningA + 1))) 
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item13 : name='endtime0'
                        //urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item14 : value='000000'
                        urlToRetrieveParamA += "070000" + "&"; //Item14 : value = 7 am.
                        //indexRunningA += 1; // Update value
                        stateShowUrlToRetrieveParamA = 2.1;
                    }
                    break;
                case 2.1: //State2.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='enddate1'", (indexRunningA + 1))) 
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item15 : name='enddate1'
                        urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 3]) + "&"; //Item16 : value= current date
                        indexRunningA += 3; // Update value
                        stateShowUrlToRetrieveParamA = 2.2;
                    }
                    break;
                case 2.2: //State2.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='endtime1'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item17 : name='endtime1'
                        //urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item18 : value='235959'
                        urlToRetrieveParamA += "065959" + "&"; //Item18 : value= 6.59 am.
                        //indexRunningA += 1; // Update value
                        stateShowUrlToRetrieveParamA = 2.3;
                    }
                    break;
                case 2.3: //State2.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='scanmode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item19 : name='scanmode'
                        stateShowUrlToRetrieveParamA = 2.4;
                    }
                    break;
                case 2.4: //State2.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='all'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item20 : value='all'
                        stateShowUrlToRetrieveParamA = 2.5;
                    }
                    break;
                case 2.5: //State2.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='scanmodesub'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item21 : name='scanmodesub'
                        urlToRetrieveParamA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item22 : value='found'
                        indexRunningA += 1; // Update value
                        stateShowUrlToRetrieveParamA = 2.6;
                    }
                    break;
                case 2.6: //State2.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='process'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item23 : name='process'>
                        stateShowUrlToRetrieveParamA = 2.7;
                    }
                    break;
                case 2.7: //State2.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='1800'>1800:", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item24 : value='1800'>1800:
                        stateShowUrlToRetrieveParamA = 2.8;
                    }
                    break;
                case 2.8: //State2.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='snlist'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item25 : name='snlist'
                        stateShowUrlToRetrieveParamA = 2.9;
                    }
                    break;
                case 2.9: //State2.9 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item26 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.11;
                    }
                    break;
                case 2.11: //State2.11 : Show URL to RetrieveParam(Continue) // Variable Double 2.1 will equal 2.10
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item27 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.12;
                    }
                    break;
                case 2.12: //State2.12 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item28 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.13;
                    }
                    break;
                case 2.13: //State2.13 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item29 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.14;
                    }
                    break;
                case 2.14: //State2.14 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item30 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.15;
                    }
                    break;
                case 2.15: //State2.15 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item31 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.16;
                    }
                    break;
                case 2.16: //State2.16 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item32 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.17;
                    }
                    break;
                case 2.17: //State2.17 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item33 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.18;
                    }
                    break;
                case 2.18: //State2.18 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item34 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.19;
                    }
                    break;
                case 2.19: //State2.19 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item35 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.21;
                    }
                    break;
                case 2.21: //State2.21 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item36 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.22;
                    }
                    break;
                case 2.22: //State2.22 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item37 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.23;
                    }
                    break;
                case 2.23: //State2.23 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item38 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.24;
                    }
                    break;
                case 2.24: //State2.24 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item39 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.25;
                    }
                    break;
                case 2.25: //State2.25 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item40 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.26;
                    }
                    break;
                case 2.26: //State2.26 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='pfcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item41 : name='pfcode'
                        stateShowUrlToRetrieveParamA = 2.27;
                    }
                    break;
                case 2.27: //State2.27 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item42 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.28;
                    }
                    break;
                case 2.28: //State2.28 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item43 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.29;
                    }
                    break;
                case 2.29: //State2.29 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item44 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.31;
                    }
                    break;
                case 2.31: //State2.31 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item45 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.32;
                    }
                    break;
                case 2.32: //State2.32 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item46 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.33;
                    }
                    break;
                case 2.33: //State2.33 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item47 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.34;
                    }
                    break;
                case 2.34: //State2.34 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item48 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.35;
                    }
                    break;
                case 2.35: //State2.35 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item49 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.36;
                    }
                    break;
                case 2.36: //State2.36 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item50 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.37;
                    }
                    break;
                case 2.37: //State2.37 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item51 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.38;
                    }
                    break;
                case 2.38: //State2.38 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item52 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.39;
                    }
                    break;
                case 2.39: //State2.39 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item53 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.41;
                    }
                    break;
                case 2.41: //State2.41 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item54 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.42;
                    }
                    break;
                case 2.42: //State2.42 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item55 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.43;
                    }
                    break;
                case 2.43: //State2.43 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item56 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.44;
                    }
                    break;
                case 2.44: //State2.44 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hddtrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item57 : name='hddtrial'
                        stateShowUrlToRetrieveParamA = 2.45;
                    }
                    break;
                case 2.45: //State2.45 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item58 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.46;
                    }
                    break;
                case 2.46: //State2.46 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item59 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.47;
                    }
                    break;
                case 2.47: //State2.47 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item60 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.48;
                    }
                    break;
                case 2.48: //State2.48 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item61 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.49;
                    }
                    break;
                case 2.49: //State2.49 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item62 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.51;
                    }
                    break;
                case 2.51: //State2.51 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item63 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.52;
                    }
                    break;
                case 2.52: //State2.52 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item64 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.53;
                    }
                    break;
                case 2.53: //State2.53 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item65 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.54;
                    }
                    break;
                case 2.54: //State2.54 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item66 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.55;
                    }
                    break;
                case 2.55: //State2.55 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item67 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.56;
                    }
                    break;
                case 2.56: //State2.56 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item68 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.57;
                    }
                    break;
                case 2.57: //State2.57 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item69 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.58;
                    }
                    break;
                case 2.58: //State2.58 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item70 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.59;
                    }
                    break;
                case 2.59: //State2.59 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item71 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.61;
                    }
                    break;
                case 2.61: //State2.61 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item72 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.62;
                    }
                    break;
                case 2.62: //State2.62 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='hsatrial'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item73 : name='hsatrial'
                        stateShowUrlToRetrieveParamA = 2.63;
                    }
                    break;
                case 2.63: //State2.63 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='locid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item74 : name='locid'
                        stateShowUrlToRetrieveParamA = 2.64;
                    }
                    break;
                case 2.64: //State2.64 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='locid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item75 : name='locid'
                        stateShowUrlToRetrieveParamA = 2.65;
                    }
                    break;
                case 2.65: //State2.65 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='locid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item76 : name='locid'
                        stateShowUrlToRetrieveParamA = 2.66;
                    }
                    break;
                case 2.66: //State2.66 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='locid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item77 : name='locid'
                        stateShowUrlToRetrieveParamA = 2.67;
                    }
                    break;
                case 2.67: //State2.67 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item78 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.68;
                    }
                    break;
                case 2.68: //State2.68 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item79 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.69;
                    }
                    break;
                case 2.69: //State2.69 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item80 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.71;
                    }
                    break;
                case 2.71: //State2.71 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item81 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.72;
                    }
                    break;
                case 2.72: //State2.72 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item82 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.73;
                    }
                    break;
                case 2.73: //State2.73 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='mfgid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item83 : name='mfgid'
                        stateShowUrlToRetrieveParamA = 2.74;
                    }
                    break;
                case 2.74: //State2.74 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item84 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.75;
                    }
                    break;
                case 2.75: //State2.75 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item85 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.76;
                    }
                    break;
                case 2.76: //State2.76 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item86 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.77;
                    }
                    break;
                case 2.77: //State2.77 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item87 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.78;
                    }
                    break;
                case 2.78: //State2.78 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item88 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.79;
                    }
                    break;
                case 2.79: //State2.79 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testerid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item89 : name='testerid'
                        stateShowUrlToRetrieveParamA = 2.81;
                    }
                    break;
                case 2.81: //State2.81 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item90 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.82;
                    }
                    break;
                case 2.82: //State2.82 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item91 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.83;
                    }
                    break;
                case 2.83: //State2.83 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item92 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.84;
                    }
                    break;
                case 2.84: //State2.84 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item93 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.85;
                    }
                    break;
                case 2.85: //State2.85 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item94 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.86;
                    }
                    break;
                case 2.86: //State2.86 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cellid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item95 : name='cellid'
                        stateShowUrlToRetrieveParamA = 2.87;
                    }
                    break;
                case 2.87: //State2.87 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testertype'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item96 : name='testertype'
                        stateShowUrlToRetrieveParamA = 2.88;
                    }
                    break;
                case 2.88: //State2.88 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testertype'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item97 : name='testertype'
                        stateShowUrlToRetrieveParamA = 2.89;
                    }
                    break;
                case 2.89: //State2.89 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testertype'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item98 : name='testertype'
                        stateShowUrlToRetrieveParamA = 2.91;
                    }
                    break;
                case 2.91: //State2.91 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testertype'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item99 : name='testertype'
                        stateShowUrlToRetrieveParamA = 2.92;
                    }
                    break;
                case 2.92: //State2.92 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item100 : name='testcode'
                        stateShowUrlToRetrieveParamA = 2.93;
                    }
                    break;
                case 2.93: //State2.93 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item101 : name='testcode'
                        stateShowUrlToRetrieveParamA = 2.94;
                    }
                    break;
                case 2.94: //State2.94 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item102 : name='testcode'
                        stateShowUrlToRetrieveParamA = 2.95;
                    }
                    break;
                case 2.95: //State2.95 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='testcode'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item103 : name='testcode'
                        stateShowUrlToRetrieveParamA = 2.96;
                    }
                    break;
                case 2.96: //State2.96 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_spdl'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item104 : name='partid_spdl'
                        stateShowUrlToRetrieveParamA = 2.97;
                    }
                    break;
                case 2.97: //State2.97 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_disk'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item105 : name='partid_disk'
                        stateShowUrlToRetrieveParamA = 2.98;
                    }
                    break;
                case 2.98: //State2.98 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_hsa'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item106 : name='partid_hsa'
                        stateShowUrlToRetrieveParamA = 2.99;
                    }
                    break;
                case 2.99: //State2.99 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_card'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item107 : name='partid_card'
                        stateShowUrlToRetrieveParamA = 2.101;
                    }
                    break;
                case 2.101: //State2.101 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_hgau'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item108 : name='partid_hgau'
                        stateShowUrlToRetrieveParamA = 2.102;
                    }
                    break;
                case 2.102: //State2.102 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_hgad'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item109 : name='partid_hgad'
                        stateShowUrlToRetrieveParamA = 2.103;
                    }
                    break;
                case 2.103: //State2.103 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_sldu'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item110 : name='partid_sldu'
                        stateShowUrlToRetrieveParamA = 2.104;
                    }
                    break;
                case 2.104: //State2.104 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='partid_sldd'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item111 : name='partid_sldd'
                        stateShowUrlToRetrieveParamA = 2.105;
                    }
                    break;
                case 2.105: //State2.105 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='lineid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item112 : name='lineid'
                        stateShowUrlToRetrieveParamA = 2.106;
                    }
                    break;
                case 2.106: //State2.106 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='lineid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item113 : name='lineid'
                        stateShowUrlToRetrieveParamA = 2.107;
                    }
                    break;
                case 2.107: //State2.107 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='lineid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item114 : name='lineid'
                        stateShowUrlToRetrieveParamA = 2.108;
                    }
                    break;
                case 2.108: //State2.108 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='teamid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item115 : name='teamid'
                        stateShowUrlToRetrieveParamA = 2.109;
                    }
                    break;
                case 2.109: //State2.109 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='teamid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item116 : name='teamid'
                        stateShowUrlToRetrieveParamA = 2.111;
                    }
                    break;
                case 2.111: //State2.111 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='teamid'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item117 : name='teamid'
                        stateShowUrlToRetrieveParamA = 2.112;
                    }
                    break;
                case 2.112: //State2.112 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='cycle'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item118 : name='cycle'
                        stateShowUrlToRetrieveParamA = 2.113;
                    }
                    break;
                case 2.113: //State2.113 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='disposition'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item119 : name='disposition'
                        stateShowUrlToRetrieveParamA = 2.114;
                    }
                    break;
                case 2.114: //State2.114 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='disposition'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item120 : name='disposition'
                        stateShowUrlToRetrieveParamA = 2.115;
                    }
                    break;
                case 2.115: //State2.115 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='disposition'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item121 : name='disposition'
                        stateShowUrlToRetrieveParamA = 2.116;
                    }
                    break;
                case 2.116: //State2.116 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='disposition'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item122 : name='disposition'
                        stateShowUrlToRetrieveParamA = 2.117;
                    }
                    break;
                case 2.117: //State2.117 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key1'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item123 : name='key1'>
                        stateShowUrlToRetrieveParamA = 2.118;
                    }
                    break;
                case 2.118: //State2.118 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='diskpn'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item124 : value='diskpn'
                        stateShowUrlToRetrieveParamA = 2.119;
                    }
                    break;
                case 2.119: //State2.119 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key1val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item125 : name='key1val'
                        stateShowUrlToRetrieveParamA = 2.121;
                    }
                    break;
                case 2.121: //State2.121 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key1val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item126 : name='key1val'
                        stateShowUrlToRetrieveParamA = 2.122;
                    }
                    break;
                case 2.122: //State2.122 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key1val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item127 : name='key1val'
                        stateShowUrlToRetrieveParamA = 2.123;
                    }
                    break;
                case 2.123: //State2.123 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key1val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item128 : name='key1val'
                        stateShowUrlToRetrieveParamA = 2.124;
                    }
                    break;
                case 2.124: //State2.124 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key2'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item129 : name='key2'>
                        stateShowUrlToRetrieveParamA = 2.125;
                    }
                    break;
                case 2.125: //State2.125 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='hsapn'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item130 : value='hsapn'
                        stateShowUrlToRetrieveParamA = 2.126;
                    }
                    break;
                case 2.126: //State2.126 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key2val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item131 : name='key2val'
                        stateShowUrlToRetrieveParamA = 2.127;
                    }
                    break;
                case 2.127: //State2.127 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key2val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item132 : name='key2val'
                        stateShowUrlToRetrieveParamA = 2.128;
                    }
                    break;
                case 2.128: //State2.128 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key2val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item133 : name='key2val'
                        stateShowUrlToRetrieveParamA = 2.129;
                    }
                    break;
                case 2.129: //State2.129 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key2val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item134 : name='key2val'
                        stateShowUrlToRetrieveParamA = 2.131;
                    }
                    break;
                case 2.131: //State2.131 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key3'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item135 : name='key3'>
                        stateShowUrlToRetrieveParamA = 2.132;
                    }
                    break;
                case 2.132: //State2.132 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='hgapn'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item136 : value='hgapn'
                        stateShowUrlToRetrieveParamA = 2.133;
                    }
                    break;
                case 2.133: //State2.133 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key3val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item137 : name='key3val'
                        stateShowUrlToRetrieveParamA = 2.134;
                    }
                    break;
                case 2.134: //State2.134 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key3val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item138 : name='key3val'
                        stateShowUrlToRetrieveParamA = 2.135;
                    }
                    break;
                case 2.135: //State2.135 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key3val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item139 : name='key3val'
                        stateShowUrlToRetrieveParamA = 2.136;
                    }
                    break;
                case 2.136: //State2.136 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key3val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item140 : name='key3val'
                        stateShowUrlToRetrieveParamA = 2.137;
                    }
                    break;
                case 2.137: //State2.137 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key4'>", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item141 : name='key4'>
                        stateShowUrlToRetrieveParamA = 2.138;
                    }
                    break;
                case 2.138: //State2.138 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("value='sliderec'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "&"; //Item142 : value='sliderec'
                        stateShowUrlToRetrieveParamA = 2.139;
                    }
                    break;
                case 2.139: //State2.139 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key4val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item143 : name='key4val'
                        stateShowUrlToRetrieveParamA = 2.141;
                    }
                    break;
                case 2.141: //State2.141 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key4val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item144 : name='key4val'
                        stateShowUrlToRetrieveParamA = 2.142;
                    }
                    break;
                case 2.142: //State2.142 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key4val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "=" + "&"; //Item145 : name='key4val'
                        stateShowUrlToRetrieveParamA = 2.143;
                    }
                    break;
                case 2.143: //State2.143 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexA("name='key4val'", (indexRunningA + 1)))
                    {
                        urlToRetrieveParamA += split_TextA(wordRunningA) + "="; //Item146 : name='key4val'
                        stateShowUrlToRetrieveParamA = 3;
                    }
                    break;


                case 3: //State3 : Show URL to RetrieveParam(Continue)
                    textBoxUrlToRetrieveParamA.Text = urlToRetrieveParamA;
                    stateShowUrlToRetrieveParamA = 10;
                    break;
                case 10: //State10 : Clear Variable
                    statusShowUrlToRetrieveParamA = true;
                    stateShowUrlToRetrieveParamA = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveParamA;
        }
        //##### End : show_UrlToRetrieveParamA(Yesterday 07:00 to Today 06:59)

        //##### Begin : show_UrlToRetrieveParamB(Today 07:00 to Now)
        private bool show_UrlToRetrieveParamB()
        {
            switch (stateShowUrlToRetrieveParamB)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveParamB = false;
                    urlToRetrieveParamB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Added new
                    indexRunningB = 0;
                    stateShowUrlToRetrieveParamB = 1;
                    break;
                case 1: //State1 : Show URL to RetrieveParam
                    if (find_WordIndexB("name='action'", indexRunningB))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item1 : name='action'
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item2 : value='retrieveProcess'><div
                        indexRunningB += 1; // Update value
                        stateShowUrlToRetrieveParamB = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='location'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item3 : name='location'>
                        stateShowUrlToRetrieveParamB = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='0'>PRB</option>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item4 : value='0'>PRB</option>
                        stateShowUrlToRetrieveParamB = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mtype'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item5 : name='mtype'
                        stateShowUrlToRetrieveParamB = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='PCM%'>PCM%</option>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "25" + "&"; //Item6 : value='PCM%'>PCM%</option>
                        stateShowUrlToRetrieveParamB = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='modelid'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item7 : name='modelid'>
                        stateShowUrlToRetrieveParamB = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("<option>PCM-ALL</option>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item8 : <option>PCM-ALL</option>
                        stateShowUrlToRetrieveParamB = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='datekey'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item9 : name='datekey'
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item10 : value='test'
                        indexRunningB += 1; // Update value
                        stateShowUrlToRetrieveParamB = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='enddate0'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item11 : name='enddate0'>
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 2]) + "&"; //Item12 : value= current date
                        //urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 5]) + "&"; //Item12 : value= Yesterday date
                        indexRunningB += 2; // Update value
                        stateShowUrlToRetrieveParamB = 2;
                    }
                    break;


                case 2: //State2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='endtime0'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item13 : name='endtime0'
                        //urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item14 : value='000000'
                        urlToRetrieveParamB += "070000" + "&"; //Item14 : value = 7 am.
                        //indexRunningB += 1; // Update value
                        stateShowUrlToRetrieveParamB = 2.1;
                    }
                    break;
                case 2.1: //State2.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='enddate1'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item15 : name='enddate1'
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 3]) + "&"; //Item16 : value= current date
                        indexRunningB += 3; // Update value
                        stateShowUrlToRetrieveParamB = 2.2;
                    }
                    break;
                case 2.2: //State2.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='endtime1'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item17 : name='endtime1'
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item18 : value='235959'
                        //urlToRetrieveParamB += "065959" + "&"; //Item18 : value= 6.59 am.
                        indexRunningB += 1; // Update value
                        stateShowUrlToRetrieveParamB = 2.3;
                    }
                    break;
                case 2.3: //State2.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='scanmode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item19 : name='scanmode'
                        stateShowUrlToRetrieveParamB = 2.4;
                    }
                    break;
                case 2.4: //State2.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='all'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item20 : value='all'
                        stateShowUrlToRetrieveParamB = 2.5;
                    }
                    break;
                case 2.5: //State2.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='scanmodesub'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item21 : name='scanmodesub'
                        urlToRetrieveParamB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item22 : value='found'
                        indexRunningB += 1; // Update value
                        stateShowUrlToRetrieveParamB = 2.6;
                    }
                    break;
                case 2.6: //State2.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='process'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item23 : name='process'>
                        stateShowUrlToRetrieveParamB = 2.7;
                    }
                    break;
                case 2.7: //State2.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='1800'>1800:", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item24 : value='1800'>1800:
                        stateShowUrlToRetrieveParamB = 2.8;
                    }
                    break;
                case 2.8: //State2.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='snlist'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item25 : name='snlist'
                        stateShowUrlToRetrieveParamB = 2.9;
                    }
                    break;
                case 2.9: //State2.9 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item26 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.11;
                    }
                    break;
                case 2.11: //State2.11 : Show URL to RetrieveParam(Continue) // Variable Double 2.1 will equal 2.10
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item27 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.12;
                    }
                    break;
                case 2.12: //State2.12 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item28 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.13;
                    }
                    break;
                case 2.13: //State2.13 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item29 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.14;
                    }
                    break;
                case 2.14: //State2.14 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item30 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.15;
                    }
                    break;
                case 2.15: //State2.15 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item31 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.16;
                    }
                    break;
                case 2.16: //State2.16 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item32 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.17;
                    }
                    break;
                case 2.17: //State2.17 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item33 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.18;
                    }
                    break;
                case 2.18: //State2.18 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item34 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.19;
                    }
                    break;
                case 2.19: //State2.19 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item35 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.21;
                    }
                    break;
                case 2.21: //State2.21 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item36 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.22;
                    }
                    break;
                case 2.22: //State2.22 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item37 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.23;
                    }
                    break;
                case 2.23: //State2.23 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item38 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.24;
                    }
                    break;
                case 2.24: //State2.24 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item39 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.25;
                    }
                    break;
                case 2.25: //State2.25 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item40 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.26;
                    }
                    break;
                case 2.26: //State2.26 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='pfcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item41 : name='pfcode'
                        stateShowUrlToRetrieveParamB = 2.27;
                    }
                    break;
                case 2.27: //State2.27 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item42 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.28;
                    }
                    break;
                case 2.28: //State2.28 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item43 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.29;
                    }
                    break;
                case 2.29: //State2.29 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item44 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.31;
                    }
                    break;
                case 2.31: //State2.31 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item45 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.32;
                    }
                    break;
                case 2.32: //State2.32 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item46 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.33;
                    }
                    break;
                case 2.33: //State2.33 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item47 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.34;
                    }
                    break;
                case 2.34: //State2.34 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item48 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.35;
                    }
                    break;
                case 2.35: //State2.35 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item49 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.36;
                    }
                    break;
                case 2.36: //State2.36 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item50 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.37;
                    }
                    break;
                case 2.37: //State2.37 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item51 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.38;
                    }
                    break;
                case 2.38: //State2.38 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item52 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.39;
                    }
                    break;
                case 2.39: //State2.39 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item53 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.41;
                    }
                    break;
                case 2.41: //State2.41 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item54 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.42;
                    }
                    break;
                case 2.42: //State2.42 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item55 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.43;
                    }
                    break;
                case 2.43: //State2.43 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item56 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.44;
                    }
                    break;
                case 2.44: //State2.44 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hddtrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item57 : name='hddtrial'
                        stateShowUrlToRetrieveParamB = 2.45;
                    }
                    break;
                case 2.45: //State2.45 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item58 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.46;
                    }
                    break;
                case 2.46: //State2.46 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item59 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.47;
                    }
                    break;
                case 2.47: //State2.47 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item60 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.48;
                    }
                    break;
                case 2.48: //State2.48 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item61 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.49;
                    }
                    break;
                case 2.49: //State2.49 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item62 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.51;
                    }
                    break;
                case 2.51: //State2.51 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item63 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.52;
                    }
                    break;
                case 2.52: //State2.52 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item64 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.53;
                    }
                    break;
                case 2.53: //State2.53 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item65 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.54;
                    }
                    break;
                case 2.54: //State2.54 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item66 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.55;
                    }
                    break;
                case 2.55: //State2.55 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item67 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.56;
                    }
                    break;
                case 2.56: //State2.56 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item68 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.57;
                    }
                    break;
                case 2.57: //State2.57 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item69 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.58;
                    }
                    break;
                case 2.58: //State2.58 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item70 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.59;
                    }
                    break;
                case 2.59: //State2.59 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item71 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.61;
                    }
                    break;
                case 2.61: //State2.61 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item72 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.62;
                    }
                    break;
                case 2.62: //State2.62 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='hsatrial'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item73 : name='hsatrial'
                        stateShowUrlToRetrieveParamB = 2.63;
                    }
                    break;
                case 2.63: //State2.63 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='locid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item74 : name='locid'
                        stateShowUrlToRetrieveParamB = 2.64;
                    }
                    break;
                case 2.64: //State2.64 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='locid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item75 : name='locid'
                        stateShowUrlToRetrieveParamB = 2.65;
                    }
                    break;
                case 2.65: //State2.65 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='locid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item76 : name='locid'
                        stateShowUrlToRetrieveParamB = 2.66;
                    }
                    break;
                case 2.66: //State2.66 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='locid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item77 : name='locid'
                        stateShowUrlToRetrieveParamB = 2.67;
                    }
                    break;
                case 2.67: //State2.67 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item78 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.68;
                    }
                    break;
                case 2.68: //State2.68 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item79 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.69;
                    }
                    break;
                case 2.69: //State2.69 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item80 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.71;
                    }
                    break;
                case 2.71: //State2.71 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item81 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.72;
                    }
                    break;
                case 2.72: //State2.72 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item82 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.73;
                    }
                    break;
                case 2.73: //State2.73 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='mfgid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item83 : name='mfgid'
                        stateShowUrlToRetrieveParamB = 2.74;
                    }
                    break;
                case 2.74: //State2.74 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item84 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.75;
                    }
                    break;
                case 2.75: //State2.75 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item85 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.76;
                    }
                    break;
                case 2.76: //State2.76 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item86 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.77;
                    }
                    break;
                case 2.77: //State2.77 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item87 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.78;
                    }
                    break;
                case 2.78: //State2.78 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item88 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.79;
                    }
                    break;
                case 2.79: //State2.79 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testerid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item89 : name='testerid'
                        stateShowUrlToRetrieveParamB = 2.81;
                    }
                    break;
                case 2.81: //State2.81 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item90 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.82;
                    }
                    break;
                case 2.82: //State2.82 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item91 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.83;
                    }
                    break;
                case 2.83: //State2.83 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item92 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.84;
                    }
                    break;
                case 2.84: //State2.84 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item93 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.85;
                    }
                    break;
                case 2.85: //State2.85 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item94 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.86;
                    }
                    break;
                case 2.86: //State2.86 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cellid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item95 : name='cellid'
                        stateShowUrlToRetrieveParamB = 2.87;
                    }
                    break;
                case 2.87: //State2.87 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testertype'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item96 : name='testertype'
                        stateShowUrlToRetrieveParamB = 2.88;
                    }
                    break;
                case 2.88: //State2.88 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testertype'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item97 : name='testertype'
                        stateShowUrlToRetrieveParamB = 2.89;
                    }
                    break;
                case 2.89: //State2.89 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testertype'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item98 : name='testertype'
                        stateShowUrlToRetrieveParamB = 2.91;
                    }
                    break;
                case 2.91: //State2.91 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testertype'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item99 : name='testertype'
                        stateShowUrlToRetrieveParamB = 2.92;
                    }
                    break;
                case 2.92: //State2.92 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item100 : name='testcode'
                        stateShowUrlToRetrieveParamB = 2.93;
                    }
                    break;
                case 2.93: //State2.93 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item101 : name='testcode'
                        stateShowUrlToRetrieveParamB = 2.94;
                    }
                    break;
                case 2.94: //State2.94 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item102 : name='testcode'
                        stateShowUrlToRetrieveParamB = 2.95;
                    }
                    break;
                case 2.95: //State2.95 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='testcode'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item103 : name='testcode'
                        stateShowUrlToRetrieveParamB = 2.96;
                    }
                    break;
                case 2.96: //State2.96 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_spdl'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item104 : name='partid_spdl'
                        stateShowUrlToRetrieveParamB = 2.97;
                    }
                    break;
                case 2.97: //State2.97 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_disk'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item105 : name='partid_disk'
                        stateShowUrlToRetrieveParamB = 2.98;
                    }
                    break;
                case 2.98: //State2.98 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_hsa'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item106 : name='partid_hsa'
                        stateShowUrlToRetrieveParamB = 2.99;
                    }
                    break;
                case 2.99: //State2.99 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_card'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item107 : name='partid_card'
                        stateShowUrlToRetrieveParamB = 2.101;
                    }
                    break;
                case 2.101: //State2.101 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_hgau'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item108 : name='partid_hgau'
                        stateShowUrlToRetrieveParamB = 2.102;
                    }
                    break;
                case 2.102: //State2.102 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_hgad'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item109 : name='partid_hgad'
                        stateShowUrlToRetrieveParamB = 2.103;
                    }
                    break;
                case 2.103: //State2.103 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_sldu'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item110 : name='partid_sldu'
                        stateShowUrlToRetrieveParamB = 2.104;
                    }
                    break;
                case 2.104: //State2.104 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='partid_sldd'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item111 : name='partid_sldd'
                        stateShowUrlToRetrieveParamB = 2.105;
                    }
                    break;
                case 2.105: //State2.105 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='lineid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item112 : name='lineid'
                        stateShowUrlToRetrieveParamB = 2.106;
                    }
                    break;
                case 2.106: //State2.106 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='lineid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item113 : name='lineid'
                        stateShowUrlToRetrieveParamB = 2.107;
                    }
                    break;
                case 2.107: //State2.107 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='lineid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item114 : name='lineid'
                        stateShowUrlToRetrieveParamB = 2.108;
                    }
                    break;
                case 2.108: //State2.108 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='teamid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item115 : name='teamid'
                        stateShowUrlToRetrieveParamB = 2.109;
                    }
                    break;
                case 2.109: //State2.109 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='teamid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item116 : name='teamid'
                        stateShowUrlToRetrieveParamB = 2.111;
                    }
                    break;
                case 2.111: //State2.111 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='teamid'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item117 : name='teamid'
                        stateShowUrlToRetrieveParamB = 2.112;
                    }
                    break;
                case 2.112: //State2.112 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='cycle'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item118 : name='cycle'
                        stateShowUrlToRetrieveParamB = 2.113;
                    }
                    break;
                case 2.113: //State2.113 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='disposition'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item119 : name='disposition'
                        stateShowUrlToRetrieveParamB = 2.114;
                    }
                    break;
                case 2.114: //State2.114 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='disposition'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item120 : name='disposition'
                        stateShowUrlToRetrieveParamB = 2.115;
                    }
                    break;
                case 2.115: //State2.115 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='disposition'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item121 : name='disposition'
                        stateShowUrlToRetrieveParamB = 2.116;
                    }
                    break;
                case 2.116: //State2.116 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='disposition'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item122 : name='disposition'
                        stateShowUrlToRetrieveParamB = 2.117;
                    }
                    break;
                case 2.117: //State2.117 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key1'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item123 : name='key1'>
                        stateShowUrlToRetrieveParamB = 2.118;
                    }
                    break;
                case 2.118: //State2.118 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='diskpn'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item124 : value='diskpn'
                        stateShowUrlToRetrieveParamB = 2.119;
                    }
                    break;
                case 2.119: //State2.119 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key1val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item125 : name='key1val'
                        stateShowUrlToRetrieveParamB = 2.121;
                    }
                    break;
                case 2.121: //State2.121 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key1val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item126 : name='key1val'
                        stateShowUrlToRetrieveParamB = 2.122;
                    }
                    break;
                case 2.122: //State2.122 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key1val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item127 : name='key1val'
                        stateShowUrlToRetrieveParamB = 2.123;
                    }
                    break;
                case 2.123: //State2.123 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key1val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item128 : name='key1val'
                        stateShowUrlToRetrieveParamB = 2.124;
                    }
                    break;
                case 2.124: //State2.124 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key2'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item129 : name='key2'>
                        stateShowUrlToRetrieveParamB = 2.125;
                    }
                    break;
                case 2.125: //State2.125 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='hsapn'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item130 : value='hsapn'
                        stateShowUrlToRetrieveParamB = 2.126;
                    }
                    break;
                case 2.126: //State2.126 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key2val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item131 : name='key2val'
                        stateShowUrlToRetrieveParamB = 2.127;
                    }
                    break;
                case 2.127: //State2.127 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key2val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item132 : name='key2val'
                        stateShowUrlToRetrieveParamB = 2.128;
                    }
                    break;
                case 2.128: //State2.128 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key2val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item133 : name='key2val'
                        stateShowUrlToRetrieveParamB = 2.129;
                    }
                    break;
                case 2.129: //State2.129 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key2val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item134 : name='key2val'
                        stateShowUrlToRetrieveParamB = 2.131;
                    }
                    break;
                case 2.131: //State2.131 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key3'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item135 : name='key3'>
                        stateShowUrlToRetrieveParamB = 2.132;
                    }
                    break;
                case 2.132: //State2.132 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='hgapn'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item136 : value='hgapn'
                        stateShowUrlToRetrieveParamB = 2.133;
                    }
                    break;
                case 2.133: //State2.133 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key3val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item137 : name='key3val'
                        stateShowUrlToRetrieveParamB = 2.134;
                    }
                    break;
                case 2.134: //State2.134 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key3val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item138 : name='key3val'
                        stateShowUrlToRetrieveParamB = 2.135;
                    }
                    break;
                case 2.135: //State2.135 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key3val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item139 : name='key3val'
                        stateShowUrlToRetrieveParamB = 2.136;
                    }
                    break;
                case 2.136: //State2.136 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key3val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item140 : name='key3val'
                        stateShowUrlToRetrieveParamB = 2.137;
                    }
                    break;
                case 2.137: //State2.137 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key4'>", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item141 : name='key4'>
                        stateShowUrlToRetrieveParamB = 2.138;
                    }
                    break;
                case 2.138: //State2.138 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("value='sliderec'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "&"; //Item142 : value='sliderec'
                        stateShowUrlToRetrieveParamB = 2.139;
                    }
                    break;
                case 2.139: //State2.139 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key4val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item143 : name='key4val'
                        stateShowUrlToRetrieveParamB = 2.141;
                    }
                    break;
                case 2.141: //State2.141 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key4val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item144 : name='key4val'
                        stateShowUrlToRetrieveParamB = 2.142;
                    }
                    break;
                case 2.142: //State2.142 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key4val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "=" + "&"; //Item145 : name='key4val'
                        stateShowUrlToRetrieveParamB = 2.143;
                    }
                    break;
                case 2.143: //State2.143 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndexB("name='key4val'", (indexRunningB + 1)))
                    {
                        urlToRetrieveParamB += split_TextB(wordRunningB) + "="; //Item146 : name='key4val'
                        stateShowUrlToRetrieveParamB = 3;
                    }
                    break;


                case 3: //State3 : Show URL to RetrieveParam(Continue)
                    textBoxUrlToRetrieveParamB.Text = urlToRetrieveParamB;
                    stateShowUrlToRetrieveParamB = 10;
                    break;
                case 10: //State10 : Clear Variable
                    statusShowUrlToRetrieveParamB = true;
                    stateShowUrlToRetrieveParamB = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveParamB;
        }
        //##### End : show_UrlToRetrieveParamB(Today 07:00 to Now)

        //##### Begin : show_UrlToGetCsvDataA
        private bool show_UrlToGetCsvDataA()
        {
            switch (stateShow_UrlToGetCsvDataA)
            {
                case 0: //Initial Variable
                    statusShow_UrlToGetCsvDataA = false;
                    urlToGetCsvDataA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";
                    indexRunningA = 0;
                    indexParam1800HeadA = 0;
                    indexParam1800UnitA = 0;
                    indexParam1800HeadValueA = 0;
                    indexParam1800UnitValueA = 0;
                    stateShow_UrlToGetCsvDataA = 1;
                    break;
                case 1: //State1 : Show URL to GetCsvData
                    if (find_WordIndexA("name='action'", indexRunningA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item1 : name='action'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item2 : value='retrieveParam'><div
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='id'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item3 : name='id'>
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item4 : value='1596113827884'><input
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='location'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item5 : name='location'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item6 : value='0'><input
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='baseprocess'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item7 : name='baseprocess'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item8 : value='1800'><input
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='mtype'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item9 : name='mtype'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "25" + "&"; //Item10 : value='PCM%'><table     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='device'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item11 : name='device'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item12 : value='web'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='format'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item13 : name='format'
                        stateShow_UrlToGetCsvDataA = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("value='csv'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item14 : value='csv'
                        stateShow_UrlToGetCsvDataA = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='samplerate_pass'><option", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item15 : name='samplerate_pass'><option
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item16 : value='100'>100</option><option     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.9;
                    }
                    break;
                case 1.9: //State1.9 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='samplerate_fail'><option", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item17 : name='samplerate_fail'><option
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item18 : value='100'>100</option><option     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.11;
                    }
                    break;
                case 1.11: //State1.11 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='maxcount_pass'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item19 : name='maxcount_pass'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item20 : value='xxx'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.12;
                    }
                    break;
                case 1.12: //State1.12 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='foundcount_pass'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item21 : name='foundcount_pass'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item22 : value='xxx'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.13;
                    }
                    break;
                case 1.13: //State1.13 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='maxcount_fail'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item23 : name='maxcount_fail'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item24 : value='xxx'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.14;
                    }
                    break;
                case 1.14: //State1.14 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='foundcount_fail'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item25 : name='foundcount_fail'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item26 : value='xxx'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.15;
                    }
                    break;
                case 1.15: //State1.15 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexA("name='process'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item27 : name='process'
                        urlToGetCsvDataA += split_TextA(wordWebCodeResponseA[indexRunningA + 1]) + "&"; //Item28 : value='1800'     
                        indexRunningA += 1; // Update value
                        stateShow_UrlToGetCsvDataA = 1.16;
                    }
                    break;
                case 1.16: //State1.16 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item29 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.17;
                    }
                    break;
                case 1.17: //State1.17 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='1:MR_RES:4:0'>1", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item30 : value='1:MR_RES:4:0'>1
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.18;
                    }
                    break;

                case 1.18: //State1.18 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item31 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.19;
                    }
                    break;
                case 1.19: //State1.19 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='2:READV:4:0'>2", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item32 : value='2:READV:4:0'>2
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.21;
                    }
                    break;
                case 1.21: //State1.21 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item33 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.22;
                    }
                    break;
                case 1.22: //State1.22 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='3:MR_RES2:4:0'>3", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item34 : value='3:MR_RES2:4:0'>3
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.23;
                    }
                    break;
                case 1.23: //State1.23 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item35 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.24;
                    }
                    break;
                case 1.24: //State1.24 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='4:READV2:4:0'>4", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item36 : value='4:READV2:4:0'>4
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.25;
                    }
                    break;
                case 1.25: //State1.25 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item37 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.26;
                    }
                    break;
                case 1.26: //State1.26 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='5:TFC_RES:4:0'>5", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item38 : value='5:TFC_RES:4:0'>5
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.27;
                    }
                    break;
                case 1.27: //State1.27 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item39 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.28;
                    }
                    break;
                case 1.28: //State1.28 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='6:ECS_RES:4:0'>6", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item40 : value='6:ECS_RES:4:0'>6
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.29;
                    }
                    break;
                case 1.29: //State1.29 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item41 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.31;
                    }
                    break;
                case 1.31: //State1.31 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='7:PMR_PLS_RES:4:0'>7", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item42 : value='7:PMR_PLS_RES:4:0'>7
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.32;
                    }
                    break;
                case 1.32: //State1.32 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_head'", indexParam1800HeadA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item43 : name='param_1800_head'
                        indexParam1800HeadA = indexRunningA; // Assign indexParam1800HeadA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.33;
                    }
                    break;
                case 1.33: //State1.33 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='8:WR_RES:4:0'>8", (indexParam1800HeadValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item44 : value='8:WR_RES:4:0'>8
                        indexParam1800HeadValueA = indexRunningA; // Assign indexParam1800HeadValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.34;
                    }
                    break;

                case 1.34: //State1.34 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_unit'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item45 : name='param_1800_unit'
                        indexParam1800UnitA = indexRunningA; // Assign indexParam1800UnitA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.35;
                    }
                    break;
                case 1.35: //State1.35 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='1:VCM_RES:4:0'>1", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item46 : value='1:VCM_RES:4:0'>1
                        indexParam1800UnitValueA = indexRunningA; // Assign indexParam1800UnitValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.36;
                    }
                    break;
                case 1.36: //State1.36 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_unit'", indexParam1800UnitA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item47 : name='param_1800_unit'
                        indexParam1800UnitA = indexRunningA; // Assign indexParam1800UnitA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.37;
                    }
                    break;
                case 1.37: //State1.37 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='2:PIEZO:4:0'>2", (indexParam1800UnitValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item48 : value='2:PIEZO:4:0'>2
                        indexParam1800UnitValueA = indexRunningA; // Assign indexParam1800UnitValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.38;
                    }
                    break;
                case 1.38: //State1.38 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_unit'", indexParam1800UnitA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item49 : name='param_1800_unit'
                        indexParam1800UnitA = indexRunningA; // Assign indexParam1800UnitA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.39;
                    }
                    break;
                case 1.39: //State1.39 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='3:HMA_PLS:4:0'>3", (indexParam1800UnitValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item50 : value='3:HMA_PLS:4:0'>3
                        indexParam1800UnitValueA = indexRunningA; // Assign indexParam1800UnitValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.41;
                    }
                    break;
                case 1.41: //State1.41 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='param_1800_unit'", indexParam1800UnitA))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "="; //Item51 : name='param_1800_unit'
                        indexParam1800UnitA = indexRunningA; // Assign indexParam1800UnitA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.42;
                    }
                    break;
                case 1.42: //State1.42 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("value='4:HMA_MNS:4:0'>4", (indexParam1800UnitValueA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "&"; //Item52 : value='4:HMA_MNS:4:0'>4
                        indexParam1800UnitValueA = indexRunningA; // Assign indexParam1800UnitValueA = indexRunningA
                        stateShow_UrlToGetCsvDataA = 1.43;
                    }
                    break;
                case 1.43: //State1.43 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexA("name='add_prior'", (indexRunningA + 1)))
                    {
                        urlToGetCsvDataA += split_TextA(wordRunningA) + "=" + "on"; //Item53 : name='add_prior'
                        stateShow_UrlToGetCsvDataA = 3;
                    }
                    break;

                case 3: //State3 : Show URL to GetCsvData(Continue)
                    textBoxUrlToGetCsvDataA.Text = urlToGetCsvDataA;
                    stateShow_UrlToGetCsvDataA = 10;
                    break;
                case 10: //Clear Variables
                    statusShow_UrlToGetCsvDataA = true;
                    stateShow_UrlToGetCsvDataA = 0;
                    break;
                default:
                    break;
                    
            }
            return statusShow_UrlToGetCsvDataA;
        }
        //##### End : show_UrlToGetCsvDataA

        //##### Begin : show_UrlToGetCsvDataB
        private bool show_UrlToGetCsvDataB()
        {
            switch (stateShow_UrlToGetCsvDataB)
            {
                case 0: //Initial Variable
                    statusShow_UrlToGetCsvDataB = false;
                    urlToGetCsvDataB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";
                    indexRunningB = 0;
                    indexParam1800HeadB = 0;
                    indexParam1800UnitB = 0;
                    indexParam1800HeadValueB = 0;
                    indexParam1800UnitValueB = 0;
                    stateShow_UrlToGetCsvDataB = 1;
                    break;
                case 1: //State1 : Show URL to GetCsvData
                    if (find_WordIndexB("name='action'", indexRunningB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item1 : name='action'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item2 : value='retrieveParam'><div
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='id'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item3 : name='id'>
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item4 : value='1596113827884'><input
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='location'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item5 : name='location'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item6 : value='0'><input
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='baseprocess'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item7 : name='baseprocess'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item8 : value='1800'><input
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='mtype'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item9 : name='mtype'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "25" + "&"; //Item10 : value='PCM%'><table     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='device'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item11 : name='device'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item12 : value='web'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='format'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item13 : name='format'
                        stateShow_UrlToGetCsvDataB = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("value='csv'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item14 : value='csv'
                        stateShow_UrlToGetCsvDataB = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='samplerate_pass'><option", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item15 : name='samplerate_pass'><option
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item16 : value='100'>100</option><option     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.9;
                    }
                    break;
                case 1.9: //State1.9 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='samplerate_fail'><option", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item17 : name='samplerate_fail'><option
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item18 : value='100'>100</option><option     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.11;
                    }
                    break;
                case 1.11: //State1.11 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='maxcount_pass'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item19 : name='maxcount_pass'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item20 : value='xxx'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.12;
                    }
                    break;
                case 1.12: //State1.12 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='foundcount_pass'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item21 : name='foundcount_pass'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item22 : value='xxx'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.13;
                    }
                    break;
                case 1.13: //State1.13 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='maxcount_fail'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item23 : name='maxcount_fail'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item24 : value='xxx'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.14;
                    }
                    break;
                case 1.14: //State1.14 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='foundcount_fail'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item25 : name='foundcount_fail'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item26 : value='xxx'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.15;
                    }
                    break;
                case 1.15: //State1.15 : Show URL to GetCsvData(Continue)
                    if (find_WordIndexB("name='process'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item27 : name='process'
                        urlToGetCsvDataB += split_TextB(wordWebCodeResponseB[indexRunningB + 1]) + "&"; //Item28 : value='1800'     
                        indexRunningB += 1; // Update value
                        stateShow_UrlToGetCsvDataB = 1.16;
                    }
                    break;
                case 1.16: //State1.16 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item29 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.17;
                    }
                    break;
                case 1.17: //State1.17 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='1:MR_RES:4:0'>1", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item30 : value='1:MR_RES:4:0'>1
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.18;
                    }
                    break;

                case 1.18: //State1.18 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item31 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.19;
                    }
                    break;
                case 1.19: //State1.19 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='2:READV:4:0'>2", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item32 : value='2:READV:4:0'>2
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.21;
                    }
                    break;
                case 1.21: //State1.21 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item33 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.22;
                    }
                    break;
                case 1.22: //State1.22 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='3:MR_RES2:4:0'>3", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item34 : value='3:MR_RES2:4:0'>3
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.23;
                    }
                    break;
                case 1.23: //State1.23 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item35 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.24;
                    }
                    break;
                case 1.24: //State1.24 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='4:READV2:4:0'>4", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item36 : value='4:READV2:4:0'>4
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.25;
                    }
                    break;
                case 1.25: //State1.25 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item37 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.26;
                    }
                    break;
                case 1.26: //State1.26 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='5:TFC_RES:4:0'>5", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item38 : value='5:TFC_RES:4:0'>5
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.27;
                    }
                    break;
                case 1.27: //State1.27 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item39 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.28;
                    }
                    break;
                case 1.28: //State1.28 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='6:ECS_RES:4:0'>6", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item40 : value='6:ECS_RES:4:0'>6
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.29;
                    }
                    break;
                case 1.29: //State1.29 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item41 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.31;
                    }
                    break;
                case 1.31: //State1.31 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='7:PMR_PLS_RES:4:0'>7", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item42 : value='7:PMR_PLS_RES:4:0'>7
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.32;
                    }
                    break;
                case 1.32: //State1.32 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_head'", indexParam1800HeadB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item43 : name='param_1800_head'
                        indexParam1800HeadB = indexRunningB; // Assign indexParam1800HeadB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.33;
                    }
                    break;
                case 1.33: //State1.33 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='8:WR_RES:4:0'>8", (indexParam1800HeadValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item44 : value='8:WR_RES:4:0'>8
                        indexParam1800HeadValueB = indexRunningB; // Assign indexParam1800HeadValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.34;
                    }
                    break;

                case 1.34: //State1.34 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_unit'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item45 : name='param_1800_unit'
                        indexParam1800UnitB = indexRunningB; // Assign indexParam1800UnitB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.35;
                    }
                    break;
                case 1.35: //State1.35 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='1:VCM_RES:4:0'>1", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item46 : value='1:VCM_RES:4:0'>1
                        indexParam1800UnitValueB = indexRunningB; // Assign indexParam1800UnitValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.36;
                    }
                    break;
                case 1.36: //State1.36 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_unit'", indexParam1800UnitB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item47 : name='param_1800_unit'
                        indexParam1800UnitB = indexRunningB; // Assign indexParam1800UnitB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.37;
                    }
                    break;
                case 1.37: //State1.37 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='2:PIEZO:4:0'>2", (indexParam1800UnitValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item48 : value='2:PIEZO:4:0'>2
                        indexParam1800UnitValueB = indexRunningB; // Assign indexParam1800UnitValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.38;
                    }
                    break;
                case 1.38: //State1.38 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_unit'", indexParam1800UnitB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item49 : name='param_1800_unit'
                        indexParam1800UnitB = indexRunningB; // Assign indexParam1800UnitB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.39;
                    }
                    break;
                case 1.39: //State1.39 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='3:HMA_PLS:4:0'>3", (indexParam1800UnitValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item50 : value='3:HMA_PLS:4:0'>3
                        indexParam1800UnitValueB = indexRunningB; // Assign indexParam1800UnitValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.41;
                    }
                    break;
                case 1.41: //State1.41 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='param_1800_unit'", indexParam1800UnitB))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "="; //Item51 : name='param_1800_unit'
                        indexParam1800UnitB = indexRunningB; // Assign indexParam1800UnitB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.42;
                    }
                    break;
                case 1.42: //State1.42 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("value='4:HMA_MNS:4:0'>4", (indexParam1800UnitValueB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "&"; //Item52 : value='4:HMA_MNS:4:0'>4
                        indexParam1800UnitValueB = indexRunningB; // Assign indexParam1800UnitValueB = indexRunningB
                        stateShow_UrlToGetCsvDataB = 1.43;
                    }
                    break;
                case 1.43: //State1.43 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndexB("name='add_prior'", (indexRunningB + 1)))
                    {
                        urlToGetCsvDataB += split_TextB(wordRunningB) + "=" + "on"; //Item53 : name='add_prior'
                        stateShow_UrlToGetCsvDataB = 3;
                    }
                    break;

                case 3: //State3 : Show URL to GetCsvData(Continue)
                    textBoxUrlToGetCsvDataB.Text = urlToGetCsvDataB;
                    stateShow_UrlToGetCsvDataB = 10;
                    break;
                case 10: //Clear Variables
                    statusShow_UrlToGetCsvDataB = true;
                    stateShow_UrlToGetCsvDataB = 0;
                    break;
                default:
                    break;

            }
            return statusShow_UrlToGetCsvDataB;
        }
        //##### End : show_UrlToGetCsvDataB

        //##### Begin : download_CsvDataA
        private void download_CsvDataA()  
        {
            if(switchDownloadCsvDataA) 
            {
                switch(stateDownloadCsvDataA)
                {
                    case 0: //State0 : Initial Variables 
                        statusWebBrowser1DocumentCompleted = false;

                        indexCsvDataRowA = 0; 
                        indexCsvDataColumnA = 0;

                        stateDownloadCsvDataA = 1;
                        //tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor

                        webBrowser1_Birth(); //webBrowser1 Birth
                        break;
                    case 1: //State1 : Initial Entering Web VnusQ by Logoff
                        if(go_UrlA("http://dwhweb.prb.hgst.com/dwh/logoff.jsp"))
                        {
                            stateDownloadCsvDataA = 2;
                        }
                        break;
                    case 2: //State2 : Go URL, Index Page
                        if (go_UrlA("http://dwhweb.prb.hgst.com/dwh/index.jsp"))
                        {
                            stateDownloadCsvDataA = 3;
                        }
                        break;
                    case 3: //State3 : Go URL, Login Page
                        if (go_UrlA("http://dwhweb.prb.hgst.com/dwh/login"))
                        {
                            stateDownloadCsvDataA = 4;
                        }
                        break;
                    case 4: //State4 : Go URL, Entering Loging by Send Login UserName + Password
                        if (go_UrlA("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On"))
                        {
                            stateDownloadCsvDataA = 5;
                        }
                        break;
                    case 5: //State5 : Show WebCode Response String from Server
                        if (addword_InRowTableA())
                        {
                            stateDownloadCsvDataA = 6;
                        }
                        break;
                    case 6: //State6 : Show URL to RetrieveProcess
                        if (show_UrlToRetrieveProcessA())
                        {
                            stateDownloadCsvDataA = 7;
                        }
                        break;
                    case 7: //State7 : Go RetrieveProcess Page
                        if (go_UrlA("http://dwhweb.prb.hgst.com/" + wordWebCodeResponseA[17].Substring(7, 56)))
                        {
                            stateDownloadCsvDataA = 8;
                        }
                        break;
                    case 8: //State8 : Show WebCode Response String from Server
                        if (addword_InRowTableA())
                        {
                            stateDownloadCsvDataA = 9;
                        }
                        break;
                    case 9: //State9 : Show URL to RetrieveParam
                        if (show_UrlToRetrieveParamA())
                        {
                            stateDownloadCsvDataA = 10;
                        }
                        break;
                    case 10: //State10 : Go RetrieveParam Page
                        if (go_UrlA(urlToRetrieveParamA))
                        {
                            stateDownloadCsvDataA = 11;
                        }
                        break;
                    case 11: //State11 : Show WebCode Response String from Server
                        if (addword_InRowTableA())
                        {
                            stateDownloadCsvDataA = 12;
                        }
                        break;
                    case 12: //State12 : Show URL to get csv data
                        if (show_UrlToGetCsvDataA())
                        {
                            stateDownloadCsvDataA = 13;
                        }
                        break;
                    case 13: //State13 : Go csv Page
                        if (go_UrlA(urlToGetCsvDataA))
                        {
                            stateDownloadCsvDataA = 14;
                        }
                        break;
                    case 14: //State14 : Convert CSV Data from web to dataGridView2A

                        //tabControl1.SelectedTab = tabPage1; //Debug

                        textBoxCsvDataA.Text = webBrowser1.Document.Body.InnerText;

                        webBrowser1_Die(); //webBrowser1 Die

                        dataTable2A.Clear(); //Clear datatable of CSV Data
                        dataTable2A.Columns.Clear(); //Clear Columns of datatable CSV Data
                        dataTable2A.Rows.Clear(); //Clear Rows of datatable CSV Data

                        wordCsvDataRowA = textBoxCsvDataA.Text.Split('\n'); //Split Row by new line(\n)

                        indexCsvDataRowA = 0; //Initial indexCsvDataRowA
                        indexCsvDataColumnA = 0; //Initial indexCsvDataColumnA

                        //dataTable2A.Columns.Add("Column" + indexCsvDataColumnA);
                        dataTable2A.Columns.Add("Item");

                        wordCsvDataColumnA = wordCsvDataRowA[0].Split(','); //Split Column of Row0 by comma(,)

                        foreach (var dataColumn in wordCsvDataColumnA) //Add Other 42 Columns of CSV Header
                        {
                            //indexCsvDataColumnA++;
                            //dataTable2A.Columns.Add("Column"+ indexCsvDataColumnA);
                            dataTable2A.Columns.Add(dataColumn);

                            textBoxLastIndexOfCsvDataColumnA.Text = indexCsvDataColumnA.ToString();
                            indexCsvDataColumnA++;
                        }

                        foreach (var dataRow in wordCsvDataRowA)
                        {
                            if (indexCsvDataRowA > 0)
                            {
                                wordCsvDataColumnA = dataRow.Split(',');

                                dataTable2A.Rows.Add(indexCsvDataRowA, wordCsvDataColumnA[0], wordCsvDataColumnA[1], wordCsvDataColumnA[2], wordCsvDataColumnA[3],
                                                                           wordCsvDataColumnA[4], wordCsvDataColumnA[5], wordCsvDataColumnA[6], wordCsvDataColumnA[7],
                                                                           wordCsvDataColumnA[8], wordCsvDataColumnA[9], wordCsvDataColumnA[10], wordCsvDataColumnA[11],
                                                                           wordCsvDataColumnA[12], wordCsvDataColumnA[13], wordCsvDataColumnA[14], wordCsvDataColumnA[15],
                                                                           wordCsvDataColumnA[16], wordCsvDataColumnA[17], wordCsvDataColumnA[18], wordCsvDataColumnA[19],
                                                                           wordCsvDataColumnA[20], wordCsvDataColumnA[21], wordCsvDataColumnA[22], wordCsvDataColumnA[23],
                                                                           wordCsvDataColumnA[24], wordCsvDataColumnA[25], wordCsvDataColumnA[26], wordCsvDataColumnA[27],
                                                                           wordCsvDataColumnA[28], wordCsvDataColumnA[29], wordCsvDataColumnA[30], wordCsvDataColumnA[31],
                                                                           wordCsvDataColumnA[32], wordCsvDataColumnA[33], wordCsvDataColumnA[34], wordCsvDataColumnA[35],
                                                                           wordCsvDataColumnA[36], wordCsvDataColumnA[37], wordCsvDataColumnA[38], wordCsvDataColumnA[39],
                                                                           wordCsvDataColumnA[40], wordCsvDataColumnA[41]);

                                textBoxLastIndexOfCsvDataRowA.Text = indexCsvDataRowA.ToString();
                            }

                            indexCsvDataRowA++;
                        }

                        dataGridView2A_Birth();
                        dataGridView2A.DataSource = dataTable2A;
                        dataGridView2A_Die();

                        //tabControl1.SelectedTab = tabPage2; //Debug

                        stateDownloadCsvDataA = 100;
                        break;
                    case 100: //State100 : End This Function and Resetting variables
                        //Begin Clear Ram
                        //this.webBrowser1.Navigate(string.Empty);
                        
                        textBoxUrlToGo.Clear();
                        textBoxUrlResponseA.Clear();
                        textBoxWebCodeResponseA.Clear();
                        textBoxCsvDataA.Clear();

                        //End Clear Ram
                        switchDisplayDataA = true; //Start function : display_DataA()
                        switchDownloadCsvDataB = true; //Start function : download_CsvData2() -->Debug
                        switchDownloadCsvDataA = false;
                        stateDownloadCsvDataA = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : download_CsvDataA

        //##### Begin : download_CsvDataB
        private void download_CsvDataB()
        {
            if (switchB)
            {
                if (switchDownloadCsvDataB)
                {
                    switch (stateDownloadCsvDataB)
                    {
                        case 0: //State0 : Initial Variables 
                            statusWebBrowser2DocumentCompleted = false;

                            indexCsvDataRowB = 0;
                            indexCsvDataColumnB = 0;

                            stateDownloadCsvDataB = 1;
                            //tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor

                            webBrowser2_Birth(); //webBrowser2 Birth
                            break;
                        case 1: //State1 : Initial Entering Web VnusQ by Logoff
                            if (go_UrlB("http://dwhweb.prb.hgst.com/dwh/logoff.jsp"))
                            {
                                stateDownloadCsvDataB = 2;
                            }
                            break;
                        case 2: //State2 : Go URL, Index Page
                            if (go_UrlB("http://dwhweb.prb.hgst.com/dwh/index.jsp"))
                            {
                                stateDownloadCsvDataB = 3;
                            }
                            break;
                        case 3: //State3 : Go URL, Login Page
                            if (go_UrlB("http://dwhweb.prb.hgst.com/dwh/login"))
                            {
                                stateDownloadCsvDataB = 4;
                            }
                            break;
                        case 4: //State4 : Go URL, Entering Loging by Send Login UserName + Password
                            if (go_UrlB("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On"))
                            {
                                stateDownloadCsvDataB = 5;
                            }
                            break;
                        case 5: //State5 : Show WebCode Response String from Server
                            if (addword_InRowTableB())
                            {
                                stateDownloadCsvDataB = 6;
                            }
                            break;
                        case 6: //State6 : Show URL to RetrieveProcess
                            if (show_UrlToRetrieveProcessB())
                            {
                                stateDownloadCsvDataB = 7;
                            }
                            break;
                        case 7: //State7 : Go RetrieveProcess Page
                            if (go_UrlB("http://dwhweb.prb.hgst.com/" + wordWebCodeResponseB[17].Substring(7, 56)))
                            {
                                stateDownloadCsvDataB = 8;
                            }
                            break;
                        case 8: //State8 : Show WebCode Response String from Server
                            if (addword_InRowTableB())
                            {
                                stateDownloadCsvDataB = 9;
                            }
                            break;
                        case 9: //State9 : Show URL to RetrieveParam
                            if (show_UrlToRetrieveParamB())
                            {
                                stateDownloadCsvDataB = 10;
                            }
                            break;
                        case 10: //State10 : Go RetrieveParam Page
                            if (go_UrlB(urlToRetrieveParamB))
                            {
                                stateDownloadCsvDataB = 11;
                            }
                            //webBrowser2.ScriptErrorsSuppressed = true; //Debug
                            break;
                        case 11: //State11 : Show WebCode Response String from Server
                            if (addword_InRowTableB())
                            {
                                stateDownloadCsvDataB = 12;
                            }
                            break;
                        case 12: //State12 : Show URL to get csv data
                            if (show_UrlToGetCsvDataB())
                            {
                                stateDownloadCsvDataB = 13;
                            }
                            break;
                        case 13: //State13 : Go csv Page
                            if (go_UrlB(urlToGetCsvDataB))
                            {
                                stateDownloadCsvDataB = 14;
                            }
                            break;
                        case 14: //State14 : Convert CSV Data from web to dataGridView2B

                            //tabControl1.SelectedTab = tabPage1; //Debug

                            textBoxCsvDataB.Text = webBrowser2.Document.Body.InnerText;

                            webBrowser2_Die(); //webBrowser2 Die

                            dataTable2B.Clear(); //Clear datatable of CSV Data
                            dataTable2B.Columns.Clear(); //Clear Columns of datatable CSV Data
                            dataTable2B.Rows.Clear(); //Clear Rows of datatable CSV Data

                            wordCsvDataRowB = textBoxCsvDataB.Text.Split('\n'); //Split Row by new line(\n)

                            indexCsvDataRowB = 0; //Initial indexCsvDataRowB
                            indexCsvDataColumnB = 0; //Initial indexCsvDataColumnB

                            //dataTable2B.Columns.Add("Column" + indexCsvDataColumnB);
                            dataTable2B.Columns.Add("Item");

                            wordCsvDataColumnB = wordCsvDataRowB[0].Split(','); //Split Column of Row0 by comma(,)

                            foreach (var dataColumn in wordCsvDataColumnB) //Add Other 42 Columns of CSV Header
                            {
                                //indexCsvDataColumnB++;
                                //dataTable2B.Columns.Add("Column" + indexCsvDataColumnB);
                                dataTable2B.Columns.Add(dataColumn);

                                textBoxLastIndexOfCsvDataColumnB.Text = indexCsvDataColumnB.ToString();
                                indexCsvDataColumnB++;
                            }

                            foreach (var dataRow in wordCsvDataRowB)
                            {
                                if (indexCsvDataRowB > 0)
                                {
                                    wordCsvDataColumnB = dataRow.Split(',');

                                    dataTable2B.Rows.Add(indexCsvDataRowB, wordCsvDataColumnB[0], wordCsvDataColumnB[1], wordCsvDataColumnB[2], wordCsvDataColumnB[3],
                                                                               wordCsvDataColumnB[4], wordCsvDataColumnB[5], wordCsvDataColumnB[6], wordCsvDataColumnB[7],
                                                                               wordCsvDataColumnB[8], wordCsvDataColumnB[9], wordCsvDataColumnB[10], wordCsvDataColumnB[11],
                                                                               wordCsvDataColumnB[12], wordCsvDataColumnB[13], wordCsvDataColumnB[14], wordCsvDataColumnB[15],
                                                                               wordCsvDataColumnB[16], wordCsvDataColumnB[17], wordCsvDataColumnB[18], wordCsvDataColumnB[19],
                                                                               wordCsvDataColumnB[20], wordCsvDataColumnB[21], wordCsvDataColumnB[22], wordCsvDataColumnB[23],
                                                                               wordCsvDataColumnB[24], wordCsvDataColumnB[25], wordCsvDataColumnB[26], wordCsvDataColumnB[27],
                                                                               wordCsvDataColumnB[28], wordCsvDataColumnB[29], wordCsvDataColumnB[30], wordCsvDataColumnB[31],
                                                                               wordCsvDataColumnB[32], wordCsvDataColumnB[33], wordCsvDataColumnB[34], wordCsvDataColumnB[35],
                                                                               wordCsvDataColumnB[36], wordCsvDataColumnB[37], wordCsvDataColumnB[38], wordCsvDataColumnB[39],
                                                                               wordCsvDataColumnB[40], wordCsvDataColumnB[41]);

                                    textBoxLastIndexOfCsvDataRowB.Text = indexCsvDataRowB.ToString();
                                }

                                indexCsvDataRowB++;
                            }

                            dataGridView2B_Birth(); 
                            dataGridView2B.DataSource = dataTable2B;
                            dataGridView2B_Die();

                            //tabControl1.SelectedTab = tabPage2; //Debug

                            stateDownloadCsvDataB = 100;
                            break;
                        case 100: //State100 : End This Function and Resetting variables
                            //Begin Clear Ram
                            this.webBrowser2.Navigate(string.Empty);

                            //textBoxUrlToGo.Clear();
                            textBoxUrlResponseB.Clear();
                            textBoxWebCodeResponseB.Clear();
                            textBoxCsvDataB.Clear();

                            //End Clear Ram
                            switchDisplayDataB = true;
                            switchDownloadCsvDataB = false;
                            stateDownloadCsvDataB = 0;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        //##### End : download_CsvDataB


        //##### Begin : display_DataA
        private void display_DataA()
        {
            if (switchDisplayDataA)
            {
                switch (stateDisplayDataA)
                {
                    case 0: //State0 : Initial Variables
                        readabilityFailTarget_A = 0.50; //Initial to check HGA Read Target of ProcessA
                        etesterFailTarget_A = 5.00; //Initial to check HSA ETEST Fail Target of ProcessA
                        badOCRTarget_A = 0.50; //Initial to check HGA BAD OCR Target of ProcessA
                        lineHeadL_A = 1; //Initial for G2_(L)
                        lineHeadR_A = 2; //Initial for G2_(R)
                        inputLineHeadL_A = 0; //Reset inputLineHeadL_A
                        inputLineHeadR_A = 0; //Reset inputLineHeadR_A
                        readabilityFailLineHeadL_A = 0; //Reset readabilityFailLineHeadL_A
                        readabilityFailLineHeadR_A = 0; //Reset readabilityFailLineHeadR_A
                        etesterFailLineHeadL_A = 0; //Reset etesterFailLineHeadL_A
                        etesterFailLineHeadR_A = 0; //Reset etesterFailLineHeadR_A
                        badOCRLineHeadL_A = 0; //Reset badOCRLineHeadL_A
                        badOCRLineHeadR_A = 0; //Reset badOCRLineHeadR_A
                        softwareVersionL_A = ""; //Reset Line Software Version
                        softwareVersionR_A = ""; //Reset Line Software Version
                        stateDisplayDataA = 1;
                        break;
                    case 1: //State1 : Open Display Area
                        tabControl1.SelectedTab = tabPage5; //Open tabPage5
                        stateDisplayDataA = 2;
                        break;
                    case 2: //State2 : Clear Table
                        dataTable3A.Clear(); //Clear data in Table
                        dataTable3A.Columns.Clear(); //Clear Columnn
                        dataTable3A.Rows.Clear(); //Clear Row
                        stateDisplayDataA = 3;
                        break;
                    case 3: //State3 : Add Column
                        dataTable3A.Columns.Add("TARGET"); //Add Column0
                        dataTable3A.Columns.Add("G2_(L)"); //Add Column1
                        dataTable3A.Columns.Add("G2_(R)"); //Add Column2
                        dataTable3A.Columns.Add("G3_(L)"); //Add Column3
                        dataTable3A.Columns.Add("G3_(R)"); //Add Column4
                        dataTable3A.Columns.Add("G4_(L)"); //Add Column5
                        dataTable3A.Columns.Add("G4_(R)"); //Add Column6
                        dataTable3A.Columns.Add("G5_(L)"); //Add Column7
                        dataTable3A.Columns.Add("G5_(R)"); //Add Column8
                        dataTable3A.Columns.Add("G6_(L)"); //Add Column9
                        dataTable3A.Columns.Add("G6_(R)"); //Add Column10
                        dataTable3A.Columns.Add("G7_(L)"); //Add Column11
                        dataTable3A.Columns.Add("G7_(R)"); //Add Column12
                        dataTable3A.Columns.Add("G8_(L)"); //Add Column13
                        dataTable3A.Columns.Add("G8_(R)"); //Add Column14
                        dataTable3A.Columns.Add("G9_(L)"); //Add Column15
                        dataTable3A.Columns.Add("G9_(R)"); //Add Column16
                        dataTable3A.Columns.Add("GA_(L)"); //Add Column17
                        dataTable3A.Columns.Add("GA_(R)"); //Add Column18
                        dataTable3A.Columns.Add("GB_(L)"); //Add Column19
                        dataTable3A.Columns.Add("GB_(R)"); //Add Column20
                        dataTable3A.Columns.Add("GC_(L)"); //Add Column21
                        dataTable3A.Columns.Add("GC_(R)"); //Add Column22
                        dataTable3A.Columns.Add("GD_(L)"); //Add Column23
                        dataTable3A.Columns.Add("GD_(R)"); //Add Column24
                        dataTable3A.Columns.Add("GE_(L)"); //Add Column25
                        dataTable3A.Columns.Add("GE_(R)"); //Add Column26
                        dataTable3A.Columns.Add("GF_(L)"); //Add Column27
                        dataTable3A.Columns.Add("GF_(R)"); //Add Column28
                        dataTable3A.Columns.Add("GG_(L)"); //Add Column29
                        dataTable3A.Columns.Add("GG_(R)"); //Add Column30
                        dataTable3A.Columns.Add("GH_(L)"); //Add Column31
                        dataTable3A.Columns.Add("GH_(R)"); //Add Column32
                        dataTable3A.Columns.Add("GI_(L)"); //Add Column33
                        dataTable3A.Columns.Add("GI_(R)"); //Add Column34
                        dataTable3A.Columns.Add("GJ_(L)"); //Add Column35
                        dataTable3A.Columns.Add("GJ_(R)"); //Add Column36
                        dataTable3A.Columns.Add("GK_(L)"); //Add Column37
                        dataTable3A.Columns.Add("GK_(R)"); //Add Column38
                        dataTable3A.Columns.Add("GL_(L)"); //Add Column39
                        dataTable3A.Columns.Add("GL_(R)"); //Add Column40
                        dataTable3A.Columns.Add("GM_(L)"); //Add Column41
                        dataTable3A.Columns.Add("GM_(R)"); //Add Column42
                        dataTable3A.Columns.Add("GN_(L)"); //Add Column43
                        dataTable3A.Columns.Add("GN_(R)"); //Add Column44
                        dataTable3A.Columns.Add("GO_(L)"); //Add Column45
                        dataTable3A.Columns.Add("GO_(R)"); //Add Column46
                        dataTable3A.Columns.Add("GP_(L)"); //Add Column47
                        dataTable3A.Columns.Add("GP_(R)"); //Add Column48
                        stateDisplayDataA = 4;
                        break;
                    case 4: //State4 : Add Row for Items
                        dataTable3A.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row0 : INPUT
                        dataTable3A.Rows.Add((readabilityFailTarget_A.ToString("#,##0.00") +"%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row1 : READABILITY FAIL
                        dataTable3A.Rows.Add((etesterFailTarget_A.ToString("#,##0.00") + "%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row2 : ETESTER FAIL
                        dataTable3A.Rows.Add((badOCRTarget_A.ToString("#,##0.00") + "%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row3 : BAD OCR
                        dataTable3A.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row4 : SW.VERSION

                        dataGridView3A.DataSource = dataTable3A; //Dump data in Table
                        dataGridView3A.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Make Text Center in Header Cell
                        dataGridView3A.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Make Text Center in Cell
                        stateDisplayDataA = 5;
                        break;
                    case 5: //State5 : Check HSA Input, HGA ReadabilityFail,

                        foreach (string line in genesis) //Check Line G2 to GN
                        {
                            for (int i = 0; i < (indexCsvDataRowA - 1); i++) //Check again maybe noneed to -1
                            {
                                if (dataTable2A.Rows[i][21].ToString() == line) //Check in Column21(LI)
                                {
                                    if (dataTable2A.Rows[i][11].ToString().EndsWith("1"))
                                    {
                                        inputLineHeadL_A++; //Increase Input Head L of Process A
                                        if (dataTable2A.Rows[i][30].ToString() == "..........")
                                        {
                                            readabilityFailLineHeadL_A++; //Increase Readability Fail Head L of Process A
                                        }
                                        if(dataTable2A.Rows[i][7].ToString() != "0000")
                                        {
                                            etesterFailLineHeadL_A++; //Increase ETEST FAIL Head L of Process A
                                        }
                                        if(dataTable2A.Rows[i][30].ToString() == "..ROI.NG..")
                                        {
                                            badOCRLineHeadL_A++; //Increase BAD OCR Head L of Process A
                                        }
                                        softwareVersionL_A = dataTable2A.Rows[i][13].ToString(); //Store SW.Version Head L use to Run Machine
                                    }
                                    else if (dataTable2A.Rows[i][11].ToString().EndsWith("2"))
                                    {
                                        inputLineHeadR_A++; //Increase Input Head R of Process A
                                        if (dataTable2A.Rows[i][30].ToString() == "..........")
                                        {
                                            readabilityFailLineHeadR_A++; //Increase Readability Fail Head R of Process A
                                        }
                                        if (dataTable2A.Rows[i][7].ToString() != "0000")
                                        {
                                            etesterFailLineHeadR_A++; //Increase ETEST FAIL Head R of Process A
                                        }
                                        if (dataTable2A.Rows[i][30].ToString() == "..ROI.NG..")
                                        {
                                            badOCRLineHeadR_A++; //Increase BAD OCR Head R of Process A
                                        }
                                        softwareVersionR_A = dataTable2A.Rows[i][13].ToString(); //Store SW.Version Head R use to Run Machine
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            //Console.WriteLine(indexCsvDataRowA - 1); //Debug

                            //*********** HSA Input *******************

                            dataTable3A.Rows[0][lineHeadL_A] = (inputLineHeadL_A / 18).ToString(); //Write HSA inputLineHeadL_A Value (HGA / 18 = HSA)
                            dataTable3A.Rows[0][lineHeadR_A] = (inputLineHeadR_A / 18).ToString(); //Write HSA inputLineHeadR_A Value (HGA / 18 = HSA)
                            //*********** HGA Readability Fail ****************
                            if ((readabilityFailLineHeadL_A == 0) && (readabilityFailLineHeadR_A == 0)) //00
                            {
                                dataTable3A.Rows[1][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadL_A].ToString().Replace("%","")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[1][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadR_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_A == 0) && (readabilityFailLineHeadR_A != 0)) //01
                            {
                                dataTable3A.Rows[1][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadL_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[1][lineHeadR_A] = (((readabilityFailLineHeadR_A / inputLineHeadR_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadR_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_A != 0) && (readabilityFailLineHeadR_A == 0)) //10
                            {
                                dataTable3A.Rows[1][lineHeadL_A] = (((readabilityFailLineHeadL_A / inputLineHeadL_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadL_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[1][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadR_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_A != 0) && (readabilityFailLineHeadR_A != 0)) //11
                            {
                                dataTable3A.Rows[1][lineHeadL_A] = (((readabilityFailLineHeadL_A / inputLineHeadL_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadL_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[1][lineHeadR_A] = (((readabilityFailLineHeadR_A / inputLineHeadR_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[1][lineHeadR_A].ToString().Replace("%", "")) >= readabilityFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //*********** HSA ETEST Fail ****************
                            if ((etesterFailLineHeadL_A == 0) && (etesterFailLineHeadR_A == 0)) //00
                            {
                                dataTable3A.Rows[2][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadL_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[2][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadR_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_A == 0) && (etesterFailLineHeadR_A != 0)) //01
                            {
                                dataTable3A.Rows[2][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadL_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[2][lineHeadR_A] = ((((etesterFailLineHeadR_A / 18) / (inputLineHeadR_A / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadR_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_A != 0) && (etesterFailLineHeadR_A == 0)) //10
                            {
                                dataTable3A.Rows[2][lineHeadL_A] = ((((etesterFailLineHeadL_A / 18) / (inputLineHeadL_A / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadL_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[2][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadR_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_A != 0) && (etesterFailLineHeadR_A != 0)) //11
                            {
                                dataTable3A.Rows[2][lineHeadL_A] = ((((etesterFailLineHeadL_A / 18) / (inputLineHeadL_A / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadL_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadL_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[2][lineHeadR_A] = ((((etesterFailLineHeadR_A / 18) / (inputLineHeadR_A / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[2][lineHeadR_A].ToString().Replace("%", "")) >= etesterFailTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //********** HGA BAD OCR ****************
                            if ((badOCRLineHeadL_A == 0) && (badOCRLineHeadR_A == 0)) //00
                            {
                                dataTable3A.Rows[3][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_A  Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadL_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[3][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadR_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_A == 0) && (badOCRLineHeadR_A != 0)) //01
                            {
                                dataTable3A.Rows[3][lineHeadL_A] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_A  Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadL_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[3][lineHeadR_A] = (((badOCRLineHeadR_A / inputLineHeadR_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadR_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_A != 0) && (badOCRLineHeadR_A == 0)) //10
                            {
                                dataTable3A.Rows[3][lineHeadL_A] = (((badOCRLineHeadL_A / inputLineHeadL_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_A  Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadL_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[3][lineHeadR_A] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadR_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_A != 0) && (badOCRLineHeadR_A != 0)) //11
                            {
                                dataTable3A.Rows[3][lineHeadL_A] = (((badOCRLineHeadL_A / inputLineHeadL_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_A  Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadL_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadL_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3A.Rows[3][lineHeadR_A] = (((badOCRLineHeadR_A / inputLineHeadR_A)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_A Value
                                if (double.Parse(dataTable3A.Rows[3][lineHeadR_A].ToString().Replace("%", "")) >= badOCRTarget_A) //Check >= Target?
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3A[lineHeadR_A, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //********** Line Software Version ***************
                            dataTable3A.Rows[4][lineHeadL_A] = softwareVersionL_A; //Write Line Software Version
                            dataTable3A.Rows[4][lineHeadR_A] = softwareVersionR_A; //Write Line Software Version
                            //**********
                            inputLineHeadL_A = 0; //Reset inputLineHeadL_A
                            inputLineHeadR_A = 0; //Reset inputLineHeadR_A
                            readabilityFailLineHeadL_A = 0; //Reset readabilityFailLineHeadL_A
                            readabilityFailLineHeadR_A = 0; //Reset readabilityFailLineHeadR_A
                            etesterFailLineHeadL_A = 0; //Reset etesterFailLineHeadL_A
                            etesterFailLineHeadR_A = 0; //Reset etesterFailLineHeadR_A
                            badOCRLineHeadL_A = 0; //Reset badOCRLineHeadL_A
                            badOCRLineHeadR_A = 0; //Reset badOCRLineHeadR_A
                            softwareVersionL_A = ""; //Reset Line Software Version
                            softwareVersionR_A = ""; //Reset Line Software Version
                            lineHeadL_A += 2; //Increase to Next Head
                            lineHeadR_A += 2; //Increase to Next Head
                        }
                        lineHeadL_A = 1; //Reset lineHeadL_A
                        lineHeadR_A = 2; //Reset lineHeadR_A
                        stateDisplayDataA = 6;
                        break;
                    case 6: //State6 : Dump into dataGridView3A
                            //dataGridView3A.DataSource = dataTable3A;
                        dataGridView3A.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //Auto Adjust Column Width
                        dataGridView3A.Columns[0].DefaultCellStyle.ForeColor = Color.Red; //Change Text in Column0 to Red Color
                        dataGridView3A.Columns[0].Frozen = true; //Freeze Column0
                        stateDisplayDataA = 10;
                        break;
                    case 10:
                        stateDisplayDataA = 0;
                        switchDisplayDataA = false;
                        //Application.Restart(); // Debug
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : display_DataA

        //##### Begin : display_DataB
        private void display_DataB()
        {
            if (switchDisplayDataB)
            {
                switch (stateDisplayDataB)
                {
                    case 0: //State0 : Initial Variables
                        readabilityFailTarget_B = 0.50; //Initial to check HGA Read Target of ProcessB
                        etesterFailTarget_B = 5.00; //Initial to check HSA ETEST Fail Target of ProcessB
                        badOCRTarget_B = 0.50; //Initial to check HGA BAD OCR Target of ProcessB
                        lineHeadL_B = 1; //Initial for G2_(L)
                        lineHeadR_B = 2; //Initial for G2_(R)
                        inputLineHeadL_B = 0; //Reset inputLineHeadL_B
                        inputLineHeadR_B = 0; //Reset inputLineHeadR_B
                        readabilityFailLineHeadL_B = 0; //Reset readabilityFailLineHeadL_B
                        readabilityFailLineHeadR_B = 0; //Reset readabilityFailLineHeadR_B
                        etesterFailLineHeadL_B = 0; //Reset etesterFailLineHeadL_B
                        etesterFailLineHeadR_B = 0; //Reset etesterFailLineHeadR_B
                        badOCRLineHeadL_B = 0; //Reset badOCRLineHeadL_B
                        badOCRLineHeadR_B = 0; //Reset badOCRLineHeadR_B
                        softwareVersionL_B = ""; //Reset Line Software Version
                        softwareVersionR_B = ""; //Reset Line Software Version
                        stateDisplayDataB = 1;
                        break;
                    case 1: //State1 : Open Display Area
                        tabControl1.SelectedTab = tabPage5; //Open tabPage5
                        stateDisplayDataB = 2;
                        break;
                    case 2: //State2 : Clear Table
                        dataTable3B.Clear(); //Clear data in Table
                        dataTable3B.Columns.Clear(); //Clear Columnn
                        dataTable3B.Rows.Clear(); //Clear Row
                        stateDisplayDataB = 3;
                        break;
                    case 3: //State3 : Add Column
                        dataTable3B.Columns.Add("TARGET"); //Add Column0
                        dataTable3B.Columns.Add("G2_(L)"); //Add Column1
                        dataTable3B.Columns.Add("G2_(R)"); //Add Column2
                        dataTable3B.Columns.Add("G3_(L)"); //Add Column3
                        dataTable3B.Columns.Add("G3_(R)"); //Add Column4
                        dataTable3B.Columns.Add("G4_(L)"); //Add Column5
                        dataTable3B.Columns.Add("G4_(R)"); //Add Column6
                        dataTable3B.Columns.Add("G5_(L)"); //Add Column7
                        dataTable3B.Columns.Add("G5_(R)"); //Add Column8
                        dataTable3B.Columns.Add("G6_(L)"); //Add Column9
                        dataTable3B.Columns.Add("G6_(R)"); //Add Column10
                        dataTable3B.Columns.Add("G7_(L)"); //Add Column11
                        dataTable3B.Columns.Add("G7_(R)"); //Add Column12
                        dataTable3B.Columns.Add("G8_(L)"); //Add Column13
                        dataTable3B.Columns.Add("G8_(R)"); //Add Column14
                        dataTable3B.Columns.Add("G9_(L)"); //Add Column15
                        dataTable3B.Columns.Add("G9_(R)"); //Add Column16
                        dataTable3B.Columns.Add("GA_(L)"); //Add Column17
                        dataTable3B.Columns.Add("GA_(R)"); //Add Column18
                        dataTable3B.Columns.Add("GB_(L)"); //Add Column19
                        dataTable3B.Columns.Add("GB_(R)"); //Add Column20
                        dataTable3B.Columns.Add("GC_(L)"); //Add Column21
                        dataTable3B.Columns.Add("GC_(R)"); //Add Column22
                        dataTable3B.Columns.Add("GD_(L)"); //Add Column23
                        dataTable3B.Columns.Add("GD_(R)"); //Add Column24
                        dataTable3B.Columns.Add("GE_(L)"); //Add Column25
                        dataTable3B.Columns.Add("GE_(R)"); //Add Column26
                        dataTable3B.Columns.Add("GF_(L)"); //Add Column27
                        dataTable3B.Columns.Add("GF_(R)"); //Add Column28
                        dataTable3B.Columns.Add("GG_(L)"); //Add Column29
                        dataTable3B.Columns.Add("GG_(R)"); //Add Column30
                        dataTable3B.Columns.Add("GH_(L)"); //Add Column31
                        dataTable3B.Columns.Add("GH_(R)"); //Add Column32
                        dataTable3B.Columns.Add("GI_(L)"); //Add Column33
                        dataTable3B.Columns.Add("GI_(R)"); //Add Column34
                        dataTable3B.Columns.Add("GJ_(L)"); //Add Column35
                        dataTable3B.Columns.Add("GJ_(R)"); //Add Column36
                        dataTable3B.Columns.Add("GK_(L)"); //Add Column37
                        dataTable3B.Columns.Add("GK_(R)"); //Add Column38
                        dataTable3B.Columns.Add("GL_(L)"); //Add Column39
                        dataTable3B.Columns.Add("GL_(R)"); //Add Column40
                        dataTable3B.Columns.Add("GM_(L)"); //Add Column41
                        dataTable3B.Columns.Add("GM_(R)"); //Add Column42
                        dataTable3B.Columns.Add("GN_(L)"); //Add Column43
                        dataTable3B.Columns.Add("GN_(R)"); //Add Column44
                        dataTable3B.Columns.Add("GO_(L)"); //Add Column45
                        dataTable3B.Columns.Add("GO_(R)"); //Add Column46
                        dataTable3B.Columns.Add("GP_(L)"); //Add Column47
                        dataTable3B.Columns.Add("GP_(R)"); //Add Column48
                        stateDisplayDataB = 4;
                        break;
                    case 4: //State4 : Add Row for Items
                        dataTable3B.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row0 : INPUT
                        dataTable3B.Rows.Add((readabilityFailTarget_B.ToString("#,##0.00") + "%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row1 : READABILITY FAIL
                        dataTable3B.Rows.Add((etesterFailTarget_B.ToString("#,##0.00") + "%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row2 : ETESTER FAIL
                        dataTable3B.Rows.Add((badOCRTarget_B.ToString("#,##0.00") + "%"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row3 : BAD OCR
                        dataTable3B.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); //Add in ITEM Row4 : SW.VERSION

                        dataGridView3B.DataSource = dataTable3B; //Dump data in Table
                        dataGridView3B.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Make Text Center in Header Cell
                        dataGridView3B.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //Make Text Center in Cell
                        stateDisplayDataB = 5;
                        break;
                    case 5: //State5 : Check HSA Input, HGA ReadabilityFail,

                        foreach (string line in genesis) //Check Line G2 to GN
                        {
                            for (int i = 0; i < (indexCsvDataRowB - 1); i++) //Check again maybe noneed to -1
                            {
                                if (dataTable2B.Rows[i][21].ToString() == line) //Check in Column21(LI)
                                {
                                    if (dataTable2B.Rows[i][11].ToString().EndsWith("1"))
                                    {
                                        inputLineHeadL_B++; //Increase Input Head L of Process B
                                        if (dataTable2B.Rows[i][30].ToString() == "..........")
                                        {
                                            readabilityFailLineHeadL_B++; //Increase Readability Fail Head L of Process B
                                        }
                                        if (dataTable2B.Rows[i][7].ToString() != "0000")
                                        {
                                            etesterFailLineHeadL_B++; //Increase ETEST FAIL Head L of Process B
                                        }
                                        if (dataTable2B.Rows[i][30].ToString() == "..ROI.NG..")
                                        {
                                            badOCRLineHeadL_B++; //Increase BAD OCR Head L of Process B
                                        }
                                        softwareVersionL_B = dataTable2B.Rows[i][13].ToString(); //Store SW.Version Head L use to Run Machine
                                    }
                                    else if (dataTable2B.Rows[i][11].ToString().EndsWith("2"))
                                    {
                                        inputLineHeadR_B++; //Increase Input Head R of Process B
                                        if (dataTable2B.Rows[i][30].ToString() == "..........")
                                        {
                                            readabilityFailLineHeadR_B++; //Increase Readability Fail Head R of Process B
                                        }
                                        if (dataTable2B.Rows[i][7].ToString() != "0000")
                                        {
                                            etesterFailLineHeadR_B++; //Increase ETEST FAIL Head R of Process B
                                        }
                                        if (dataTable2B.Rows[i][30].ToString() == "..ROI.NG..")
                                        {
                                            badOCRLineHeadR_B++; //Increase BAD OCR Head R of Process B
                                        }
                                        softwareVersionR_B = dataTable2B.Rows[i][13].ToString(); //Store SW.Version Head R use to Run Machine
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            //Console.WriteLine(indexCsvDataRowB - 1); //Debug

                            //*********** HSA Input *******************
                            dataTable3B.Rows[0][lineHeadL_B] = (inputLineHeadL_B / 18).ToString(); //Write HSA inputLineHeadL_B Value (HGA / 18 = HSA)
                            dataTable3B.Rows[0][lineHeadR_B] = (inputLineHeadR_B / 18).ToString(); //Write HSA inputLineHeadR_B Value (HGA / 18 = HSA)
                            //*********** HGA Readability Fail ****************
                            if ((readabilityFailLineHeadL_B == 0) && (readabilityFailLineHeadR_B == 0)) //00
                            {
                                dataTable3B.Rows[1][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadL_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[1][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadR_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_B == 0) && (readabilityFailLineHeadR_B != 0)) //01
                            {
                                dataTable3B.Rows[1][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadL_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[1][lineHeadR_B] = (((readabilityFailLineHeadR_B / inputLineHeadR_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadR_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_B != 0) && (readabilityFailLineHeadR_B == 0)) //10
                            {
                                dataTable3B.Rows[1][lineHeadL_B] = (((readabilityFailLineHeadL_B / inputLineHeadL_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadL_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[1][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadR_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((readabilityFailLineHeadL_B != 0) && (readabilityFailLineHeadR_B != 0)) //11
                            {
                                dataTable3B.Rows[1][lineHeadL_B] = (((readabilityFailLineHeadL_B / inputLineHeadL_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadL_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[1][lineHeadR_B] = (((readabilityFailLineHeadR_B / inputLineHeadR_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[1][lineHeadR_B].ToString().Replace("%", "")) >= readabilityFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 1].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //*********** HSA ETEST Fail ****************
                            if ((etesterFailLineHeadL_B == 0) && (etesterFailLineHeadR_B == 0)) //00
                            {
                                dataTable3B.Rows[2][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadL_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[2][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadR_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_B == 0) && (etesterFailLineHeadR_B != 0)) //01
                            {
                                dataTable3B.Rows[2][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadL_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[2][lineHeadR_B] = ((((etesterFailLineHeadR_B / 18) / (inputLineHeadR_B / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadR_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_B != 0) && (etesterFailLineHeadR_B == 0)) //10
                            {
                                dataTable3B.Rows[2][lineHeadL_B] = ((((etesterFailLineHeadL_B / 18) / (inputLineHeadL_B / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadL_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[2][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HSA etesterFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadR_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((etesterFailLineHeadL_B != 0) && (etesterFailLineHeadR_B != 0)) //11
                            {
                                dataTable3B.Rows[2][lineHeadL_B] = ((((etesterFailLineHeadL_B / 18) / (inputLineHeadL_B / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadL_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadL_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[2][lineHeadR_B] = ((((etesterFailLineHeadR_B / 18) / (inputLineHeadR_B / 18))) * 100).ToString("#,##0.00") + "%"; //Write HSA readabilityFailLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[2][lineHeadR_B].ToString().Replace("%", "")) >= etesterFailTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 2].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //********** HGA BAD OCR ****************
                            if ((badOCRLineHeadL_B == 0) && (badOCRLineHeadR_B == 0)) //00
                            {
                                dataTable3B.Rows[3][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_B  Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadL_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[3][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadR_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_B == 0) && (badOCRLineHeadR_B != 0)) //01
                            {
                                dataTable3B.Rows[3][lineHeadL_B] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_B  Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadL_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[3][lineHeadR_B] = (((badOCRLineHeadR_B / inputLineHeadR_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadR_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_B != 0) && (badOCRLineHeadR_B == 0)) //10
                            {
                                dataTable3B.Rows[3][lineHeadL_B] = (((badOCRLineHeadL_B / inputLineHeadL_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_B  Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadL_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[3][lineHeadR_B] = 0.ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadR_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            if ((badOCRLineHeadL_B != 0) && (badOCRLineHeadR_B != 0)) //11
                            {
                                dataTable3B.Rows[3][lineHeadL_B] = (((badOCRLineHeadL_B / inputLineHeadL_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadL_B  Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadL_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadL_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                                dataTable3B.Rows[3][lineHeadR_B] = (((badOCRLineHeadR_B / inputLineHeadR_B)) * 100).ToString("#,##0.00") + "%"; //Write HGA badOCRLineHeadR_B Value
                                if (double.Parse(dataTable3B.Rows[3][lineHeadR_B].ToString().Replace("%", "")) >= badOCRTarget_B) //Check >= Target?
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    dataGridView3B[lineHeadR_B, 3].Style.BackColor = Color.LawnGreen;
                                }
                            }
                            //********** Line Software Version ***************
                            dataTable3B.Rows[4][lineHeadL_B] = softwareVersionL_B; //Write Line Software Version
                            dataTable3B.Rows[4][lineHeadR_B] = softwareVersionR_B; //Write Line Software Version
                            //**********
                            inputLineHeadL_B = 0; //Reset inputLineHeadL_B
                            inputLineHeadR_B = 0; //Reset inputLineHeadR_B
                            readabilityFailLineHeadL_B = 0; //Reset readabilityFailLineHeadL_B
                            readabilityFailLineHeadR_B = 0; //Reset readabilityFailLineHeadR_B
                            etesterFailLineHeadL_B = 0; //Reset etesterFailLineHeadL_B
                            etesterFailLineHeadR_B = 0; //Reset etesterFailLineHeadR_B
                            badOCRLineHeadL_B = 0; //Reset badOCRLineHeadL_B
                            badOCRLineHeadR_B = 0; //Reset badOCRLineHeadR_B
                            softwareVersionL_B = ""; //Reset Line Software Version
                            softwareVersionR_B = ""; //Reset Line Software Version
                            lineHeadL_B += 2; //Increase to Next Head
                            lineHeadR_B += 2; //Increase to Next Head
                        }
                        lineHeadL_B = 1; //Reset lineHeadL_B
                        lineHeadR_B = 2; //Reset lineHeadR_B
                        stateDisplayDataB = 6;
                        break;
                    case 6: //State6 : Dump into dataGridView3B
                        //dataGridView3B.DataSource = dataTable3B;
                        dataGridView3B.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //Auto Adjust Column Width
                        dataGridView3B.Columns[0].DefaultCellStyle.ForeColor = Color.Red; //Change Text in Column0 to Red Color
                        dataGridView3B.Columns[0].Frozen = true; //Freeze Column0
                        stateDisplayDataB = 10;
                        break;
                    case 10:
                        stateDisplayDataB = 0;
                        switchDisplayDataB = false;
                        //Application.Restart(); // Debug
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : display_DataB


        //##### End : My function Area #####

        private void Form1_Load(object sender, EventArgs e)
        {
            GC.Collect(); //Force garbage collection
            GC.WaitForPendingFinalizers(); //Wait for all finalizer

            dataTable1A.Columns.Add("INDEX");
            dataTable1A.Columns.Add("WORD");
            dataTable1B.Columns.Add("INDEX");
            dataTable1B.Columns.Add("WORD");
            switchDownloadCsvDataA = true; //Start function : download_CsvData1()
            //switchDownloadCsvDataB = true; //Start function : download_CsvData2()
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            // Reset all necessary variables
            this.webBrowser1.Navigate(string.Empty);
            this.webBrowser2.Navigate(string.Empty);

            textBoxUrlToGo.Clear();
            textBoxUrlResponseA.Clear();
            textBoxUrlResponseB.Clear();
            textBoxWebCodeResponseA.Clear();
            textBoxWebCodeResponseB.Clear();
            textBoxCsvDataA.Clear();
            textBoxCsvDataB.Clear();

            textBoxWebCodeResponseStringLengthA.Clear();
            textBoxWebCodeResponseSubStringLengthA.Clear();
            textBoxWebCodeResponseLastSubStringA.Clear();
            textBoxWebCodeResponseSubStringIndex17A.Clear();
            textBoxWebCodeResponseSubStringIndex17AfterTrimmedA.Clear();
            textBoxParametricDataRetrieveProductionDB_A.Clear();
            textBoxIndexRunningA.Clear();
            textBoxWordRunningA.Clear();
            textBoxUrlToRetrieveParamA.Clear();
            textBoxUrlToGetCsvDataA.Clear();

            textBoxWebCodeResponseStringLengthB.Clear();
            textBoxWebCodeResponseSubStringLengthB.Clear();
            textBoxWebCodeResponseLastSubStringB.Clear();
            textBoxWebCodeResponseSubStringIndex17B.Clear();
            textBoxWebCodeResponseSubStringIndex17AfterTrimmedB.Clear();
            textBoxParametricDataRetrieveProductionDB_B.Clear();
            textBoxIndexRunningB.Clear();
            textBoxWordRunningB.Clear();
            textBoxUrlToRetrieveParamB.Clear();
            textBoxUrlToGetCsvDataB.Clear();

            dataTable1A.Clear(); //Clear datatable
            dataTable1B.Clear(); //Clear datatable

            textBoxLastIndexOfCsvDataRowA.Clear();
            textBoxLastIndexOfCsvDataColumnA.Clear();

            textBoxLastIndexOfCsvDataRowB.Clear();
            textBoxLastIndexOfCsvDataColumnB.Clear();

            dataTable2A.Clear(); //Clear datatable
            dataTable2B.Clear(); //Clear datatable

            switchDownloadCsvDataA = false; //Stop function : download_CsvData1()
            switchDownloadCsvDataB = false; //Stop function : download_CsvData2()

            statusGoUrlA = false;
            stateGoUrlA = 0;

            statusGoUrlB = false;
            stateGoUrlB = 0;

            statusAddWordInRowTableA = false;
            stateAddWordInRowTableA = 0;

            statusAddWordInRowTableB = false;
            stateAddWordInRowTableB = 0;

            statusShowUrlToRetrieveProcessA = false;
            stateShowUrlToRetrieveProcessA = 0;

            statusShowUrlToRetrieveProcessB = false;
            stateShowUrlToRetrieveProcessB = 0;

            statusFindWordIndexA = false;
            stateFindWordIndexA = 0;

            statusFindWordIndexB = false;
            stateFindWordIndexB = 0;

            statusShowUrlToRetrieveParamA = false;
            urlToRetrieveParamA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Added new
            indexRunningA = 0;
            stateShowUrlToRetrieveParamA = 0;

            statusShowUrlToRetrieveParamB = false;
            urlToRetrieveParamB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Added new
            indexRunningB = 0;
            stateShowUrlToRetrieveParamB = 0;

            statusShow_UrlToGetCsvDataA = false;
            urlToGetCsvDataA = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";
            indexRunningA = 0;
            indexParam1800HeadA = 0;
            indexParam1800UnitA = 0;
            indexParam1800HeadValueA = 0;
            indexParam1800UnitValueA = 0;
            stateShow_UrlToGetCsvDataA = 0;

            statusShow_UrlToGetCsvDataB = false;
            urlToGetCsvDataB = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";
            indexRunningB = 0;
            indexParam1800HeadB = 0;
            indexParam1800UnitB = 0;
            indexParam1800HeadValueB = 0;
            indexParam1800UnitValueB = 0;
            stateShow_UrlToGetCsvDataB = 0;

            statusWebBrowser1DocumentCompleted = false;
            indexCsvDataRowA = 0;
            indexCsvDataColumnA = 0;
            stateDownloadCsvDataA = 0;
            //tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor

            statusWebBrowser2DocumentCompleted = false;
            indexCsvDataRowB = 0;
            indexCsvDataColumnB = 0;
            stateDownloadCsvDataB = 0;
            //tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor

            //Begin again

            GC.Collect(); //Force garbage collection
            GC.WaitForPendingFinalizers(); //Wait for all finalizer

            switchDownloadCsvDataA = true; //Start function : download_CsvData1()
            //switchDownloadCsvDataB = true; //Start function : download_CsvData2()
        }
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusWebBrowser1DocumentCompleted = false; //Set status = false
        }

        private void webBrowser2_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            statusWebBrowser2DocumentCompleted = false; //Set status = false
        }

        public void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }
        private void webBrowser2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusWebBrowser1DocumentCompleted = true; //Set status = true
        }
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusWebBrowser2DocumentCompleted = true; //Set status = true
        }


        private void buttonTestTrim_Click(object sender, EventArgs e) //Must Do After Login completed
        {
        }

        private void buttonTestGoParametricUrl1_Click(object sender, EventArgs e)
        {
        }

        private void timerStateCyclic_Tick(object sender, EventArgs e)
        {
            check_Time(); //Check Time to use Function download_CsvDataB() must between 09:00 to 23:54 
            download_CsvDataA(); //Auto download CSV Data Yesterday 07:00 to Today 06:59
            download_CsvDataB(); //Auto download CSV Data Today 07:00 to Today 23.59
            display_DataA(); //Auto display Data Yesterday 07:00 to Today 06:59
            display_DataB(); //Auto display Data Today 07:00 to Now(23:59:59)
            textBoxStateDownloadCsvDataA.Text = stateDownloadCsvDataA.ToString();
            textBoxStateDownloadCsvDataB.Text = stateDownloadCsvDataB.ToString();
            textBoxStateDisplayDataA.Text = stateDisplayDataA.ToString();
            textBoxStateDisplayDataB.Text = stateDisplayDataB.ToString();
        }

    }
}

