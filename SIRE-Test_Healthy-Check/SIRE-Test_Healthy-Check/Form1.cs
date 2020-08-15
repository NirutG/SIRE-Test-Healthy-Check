using System;
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
        string[] wordWebCodeResponse; //Check Word in textBoxWebCodeResponse
        uint indexWordWebCodeResponse = 0; //Index of string array, wordWebCodeResponse

        bool statusWebBrowser1DocumentCompleted = false; //Decare for check when webBrowser1_DocumentCompleted
        bool statusDelay = false; //Check Function delay_State is done?
        bool statusAddWordInRowTable = false; //Check Function addword_InRowTable is done?
        bool statusFindWordIndex = false; //Check Function find_WordIndex is done?
        bool statusGoUrl = false; //Check Function go_Url is done?
        bool statusShowUrlToRetrieveProcess = false; //Check Function show_UrlToRetrieveProcess
        bool statusShowUrlToRetrieveParam = false; //Check Function show_UrlToRetrieveParam
        bool statusShow_UrlToGetCsvData = false; //Check Function show_UrlToGetCsvData

        byte stateDelay = 0; //Initial State of Function delay at state0
        byte stateAddWordInRowTable = 0; //Initial State of Function addword_InRowTable
        byte stateFindWordIndex = 0; //Initial State of Function find_WordIndex
        byte stateGoUrl = 0; //Initial State of Function go_Url
        byte stateShowUrlToRetrieveProcess = 0; //Initial State of Function show_UrlToRetrieveProcess
        double stateShowUrlToRetrieveParam = 0; //Initial State of Function show_UrlToRetrieveParam
        double stateShow_UrlToGetCsvData = 0; //Initial State of Function show_UrlToGetCsvData

        string[] wordSplit; //Decare String array to use in Function split_Text()
        string urlToRetrieveParam = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParam
        string urlToGetCsvData = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParam
        string wordTarget = ""; //Initial to use with Function fine_Word()
        string[] wordCsvDataRow; //Decare String array to receive CSV Data separate by Row
        string[] wordCsvDataColumn; //Decare String array to receive CSV Data separate by Column
        uint indexCsvDataRow = 0; //Decare to be Row index of CsvData
        uint indexCsvDataColumn = 0; //Decare to be Column index of CsvData

        string wordRunning = ""; //Initial to use in Function find_WordIndex
        uint indexRunning = 0; //Initial to use in Function find_WordIndex
        uint indexParam1800Head = 0; //Initial to use in Function show_UrlToGetCsvData()
        uint indexParam1800Unit = 0; //Initial to use in Function show_UrlToGetCsvData()
        uint indexParam1800HeadValue = 0; //Initial to use in Function show_UrlToGetCsvData()
        uint indexParam1800UnitValue = 0; //Initial to use in Function show_UrlToGetCsvData()
        double testShow = 10.0;
        uint test = 0;
        bool switchStepRun = false; //Decare to test function by STEP Run
        bool switchDownloadCsvData = false; //Decare for ON function download_CsvData
        bool switchDisplayData = false; //Decare for ON function display_Data

        double stateDownloadCsvData = 0; //Initial State of Function download_CsvData at state0
        byte stateDisplayData = 0; //Initial State of Function display_Data at state0
        byte subStateDisplayData1 = 0; //Initial subStateDisplayData1 of Function display_Data at State2


        uint errorCodeTotal = 0; //Initial Count Total Error Code
        uint errorCodePass = 0; //Initial Count Pass Error Code
        uint errorCodeFail = 0; //Initial Count Fail Error Code
        uint countErrorCodeLoop = 0; //Initial errorCodeFail counting 
        string checkColumnPfcd = ""; //Initial for check Column Name : PFCD

        //string[] errorCodeNumber; //Decare to store ErrorCode Number from dataGridView3
        uint index = 0; //Decare for separate ErrorCode count how many difference ErrorCode in dataGridView4
        string[] errorCode = new string[100000000]; //Decare for store ErrorCode 
        uint[] errorCodeQuantity = new uint[70000]; //Decare for Store ErrorCode Quantity in dataGridView4
        string errorCodeInColumn = "";
        string errorCodeCheck = "";



        DataTable dataTable1 = new DataTable(); //Decare to use Class DataTable to help checking
        DataTable dataTable2 = new DataTable(); //Decare to use Class DataTable to help checking CSV Data
        DataTable dataTable3 = new DataTable(); //Decare to use Class DataTable to help checking Display Data
        DataTable dataTable4 = new DataTable(); //Decare to use Class DataTable to help count ErrorCode Count
        AutoHand autoHand = new AutoHand();//Decare to use DLL File of AutoItX3
        //Point point = new Point(0, 0); //Decare point x=0, y=0
        Point point = new Point(0, 0); //Decare point x=0, y=0
        WebClient webClient1 = new WebClient();
        
        

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
        }

        //##### Begin : My function Area #####

        //##### Begin : delay_State
        public bool delay_State(int intervalValue) //Delay function
        {
            switch(stateDelay)
            {
                case 0: //Initial variable
                    statusDelay = false;
                    stateDelay = 1;
                    break;
                case 1: //Set Interval and Enable timer1
                    timer1.Interval = intervalValue;
                    timer1.Enabled = true;
                    stateDelay = 2;
                    break;
                case 2: //Wait until timer1 will Tick
                    if(statusDelay == true)
                    {
                        stateDelay = 0;
                    }
                    else
                    {
                        stateDelay = 2;
                    }
                    break;
                default:
                    break;
            }
            return statusDelay;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusDelay = true;
            timer1.Enabled = false;
        }
        //##### End : delay_State

        //##### Begin : go_Url
        private bool go_Url(string url)
        {
            switch (stateGoUrl)
            {
                case 0: //State0 : Initial Variables
                    statusGoUrl = false;
                    stateGoUrl = 1;
                    break;
                case 1: //State1 : Go URL
                    this.webBrowser1.Navigate(url);
                    stateGoUrl = 2;
                    break;
                case 2: //State2 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                    if (statusWebBrowser1DocumentCompleted)
                    {
                        textBoxUrlResponse.Text = "" + webBrowser1.Url;
                        stateGoUrl = 3;
                    }
                    break;
                case 3: //State3 : Show WebCode Response from Server of Index Page
                    textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                    stateGoUrl = 4;
                    break;
                case 4: //State4 : Clear Variables
                    statusGoUrl = true;
                    stateGoUrl = 0;
                    break;
                default:
                    break;
            }
        return statusGoUrl;
        }
        //##### End : go_Url

        //##### Begin : addWordInRow_Table1
        private bool addword_InRowTable()
        {
            switch (stateAddWordInRowTable)
            {
                case 0: //Initial Variables
                    statusAddWordInRowTable = false;
                    stateAddWordInRowTable = 1;
                    break;
                case 1: //State1 : Show WebCode Response String Length from Server
                    textBoxWebCodeResponseStringLength.Text = textBoxWebCodeResponse.Text.Length.ToString();
                    stateAddWordInRowTable = 2;
                    break;
                case 2: //State2 : Make SubString by Remove no need characters from Web Code Response
                    textBoxWebCodeResponse.Text = Regex.Replace(textBoxWebCodeResponse.Text, "\t|\n|\r", ""); //Test1 = OK
                    //textBoxWebCodeResponse.Text = Regex.Replace(textBoxWebCodeResponse.Text, @"\\s+", ""); //Test2 = Not OK

                    wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(null); //SubState2.1 : Split null
                    wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); //SubState2.2
                    wordWebCodeResponse = textBoxWebCodeResponse.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //SubState2.3 (InnerState2.1 to 2.3 = Remove no need characters)

                    stateAddWordInRowTable = 3;
                    break;
                case 3: //State3 : Show WebCode Response SubString Length
                    textBoxWebCodeResponseSubStringLength.Text = wordWebCodeResponse.Length.ToString();
                    stateAddWordInRowTable = 4;
                    break;
                case 4://State4 : Show WebCode Response Last SubString 
                    textBoxWebCodeResponseLastSubString.Text = wordWebCodeResponse.Last();
                    stateAddWordInRowTable = 5;
                    break;
                case 5: //State5 : Clear all data in datatable
                    //dataTable1.Clear();
                    dataTable1.Clear(); //Clear datatable
                    //dataTable1.Columns.Clear(); //Clear Columns of datatable
                    //dataTable1.Rows.Clear(); //Clear Rows of datatable
                    stateAddWordInRowTable = 6;
                    break;
                case 6: //State6 : Initial indexWordWebCodeResponse = 0
                    indexWordWebCodeResponse = 0;
                    stateAddWordInRowTable = 7;
                    break;
                case 7: //State7 : Looping until last word in String Array wordWebCodeResponse
                    foreach (var word in wordWebCodeResponse)
                    {
                        dataTable1.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                        indexWordWebCodeResponse++;
                    }
                    stateAddWordInRowTable = 8;
                    break;
                case 8: //State8 : Input dataGridView1 by dataTable1 to show in Table
                    dataGridView1.DataSource = dataTable1;
                    stateAddWordInRowTable = 9;
                    break;
                case 9: //State9 : Clear Variable
                    stateAddWordInRowTable = 0;
                    statusAddWordInRowTable = true;
                    break;
                default:
                    break;
            }
            return statusAddWordInRowTable;
        }
        //##### End : addWordInRow_Table1

        //##### Begin : show_UrlToRetrieveProcess
        private bool show_UrlToRetrieveProcess()
        {
            switch (stateShowUrlToRetrieveProcess)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveProcess = false;
                    stateShowUrlToRetrieveProcess = 1;
                    break;
                case 1: //State1 : Show wordWebCodeResponse[17] to textbox
                    textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17];
                    stateShowUrlToRetrieveProcess = 2;
                    break;
                case 2: //State2 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                    textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56);
                    stateShowUrlToRetrieveProcess = 3;
                    break;
                case 3: //State3 : Show ParametricDataRetrieveProductionDB URL to textbox
                    textBoxParametricDataRetrieveProductionDB.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56);
                    stateShowUrlToRetrieveProcess = 4;
                    break;
                case 4: //State4 : Clear Variable
                    statusShowUrlToRetrieveProcess = true;
                    stateShowUrlToRetrieveProcess = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveProcess;
        }
        //##### End : show_UrlToRetrieveProcess

        //##### Begin : split_Text
        private string split_Text(string textInput)
        {
            if(textInput == "<option>PCM-ALL</option>") // For only Item8 : <option>PCM-ALL</option>
            {
                wordSplit = textInput.Split('<','>');
                return wordSplit[2];
            }
            else
            {
                wordSplit = textInput.Split('\'');
                return wordSplit[1];
            }
        }
        //##### End : split_Text

        //##### Begin : find_WordIndex
        private bool find_WordIndex(string wordToCompare, uint indexInitial)
        {
            switch (stateFindWordIndex)
            {
                case 0: //State0 : Initial Variables
                    statusFindWordIndex = false;
                    stateFindWordIndex = 1;
                    break;
                case 1: //State1 : Initial wordRunning
                    indexRunning = indexInitial;
                    textBoxIndexRunning.Text = indexRunning.ToString(); // Check index
                    wordRunning = wordWebCodeResponse[indexRunning];
                    textBoxWordRunning.Text = wordRunning; //Check Word Running
                    stateFindWordIndex = 2;
                    break;
                case 2: //State2 : Compare Words
                    if(wordWebCodeResponse[indexRunning] != wordToCompare)
                    {
                        textBoxIndexRunning.Text = indexRunning.ToString(); // Check index

                        wordRunning = wordWebCodeResponse[indexRunning];
                        textBoxWordRunning.Text = wordRunning; //Check Word Running

                        indexRunning++;
                    }
                    else
                    {
                        textBoxIndexRunning.Text = indexRunning.ToString(); // Check index
                        wordRunning = wordWebCodeResponse[indexRunning];
                        textBoxWordRunning.Text = wordRunning; //Check Word Running
                        stateFindWordIndex = 3;
                    }
                    break;
                case 3: //State3 : Clear Variables
                    statusFindWordIndex = true;
                    stateFindWordIndex = 0;
                    break;
                default:
                    break;
            }
            return statusFindWordIndex;
        }
        //##### End : find_WordIndex

        //##### Begin : show_UrlToRetrieveParam
        private bool show_UrlToRetrieveParam()
        {
            switch (stateShowUrlToRetrieveParam)
            {
                case 0: //Initial Variable
                    statusShowUrlToRetrieveParam = false;
                    urlToRetrieveParam = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Added new
                    indexRunning = 0;
                    stateShowUrlToRetrieveParam = 1;
                    break;
                case 1: //State1 : Show URL to RetrieveParam
                    if (find_WordIndex("name='action'", indexRunning))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item1 : name='action'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item2 : value='retrieveProcess'><div
                        indexRunning += 1; // Update value
                        stateShowUrlToRetrieveParam = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='location'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item3 : name='location'>
                        stateShowUrlToRetrieveParam = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='0'>PRB</option>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item4 : value='0'>PRB</option>
                        stateShowUrlToRetrieveParam = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mtype'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item5 : name='mtype'
                        stateShowUrlToRetrieveParam = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='PCM%'>PCM%</option>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "25" + "&"; //Item6 : value='PCM%'>PCM%</option>
                        stateShowUrlToRetrieveParam = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='modelid'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item7 : name='modelid'>
                        stateShowUrlToRetrieveParam = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("<option>PCM-ALL</option>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item8 : <option>PCM-ALL</option>
                        stateShowUrlToRetrieveParam = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='datekey'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item9 : name='datekey'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item10 : value='test'
                        indexRunning += 1; // Update value
                        stateShowUrlToRetrieveParam = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='enddate0'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item11 : name='enddate0'>
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 2]) + "&"; //Item12 : value= current date
                        indexRunning += 2; // Update value
                        stateShowUrlToRetrieveParam = 2;
                    }
                    break;


                case 2: //State2 : Show URL to RetrieveParam(Continue)
                    if(find_WordIndex("name='endtime0'", (indexRunning + 1))) 
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item13 : name='endtime0'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item14 : value='000000'
                        indexRunning += 1; // Update value
                        stateShowUrlToRetrieveParam = 2.1;
                    }
                    break;
                case 2.1: //State2.1 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='enddate1'", (indexRunning + 1))) 
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item15 : name='enddate1'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 3]) + "&"; //Item16 : value= current date
                        indexRunning += 3; // Update value
                        stateShowUrlToRetrieveParam = 2.2;
                    }
                    break;
                case 2.2: //State2.2 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='endtime1'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item17 : name='endtime1'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item18 : value='235959'
                        indexRunning += 1; // Update value
                        stateShowUrlToRetrieveParam = 2.3;
                    }
                    break;
                case 2.3: //State2.3 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='scanmode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item19 : name='scanmode'
                        stateShowUrlToRetrieveParam = 2.4;
                    }
                    break;
                case 2.4: //State2.4 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='all'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item20 : value='all'
                        stateShowUrlToRetrieveParam = 2.5;
                    }
                    break;
                case 2.5: //State2.5 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='scanmodesub'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item21 : name='scanmodesub'
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item22 : value='found'
                        indexRunning += 1; // Update value
                        stateShowUrlToRetrieveParam = 2.6;
                    }
                    break;
                case 2.6: //State2.6 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='process'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item23 : name='process'>
                        stateShowUrlToRetrieveParam = 2.7;
                    }
                    break;
                case 2.7: //State2.7 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='1800'>1800:", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item24 : value='1800'>1800:
                        stateShowUrlToRetrieveParam = 2.8;
                    }
                    break;
                case 2.8: //State2.8 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='snlist'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item25 : name='snlist'
                        stateShowUrlToRetrieveParam = 2.9;
                    }
                    break;
                case 2.9: //State2.9 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item26 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.11;
                    }
                    break;
                case 2.11: //State2.11 : Show URL to RetrieveParam(Continue) // Variable Double 2.1 will equal 2.10
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item27 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.12;
                    }
                    break;
                case 2.12: //State2.12 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item28 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.13;
                    }
                    break;
                case 2.13: //State2.13 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item29 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.14;
                    }
                    break;
                case 2.14: //State2.14 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item30 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.15;
                    }
                    break;
                case 2.15: //State2.15 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item31 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.16;
                    }
                    break;
                case 2.16: //State2.16 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item32 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.17;
                    }
                    break;
                case 2.17: //State2.17 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item33 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.18;
                    }
                    break;
                case 2.18: //State2.18 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item34 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.19;
                    }
                    break;
                case 2.19: //State2.19 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item35 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.21;
                    }
                    break;
                case 2.21: //State2.21 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item36 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.22;
                    }
                    break;
                case 2.22: //State2.22 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item37 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.23;
                    }
                    break;
                case 2.23: //State2.23 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item38 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.24;
                    }
                    break;
                case 2.24: //State2.24 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item39 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.25;
                    }
                    break;
                case 2.25: //State2.25 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item40 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.26;
                    }
                    break;
                case 2.26: //State2.26 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item41 : name='pfcode'
                        stateShowUrlToRetrieveParam = 2.27;
                    }
                    break;
                case 2.27: //State2.27 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item42 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.28;
                    }
                    break;
                case 2.28: //State2.28 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item43 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.29;
                    }
                    break;
                case 2.29: //State2.29 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item44 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.31;
                    }
                    break;
                case 2.31: //State2.31 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item45 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.32;
                    }
                    break;
                case 2.32: //State2.32 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item46 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.33;
                    }
                    break;
                case 2.33: //State2.33 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item47 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.34;
                    }
                    break;
                case 2.34: //State2.34 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item48 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.35;
                    }
                    break;
                case 2.35: //State2.35 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item49 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.36;
                    }
                    break;
                case 2.36: //State2.36 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item50 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.37;
                    }
                    break;
                case 2.37: //State2.37 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item51 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.38;
                    }
                    break;
                case 2.38: //State2.38 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item52 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.39;
                    }
                    break;
                case 2.39: //State2.39 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item53 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.41;
                    }
                    break;
                case 2.41: //State2.41 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item54 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.42;
                    }
                    break;
                case 2.42: //State2.42 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item55 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.43;
                    }
                    break;
                case 2.43: //State2.43 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item56 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.44;
                    }
                    break;
                case 2.44: //State2.44 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hddtrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item57 : name='hddtrial'
                        stateShowUrlToRetrieveParam = 2.45;
                    }
                    break;
                case 2.45: //State2.45 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item58 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.46;
                    }
                    break;
                case 2.46: //State2.46 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item59 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.47;
                    }
                    break;
                case 2.47: //State2.47 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item60 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.48;
                    }
                    break;
                case 2.48: //State2.48 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item61 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.49;
                    }
                    break;
                case 2.49: //State2.49 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item62 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.51;
                    }
                    break;
                case 2.51: //State2.51 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item63 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.52;
                    }
                    break;
                case 2.52: //State2.52 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item64 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.53;
                    }
                    break;
                case 2.53: //State2.53 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item65 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.54;
                    }
                    break;
                case 2.54: //State2.54 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item66 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.55;
                    }
                    break;
                case 2.55: //State2.55 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item67 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.56;
                    }
                    break;
                case 2.56: //State2.56 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item68 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.57;
                    }
                    break;
                case 2.57: //State2.57 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item69 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.58;
                    }
                    break;
                case 2.58: //State2.58 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item70 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.59;
                    }
                    break;
                case 2.59: //State2.59 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item71 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.61;
                    }
                    break;
                case 2.61: //State2.61 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item72 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.62;
                    }
                    break;
                case 2.62: //State2.62 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='hsatrial'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item73 : name='hsatrial'
                        stateShowUrlToRetrieveParam = 2.63;
                    }
                    break;
                case 2.63: //State2.63 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='locid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item74 : name='locid'
                        stateShowUrlToRetrieveParam = 2.64;
                    }
                    break;
                case 2.64: //State2.64 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='locid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item75 : name='locid'
                        stateShowUrlToRetrieveParam = 2.65;
                    }
                    break;
                case 2.65: //State2.65 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='locid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item76 : name='locid'
                        stateShowUrlToRetrieveParam = 2.66;
                    }
                    break;
                case 2.66: //State2.66 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='locid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item77 : name='locid'
                        stateShowUrlToRetrieveParam = 2.67;
                    }
                    break;
                case 2.67: //State2.67 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item78 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.68;
                    }
                    break;
                case 2.68: //State2.68 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item79 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.69;
                    }
                    break;
                case 2.69: //State2.69 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item80 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.71;
                    }
                    break;
                case 2.71: //State2.71 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item81 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.72;
                    }
                    break;
                case 2.72: //State2.72 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item82 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.73;
                    }
                    break;
                case 2.73: //State2.73 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='mfgid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item83 : name='mfgid'
                        stateShowUrlToRetrieveParam = 2.74;
                    }
                    break;
                case 2.74: //State2.74 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item84 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.75;
                    }
                    break;
                case 2.75: //State2.75 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item85 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.76;
                    }
                    break;
                case 2.76: //State2.76 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item86 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.77;
                    }
                    break;
                case 2.77: //State2.77 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item87 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.78;
                    }
                    break;
                case 2.78: //State2.78 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item88 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.79;
                    }
                    break;
                case 2.79: //State2.79 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testerid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item89 : name='testerid'
                        stateShowUrlToRetrieveParam = 2.81;
                    }
                    break;
                case 2.81: //State2.81 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item90 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.82;
                    }
                    break;
                case 2.82: //State2.82 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item91 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.83;
                    }
                    break;
                case 2.83: //State2.83 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item92 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.84;
                    }
                    break;
                case 2.84: //State2.84 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item93 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.85;
                    }
                    break;
                case 2.85: //State2.85 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item94 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.86;
                    }
                    break;
                case 2.86: //State2.86 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cellid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item95 : name='cellid'
                        stateShowUrlToRetrieveParam = 2.87;
                    }
                    break;
                case 2.87: //State2.87 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testertype'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item96 : name='testertype'
                        stateShowUrlToRetrieveParam = 2.88;
                    }
                    break;
                case 2.88: //State2.88 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testertype'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item97 : name='testertype'
                        stateShowUrlToRetrieveParam = 2.89;
                    }
                    break;
                case 2.89: //State2.89 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testertype'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item98 : name='testertype'
                        stateShowUrlToRetrieveParam = 2.91;
                    }
                    break;
                case 2.91: //State2.91 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testertype'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item99 : name='testertype'
                        stateShowUrlToRetrieveParam = 2.92;
                    }
                    break;
                case 2.92: //State2.92 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item100 : name='testcode'
                        stateShowUrlToRetrieveParam = 2.93;
                    }
                    break;
                case 2.93: //State2.93 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item101 : name='testcode'
                        stateShowUrlToRetrieveParam = 2.94;
                    }
                    break;
                case 2.94: //State2.94 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item102 : name='testcode'
                        stateShowUrlToRetrieveParam = 2.95;
                    }
                    break;
                case 2.95: //State2.95 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='testcode'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item103 : name='testcode'
                        stateShowUrlToRetrieveParam = 2.96;
                    }
                    break;
                case 2.96: //State2.96 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_spdl'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item104 : name='partid_spdl'
                        stateShowUrlToRetrieveParam = 2.97;
                    }
                    break;
                case 2.97: //State2.97 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_disk'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item105 : name='partid_disk'
                        stateShowUrlToRetrieveParam = 2.98;
                    }
                    break;
                case 2.98: //State2.98 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_hsa'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item106 : name='partid_hsa'
                        stateShowUrlToRetrieveParam = 2.99;
                    }
                    break;
                case 2.99: //State2.99 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_card'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item107 : name='partid_card'
                        stateShowUrlToRetrieveParam = 2.101;
                    }
                    break;
                case 2.101: //State2.101 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_hgau'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item108 : name='partid_hgau'
                        stateShowUrlToRetrieveParam = 2.102;
                    }
                    break;
                case 2.102: //State2.102 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_hgad'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item109 : name='partid_hgad'
                        stateShowUrlToRetrieveParam = 2.103;
                    }
                    break;
                case 2.103: //State2.103 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_sldu'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item110 : name='partid_sldu'
                        stateShowUrlToRetrieveParam = 2.104;
                    }
                    break;
                case 2.104: //State2.104 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='partid_sldd'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item111 : name='partid_sldd'
                        stateShowUrlToRetrieveParam = 2.105;
                    }
                    break;
                case 2.105: //State2.105 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='lineid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item112 : name='lineid'
                        stateShowUrlToRetrieveParam = 2.106;
                    }
                    break;
                case 2.106: //State2.106 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='lineid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item113 : name='lineid'
                        stateShowUrlToRetrieveParam = 2.107;
                    }
                    break;
                case 2.107: //State2.107 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='lineid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item114 : name='lineid'
                        stateShowUrlToRetrieveParam = 2.108;
                    }
                    break;
                case 2.108: //State2.108 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='teamid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item115 : name='teamid'
                        stateShowUrlToRetrieveParam = 2.109;
                    }
                    break;
                case 2.109: //State2.109 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='teamid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item116 : name='teamid'
                        stateShowUrlToRetrieveParam = 2.111;
                    }
                    break;
                case 2.111: //State2.111 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='teamid'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item117 : name='teamid'
                        stateShowUrlToRetrieveParam = 2.112;
                    }
                    break;
                case 2.112: //State2.112 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='cycle'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item118 : name='cycle'
                        stateShowUrlToRetrieveParam = 2.113;
                    }
                    break;
                case 2.113: //State2.113 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='disposition'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item119 : name='disposition'
                        stateShowUrlToRetrieveParam = 2.114;
                    }
                    break;
                case 2.114: //State2.114 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='disposition'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item120 : name='disposition'
                        stateShowUrlToRetrieveParam = 2.115;
                    }
                    break;
                case 2.115: //State2.115 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='disposition'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item121 : name='disposition'
                        stateShowUrlToRetrieveParam = 2.116;
                    }
                    break;
                case 2.116: //State2.116 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='disposition'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item122 : name='disposition'
                        stateShowUrlToRetrieveParam = 2.117;
                    }
                    break;
                case 2.117: //State2.117 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key1'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item123 : name='key1'>
                        stateShowUrlToRetrieveParam = 2.118;
                    }
                    break;
                case 2.118: //State2.118 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='diskpn'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item124 : value='diskpn'
                        stateShowUrlToRetrieveParam = 2.119;
                    }
                    break;
                case 2.119: //State2.119 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key1val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item125 : name='key1val'
                        stateShowUrlToRetrieveParam = 2.121;
                    }
                    break;
                case 2.121: //State2.121 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key1val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item126 : name='key1val'
                        stateShowUrlToRetrieveParam = 2.122;
                    }
                    break;
                case 2.122: //State2.122 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key1val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item127 : name='key1val'
                        stateShowUrlToRetrieveParam = 2.123;
                    }
                    break;
                case 2.123: //State2.123 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key1val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item128 : name='key1val'
                        stateShowUrlToRetrieveParam = 2.124;
                    }
                    break;
                case 2.124: //State2.124 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key2'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item129 : name='key2'>
                        stateShowUrlToRetrieveParam = 2.125;
                    }
                    break;
                case 2.125: //State2.125 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='hsapn'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item130 : value='hsapn'
                        stateShowUrlToRetrieveParam = 2.126;
                    }
                    break;
                case 2.126: //State2.126 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key2val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item131 : name='key2val'
                        stateShowUrlToRetrieveParam = 2.127;
                    }
                    break;
                case 2.127: //State2.127 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key2val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item132 : name='key2val'
                        stateShowUrlToRetrieveParam = 2.128;
                    }
                    break;
                case 2.128: //State2.128 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key2val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item133 : name='key2val'
                        stateShowUrlToRetrieveParam = 2.129;
                    }
                    break;
                case 2.129: //State2.129 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key2val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item134 : name='key2val'
                        stateShowUrlToRetrieveParam = 2.131;
                    }
                    break;
                case 2.131: //State2.131 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key3'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item135 : name='key3'>
                        stateShowUrlToRetrieveParam = 2.132;
                    }
                    break;
                case 2.132: //State2.132 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='hgapn'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item136 : value='hgapn'
                        stateShowUrlToRetrieveParam = 2.133;
                    }
                    break;
                case 2.133: //State2.133 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key3val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item137 : name='key3val'
                        stateShowUrlToRetrieveParam = 2.134;
                    }
                    break;
                case 2.134: //State2.134 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key3val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item138 : name='key3val'
                        stateShowUrlToRetrieveParam = 2.135;
                    }
                    break;
                case 2.135: //State2.135 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key3val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item139 : name='key3val'
                        stateShowUrlToRetrieveParam = 2.136;
                    }
                    break;
                case 2.136: //State2.136 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key3val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item140 : name='key3val'
                        stateShowUrlToRetrieveParam = 2.137;
                    }
                    break;
                case 2.137: //State2.137 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key4'>", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item141 : name='key4'>
                        stateShowUrlToRetrieveParam = 2.138;
                    }
                    break;
                case 2.138: //State2.138 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("value='sliderec'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item142 : value='sliderec'
                        stateShowUrlToRetrieveParam = 2.139;
                    }
                    break;
                case 2.139: //State2.139 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key4val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item143 : name='key4val'
                        stateShowUrlToRetrieveParam = 2.141;
                    }
                    break;
                case 2.141: //State2.141 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key4val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item144 : name='key4val'
                        stateShowUrlToRetrieveParam = 2.142;
                    }
                    break;
                case 2.142: //State2.142 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key4val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item145 : name='key4val'
                        stateShowUrlToRetrieveParam = 2.143;
                    }
                    break;
                case 2.143: //State2.143 : Show URL to RetrieveParam(Continue)
                    if (find_WordIndex("name='key4val'", (indexRunning + 1)))
                    {
                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item146 : name='key4val'
                        stateShowUrlToRetrieveParam = 3;
                    }
                    break;


                case 3: //State3 : Show URL to RetrieveParam(Continue)
                    textBoxUrlToRetrieveParam.Text = urlToRetrieveParam;
                    stateShowUrlToRetrieveParam = 10;
                    break;
                case 10: //State10 : Clear Variable
                    statusShowUrlToRetrieveParam = true;
                    stateShowUrlToRetrieveParam = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlToRetrieveParam;
        }
        //##### End : show_UrlToRetrieveParam

        //##### Begin : show_UrlToGetCsvData
        private bool show_UrlToGetCsvData()
        {
            switch (stateShow_UrlToGetCsvData)
            {
                case 0: //Initial Variable
                    statusShow_UrlToGetCsvData = false;
                    urlToGetCsvData = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";
                    indexRunning = 0;
                    indexParam1800Head = 0;
                    indexParam1800Unit = 0;
                    indexParam1800HeadValue = 0;
                    indexParam1800UnitValue = 0;
                    stateShow_UrlToGetCsvData = 1;
                    break;
                case 1: //State1 : Show URL to GetCsvData
                    if (find_WordIndex("name='action'", indexRunning))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item1 : name='action'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item2 : value='retrieveParam'><div
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.1;
                    }
                    break;
                case 1.1: //State1.1 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='id'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item3 : name='id'>
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item4 : value='1596113827884'><input
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.2;
                    }
                    break;
                case 1.2: //State1.2 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='location'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item5 : name='location'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item6 : value='0'><input
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.3;
                    }
                    break;
                case 1.3: //State1.3 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='baseprocess'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item7 : name='baseprocess'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item8 : value='1800'><input
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.4;
                    }
                    break;
                case 1.4: //State1.4 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='mtype'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item9 : name='mtype'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "25" + "&"; //Item10 : value='PCM%'><table     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.5;
                    }
                    break;
                case 1.5: //State1.5 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='device'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item11 : name='device'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item12 : value='web'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.6;
                    }
                    break;
                case 1.6: //State1.6 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='format'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item13 : name='format'
                        stateShow_UrlToGetCsvData = 1.7;
                    }
                    break;
                case 1.7: //State1.7 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("value='csv'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item14 : value='csv'
                        stateShow_UrlToGetCsvData = 1.8;
                    }
                    break;
                case 1.8: //State1.8 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='samplerate_pass'><option", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item15 : name='samplerate_pass'><option
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item16 : value='100'>100</option><option     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.9;
                    }
                    break;
                case 1.9: //State1.9 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='samplerate_fail'><option", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item17 : name='samplerate_fail'><option
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item18 : value='100'>100</option><option     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.11;
                    }
                    break;
                case 1.11: //State1.11 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='maxcount_pass'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item19 : name='maxcount_pass'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item20 : value='xxx'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.12;
                    }
                    break;
                case 1.12: //State1.12 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='foundcount_pass'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item21 : name='foundcount_pass'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item22 : value='xxx'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.13;
                    }
                    break;
                case 1.13: //State1.13 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='maxcount_fail'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item23 : name='maxcount_fail'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item24 : value='xxx'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.14;
                    }
                    break;
                case 1.14: //State1.14 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='foundcount_fail'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item25 : name='foundcount_fail'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item26 : value='xxx'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.15;
                    }
                    break;
                case 1.15: //State1.15 : Show URL to GetCsvData(Continue)
                    if (find_WordIndex("name='process'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item27 : name='process'
                        urlToGetCsvData += split_Text(wordWebCodeResponse[indexRunning + 1]) + "&"; //Item28 : value='1800'     
                        indexRunning += 1; // Update value
                        stateShow_UrlToGetCsvData = 1.16;
                    }
                    break;
                case 1.16: //State1.16 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item29 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.17;
                    }
                    break;
                case 1.17: //State1.17 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='1:MR_RES:4:0'>1", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item30 : value='1:MR_RES:4:0'>1
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.18;
                    }
                    break;

                case 1.18: //State1.18 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item31 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.19;
                    }
                    break;
                case 1.19: //State1.19 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='2:READV:4:0'>2", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item32 : value='2:READV:4:0'>2
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.21;
                    }
                    break;
                case 1.21: //State1.21 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item33 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.22;
                    }
                    break;
                case 1.22: //State1.22 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='3:MR_RES2:4:0'>3", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item34 : value='3:MR_RES2:4:0'>3
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.23;
                    }
                    break;
                case 1.23: //State1.23 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item35 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.24;
                    }
                    break;
                case 1.24: //State1.24 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='4:READV2:4:0'>4", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item36 : value='4:READV2:4:0'>4
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.25;
                    }
                    break;
                case 1.25: //State1.25 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item37 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.26;
                    }
                    break;
                case 1.26: //State1.26 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='5:TFC_RES:4:0'>5", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item38 : value='5:TFC_RES:4:0'>5
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.27;
                    }
                    break;
                case 1.27: //State1.27 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item39 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.28;
                    }
                    break;
                case 1.28: //State1.28 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='6:ECS_RES:4:0'>6", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item40 : value='6:ECS_RES:4:0'>6
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.29;
                    }
                    break;
                case 1.29: //State1.29 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item41 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.31;
                    }
                    break;
                case 1.31: //State1.31 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='7:PMR_PLS_RES:4:0'>7", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item42 : value='7:PMR_PLS_RES:4:0'>7
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.32;
                    }
                    break;
                case 1.32: //State1.32 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_head'", indexParam1800Head))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item43 : name='param_1800_head'
                        indexParam1800Head = indexRunning; // Assign indexParam1800Head = indexRunning
                        stateShow_UrlToGetCsvData = 1.33;
                    }
                    break;
                case 1.33: //State1.33 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='8:WR_RES:4:0'>8", (indexParam1800HeadValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item44 : value='8:WR_RES:4:0'>8
                        indexParam1800HeadValue = indexRunning; // Assign indexParam1800HeadValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.34;
                    }
                    break;

                case 1.34: //State1.34 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_unit'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item45 : name='param_1800_unit'
                        indexParam1800Unit = indexRunning; // Assign indexParam1800Unit = indexRunning
                        stateShow_UrlToGetCsvData = 1.35;
                    }
                    break;
                case 1.35: //State1.35 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='1:VCM_RES:4:0'>1", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item46 : value='1:VCM_RES:4:0'>1
                        indexParam1800UnitValue = indexRunning; // Assign indexParam1800UnitValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.36;
                    }
                    break;
                case 1.36: //State1.36 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_unit'", indexParam1800Unit))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item47 : name='param_1800_unit'
                        indexParam1800Unit = indexRunning; // Assign indexParam1800Unit = indexRunning
                        stateShow_UrlToGetCsvData = 1.37;
                    }
                    break;
                case 1.37: //State1.37 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='2:PIEZO:4:0'>2", (indexParam1800UnitValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item48 : value='2:PIEZO:4:0'>2
                        indexParam1800UnitValue = indexRunning; // Assign indexParam1800UnitValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.38;
                    }
                    break;
                case 1.38: //State1.38 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_unit'", indexParam1800Unit))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item49 : name='param_1800_unit'
                        indexParam1800Unit = indexRunning; // Assign indexParam1800Unit = indexRunning
                        stateShow_UrlToGetCsvData = 1.39;
                    }
                    break;
                case 1.39: //State1.39 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='3:HMA_PLS:4:0'>3", (indexParam1800UnitValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item50 : value='3:HMA_PLS:4:0'>3
                        indexParam1800UnitValue = indexRunning; // Assign indexParam1800UnitValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.41;
                    }
                    break;
                case 1.41: //State1.41 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='param_1800_unit'", indexParam1800Unit))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "="; //Item51 : name='param_1800_unit'
                        indexParam1800Unit = indexRunning; // Assign indexParam1800Unit = indexRunning
                        stateShow_UrlToGetCsvData = 1.42;
                    }
                    break;
                case 1.42: //State1.42 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("value='4:HMA_MNS:4:0'>4", (indexParam1800UnitValue + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "&"; //Item52 : value='4:HMA_MNS:4:0'>4
                        indexParam1800UnitValue = indexRunning; // Assign indexParam1800UnitValue = indexRunning
                        stateShow_UrlToGetCsvData = 1.43;
                    }
                    break;
                case 1.43: //State1.43 : Show URL to GetCsvData(Continue) ###Special
                    if (find_WordIndex("name='add_prior'", (indexRunning + 1)))
                    {
                        urlToGetCsvData += split_Text(wordRunning) + "=" + "on"; //Item53 : name='add_prior'
                        stateShow_UrlToGetCsvData = 3;
                    }
                    break;

                case 3: //State3 : Show URL to GetCsvData(Continue)
                    textBoxUrlToGetCsvData.Text = urlToGetCsvData;
                    stateShow_UrlToGetCsvData = 10;
                    break;
                case 10: //Clear Variables
                    statusShow_UrlToGetCsvData = true;
                    stateShow_UrlToGetCsvData = 0;
                    break;
                default:
                    break;
                    
            }
            return statusShow_UrlToGetCsvData;
        }
        //##### End : show_UrlToGetCsvData

        //##### Begin : download_CsvData
        private void download_CsvData()  
        {
            if(switchDownloadCsvData) 
            {
                switch(stateDownloadCsvData)
                {
                    case 0: //State0 : Initial Variables 
                        statusWebBrowser1DocumentCompleted = false;

                        indexCsvDataRow = 0; 
                        indexCsvDataColumn = 0;

                        stateDownloadCsvData = 1;
                        tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor
                        break;
                    case 1: //State1 : Initial Entering Web VnusQ by Logoff
                        if(go_Url("http://dwhweb.prb.hgst.com/dwh/logoff.jsp"))
                        {
                            stateDownloadCsvData = 2;
                        }
                        break;
                    case 2: //State2 : Go URL, Index Page
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/index.jsp"))
                        {
                            stateDownloadCsvData = 3;
                        }
                        break;
                    case 3: //State3 : Go URL, Login Page
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/login"))
                        {
                            stateDownloadCsvData = 4;
                        }
                        break;
                    case 4: //State4 : Go URL, Entering Loging by Send Login UserName + Password
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On"))
                        {
                            stateDownloadCsvData = 5;
                        }
                        break;
                    case 5: //State5 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvData = 6;
                        }
                        break;
                    case 6: //State6 : Show URL to RetrieveProcess
                        if (show_UrlToRetrieveProcess())
                        {
                            stateDownloadCsvData = 7;
                        }
                        break;
                    case 7: //State7 : Go RetrieveProcess Page
                        if (go_Url("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56)))
                        {
                            stateDownloadCsvData = 8;
                        }
                        break;
                    case 8: //State8 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvData = 9;
                        }
                        break;
                    case 9: //State9 : Show URL to RetrieveParam
                        if (show_UrlToRetrieveParam())
                        {
                            stateDownloadCsvData = 10;
                        }
                        break;
                    case 10: //State10 : Go RetrieveParam Page
                        if(go_Url(urlToRetrieveParam))
                        {
                            stateDownloadCsvData = 11;
                        }
                        break;
                    case 11: //State11 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvData = 12;
                        }
                        break;
                    case 12: //State12 : Show URL to get csv data
                        if (show_UrlToGetCsvData())
                        {
                            stateDownloadCsvData = 13;
                        }
                        break;
                    case 13: //State13 : Go csv Page
                        if (go_Url(urlToGetCsvData))
                        {
                            stateDownloadCsvData = 14;
                        }
                        break;
                    case 14: //State14 : Convert CSV Data from web to dataGridView2
                        textBoxCsvData.Text = webBrowser1.Document.Body.InnerText;

                        dataTable2.Clear(); //Clear datatable of CSV Data
                        dataTable2.Columns.Clear(); //Clear Columns of datatable CSV Data
                        dataTable2.Rows.Clear(); //Clear Rows of datatable CSV Data

                        wordCsvDataRow = textBoxCsvData.Text.Split('\n'); //Split Row by new line(\n)

                        indexCsvDataRow = 0; //Initial indexCsvDataRow
                        indexCsvDataColumn = 0; //Initial indexCsvDataColumn

                        dataTable2.Columns.Add("Column" + indexCsvDataColumn);

                        wordCsvDataColumn = wordCsvDataRow[0].Split(','); //Split Column of Row0 by comma(,)

                        foreach (var dataColumn in wordCsvDataColumn) //Add Other 42 Columns of CSV Header
                        {
                            indexCsvDataColumn++;
                            dataTable2.Columns.Add("Column"+ indexCsvDataColumn);
                            
                            textBoxLastIndexOfCsvDataColumn.Text = indexCsvDataColumn.ToString();
                        }

                        foreach (var dataRow in wordCsvDataRow)
                        {
                            wordCsvDataColumn = dataRow.Split(',');

                            dataTable2.Rows.Add(indexCsvDataRow, wordCsvDataColumn[0], wordCsvDataColumn[1], wordCsvDataColumn[2], wordCsvDataColumn[3],
                                                                       wordCsvDataColumn[4], wordCsvDataColumn[5], wordCsvDataColumn[6], wordCsvDataColumn[7],
                                                                       wordCsvDataColumn[8], wordCsvDataColumn[9], wordCsvDataColumn[10], wordCsvDataColumn[11],
                                                                       wordCsvDataColumn[12], wordCsvDataColumn[13], wordCsvDataColumn[14], wordCsvDataColumn[15],
                                                                       wordCsvDataColumn[16], wordCsvDataColumn[17], wordCsvDataColumn[18], wordCsvDataColumn[19],
                                                                       wordCsvDataColumn[20], wordCsvDataColumn[21], wordCsvDataColumn[22], wordCsvDataColumn[23],
                                                                       wordCsvDataColumn[24], wordCsvDataColumn[25], wordCsvDataColumn[26], wordCsvDataColumn[27],
                                                                       wordCsvDataColumn[28], wordCsvDataColumn[29], wordCsvDataColumn[30], wordCsvDataColumn[31],
                                                                       wordCsvDataColumn[32], wordCsvDataColumn[33], wordCsvDataColumn[34], wordCsvDataColumn[35],
                                                                       wordCsvDataColumn[36], wordCsvDataColumn[37], wordCsvDataColumn[38], wordCsvDataColumn[39],
                                                                       wordCsvDataColumn[40], wordCsvDataColumn[41]);

                            textBoxLastIndexOfCsvDataRow.Text = indexCsvDataRow.ToString();

                            indexCsvDataRow++;
                        }

                        dataGridView2.DataSource = dataTable2;

                        stateDownloadCsvData = 100;
                        break;
                    case 100: //State100 : End This Function and Resetting variables
                        switchDisplayData = true; //Enable Function display_Data()
                        switchDownloadCsvData = false;
                        stateDownloadCsvData = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : download_CsvData

        //##### Begin : display_Data
        private void display_Data()
        {
            if (switchDisplayData)
            {
                switch (stateDisplayData)
                {
                    case 0: //Initial Variable
                        errorCodeTotal = indexCsvDataRow; //Initial Count Total Error Code
                        errorCodePass = 0; //Initial Count Pass Error Code
                        errorCodeFail = 0; //Initial Count Fail Error Code
                        //countErrorCodeLoop = 0;

                        dataTable3.Clear(); //Clear datatable of Display Data
                        dataTable3.Columns.Clear(); //Clear Columns of Display CSV Data
                        dataTable3.Rows.Clear(); //Clear Rows of Display CSV Data
                        dataTable3.Columns.Add("Item"); //Add 1st Column
                        dataTable3.Columns.Add("ErrorCode"); //Add 2nd Column

                        dataTable4.Clear(); //Clear datatable of ErrorCodeCount
                        dataTable4.Columns.Clear(); //Clear Column of ErrorCodeCount
                        dataTable4.Rows.Clear(); //Clear Rows of ErrorCodeCount
                        dataTable4.Columns.Add("ErrorCodeNumber"); //Add 1st Column
                        dataTable4.Columns.Add("Q'ty"); //Add 2nd Column
                        dataTable4.Columns.Add("%"); //Add 3rn Column



                        tabControl1.SelectedTab = tabPage0; //Open tabPage0 to Display data
                        subStateDisplayData1 = 0;
                        stateDisplayData = 1;
                        break;
                    case 1: //State1 : Count ErrorCode in Column "PFCD", Total and Pass and Fail = ? and Identigy ErrorCode into dataGridView3
                        for(int i = 1; i < errorCodeTotal; i++)
                        {
                            //if(dataGridView2[7,i].Value.ToString() == "0000") //Column : "PFCD"
                            if(dataGridView2.Rows[i].Cells[7].Value.ToString() == "0000") //Column : "PFCD" ***** Test New Code
                            {
                                errorCodePass++;
                            }
                            else
                            {
                                //dataTable3.Rows.Add(i, dataGridView2[7, i].Value.ToString()); //Add Idex of ErrorCode and ErrorCode into dataTable3
                                dataTable3.Rows.Add(i, dataGridView2.Rows[i].Cells[7].Value.ToString()); //Add Idex of ErrorCode and ErrorCode into dataTable3 ***** Test New Code
                                errorCodeFail++;
                            }
                        }
                        textBoxErorCodeTotal.Text = errorCodeTotal.ToString();
                        textBoxErorCodePass.Text = errorCodePass.ToString();
                        textBoxErorCodeFail.Text = errorCodeFail.ToString();
                        dataGridView3.DataSource = dataTable3; //Dump dataTable3 after added all ErrorCode into dataGridView3 to Analyze
                        stateDisplayData = 2;
                        break;
                    case 2: //State2 : Count Q'ty and % of ErrorCode in dataTable3 
                        
                        foreach (DataGridViewRow checkCode in dataGridView3.Rows)
                        {
                            errorCodeInColumn += checkCode.Cells["ErrorCode"].Value + " ";
                            //errorCodeInColumn += checkCode.Cells["ErrorCode"].Value;
                        }
                        textBoxCheckErrorCode.Text = errorCodeInColumn;
                        
                        stateDisplayData = 3;
                        break;
                    case 3: //State3 : Count Q'ty and % of ErrorCode in dataTable3 Continue
                        index = 0; //Prepare to count ErrorCode1
                        errorCode = errorCodeInColumn.Split(' ');
                        stateDisplayData = 4;
                        break;
                    case 4: //State4 : Count Q'ty and % of ErrorCode in dataTable3 Continue
                        //errorCodeFilter = errorCode[0]+" "; //Put 1st ErrorCode to errorCodeFilter
                        dataTable4.Rows.Add(errorCode[0], "NotCount!", "NotReady!");
                        errorCodeCheck = errorCode[0];
                        //index++;
                        stateDisplayData = 5;
                        break;
                    case 5: //State5 : Count Q'ty and % of ErrorCode in dataTable3 Continue
                        foreach (string checkWord in errorCode)
                        {
                            if(checkWord != errorCodeCheck) //Checking Difference ErrorCode
                            {
                                dataTable4.Rows.Add(checkWord, "NotCount", "NotReady!");
                                errorCodeCheck = checkWord;
                            }
                            //index++;
                        }
                        stateDisplayData = 6;
                        break;
                    case 6: //State6 : Count Q'ty and % of ErrorCode in dataTable3 Continue
                        dataGridView4.DataSource = dataTable4; //Assign dataGridView4.DataSource = dataTable4
                        stateDisplayData = 100;
                        break;
                    case 100: //State100:
                        switchDisplayData = false;
                        subStateDisplayData1 = 0;
                        stateDisplayData = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : display_Data

        //##### End : My function Area #####

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable1.Columns.Add("INDEX");
            dataTable1.Columns.Add("WORD");
            switchDownloadCsvData = true; //Start function : download_CsvData()
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            switchDownloadCsvData = true; //Start function : download_CsvData()
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
            download_CsvData(); //Auto download CSV File
            display_Data(); //Auto display Data
            textBoxStateDownloadCsvData.Text = stateDownloadCsvData.ToString();
            textBoxStateDisplayData.Text = stateDisplayData.ToString();
        }


        private void buttonCheckDataInDataGridView2_Click(object sender, EventArgs e)
        {
            textBoxDataGridView2Value.Text = dataGridView2[int.Parse(textBoxDataGridView2Column.Text), int.Parse(textBoxDataGridView2Row.Text)].Value.ToString();
        }

    }
}

