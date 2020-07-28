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
        int indexWordWebCodeResponse = 0; //Index of string array, wordWebCodeResponse

        bool statusWebBrowser1DocumentCompleted = false; //Decare for check when webBrowser1_DocumentCompleted
        bool statusDelay = false; //Check Function delay_State is done?
        bool statusAddWordInRowTable = false; //Check Function addword_InRowTable is done?
        bool statusFindWordIndex = false; //Check Function find_WordIndex is done?
        bool statusGoUrl = false; //Check Function go_Url is done?
        bool statusShowUrlToRetrieveProcess = false; //Check Function show_UrlToRetrieveProcess
        bool statusShowUrlToRetrieveParam = false; //Check Function show_UrlToRetrieveParam

        byte stateDelay = 0; //Initial State of Function delay at state0
        byte stateAddWordInRowTable = 0; //Initial State of Function addword_InRowTable
        byte stateFindWordIndex = 0; //Initial State of Function find_WordIndex
        byte stateGoUrl = 0; //Initial State of Function go_Url
        byte stateShowUrlToRetrieveProcess = 0; //Initial State of Function show_UrlToRetrieveProcess
        double stateShowUrlToRetrieveParam = 0; //Initial State of Function show_UrlToRetrieveParam

        string[] wordSplit; //Decare String array to use in Function split_Text()
        string urlToRetrieveParam = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?"; //Initial urlToRetrieveParam
        string wordTarget = ""; //Initial to use with Function fine_Word()

        string wordRunning = ""; //Initial to use in Function find_WordIndex
        int indexRunning = 0; //Initial to use in Function find_WordIndex
        double testShow = 10.0;
        int test = 0;
        bool switchStepRun = false; //Decare to test function by STEP Run
        bool switchDownloadCsvFile = false; //Decare for ON function download_CsvFile
        bool switchSaveCsvFile = false; //Decare for ON function save_CsvFile
        bool switchReadCsvFile = false; //Decare for ON function read_CsvFile
        bool switchSearchDataInCsvFile = false; //Decare for ON function search_DataInCsvFile

        double stateDownloadCsvFile = 0; //Initial State of Function download_CsvFile at state0
        double stateSaveCsvFile = 0; //Initial State of Function save_CsvFile at state0



        DataTable datatableWordWebCodeResponse = new DataTable(); //Decare to use Class DataTable to help checking
        AutoHand autoHand = new AutoHand();//Decare to use DLL File of AutoItX3
        //Point point = new Point(0, 0); //Decare point x=0, y=0
        Point point = new Point(0, 0); //Decare point x=0, y=0
        WebClient webClient1 = new WebClient();
        
        

        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
            timerStateCyclic.Enabled = true;
            //textBox3.Text = testShow.ToString();
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
                    datatableWordWebCodeResponse.Clear();
                    stateAddWordInRowTable = 6;
                    break;
                case 6: //State6 : Initial indexWordWebCodeResponse = 0
                    indexWordWebCodeResponse = 0;
                    stateAddWordInRowTable = 7;
                    break;
                case 7: //State7 : Looping until last word in String Array wordWebCodeResponse
                    foreach (var word in wordWebCodeResponse)
                    {
                        datatableWordWebCodeResponse.Rows.Add(indexWordWebCodeResponse.ToString(), wordWebCodeResponse[indexWordWebCodeResponse]); //Add Data to new Row in Table
                        indexWordWebCodeResponse++;
                    }
                    stateAddWordInRowTable = 8;
                    break;
                case 8: //State8 : Input dataGridView1 by datatableWordWebCodeResponse to show in Table
                    dataGridView1.DataSource = datatableWordWebCodeResponse;
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
            if(textInput == wordWebCodeResponse[2576]) // For only Item8, Index[2576] : <option>PCM-ALL</option>
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
        private bool find_WordIndex(string wordToCompare, int indexInitial)
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
                    stateShowUrlToRetrieveParam = 1;
                    //stateShowUrlToRetrieveParam = 3;
                    int indexWord = 0;
                    break;
                case 1: //State1 : Show URL to RetrieveParam
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1031]) + "="; //Item1 : name='action'
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1032]) + "&"; //Item2 : value='retrieveProcess'><div
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1145]) + "="; //Item3 : name='location'>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1147]) + "&"; //Item4 : value='0'>PRB</option>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1154]) + "="; //Item5 : name='mtype'
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1507]) + "25" + "&"; //Item6 : value='PCM%'>PCM%</option>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1626]) + "="; //Item7 : name='modelid'>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2576]) + "&"; //Item8 : <option>PCM-ALL</option>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2927]) + "="; //Item9 : name='datekey'
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2928]) + "&"; //Item10 : value='test'
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2983]) + "="; //Item11 : name='enddate0'>
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2985]) + "&"; //Item12 : value='20200728'>2020-07-28
                    stateShowUrlToRetrieveParam = 2;
                    break;
                case 2: //State2 : Show URL to RetrieveParam(Continue)
                    if(find_WordIndex("name='endtime0'", 2986)) 
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
                        urlToRetrieveParam += split_Text(wordWebCodeResponse[indexRunning + 3]) + "&"; //Item16 : value='20200728'>2020-07-28
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
                        stateShowUrlToRetrieveParam = 3;
                    }
                    break;
                //case 2.7: //State2.7 : 
                //  urlToRetrieveParam += split_Text(wordWebCodeResponse[4173]) + "="; //Item23
                //stateShowUrlToRetrieveParam = 3;
                //break;
                /*
                                case 2.7: //State2.7 : Show URL to RetrieveParam(Continue)
                                    if (find_WordIndex("name='process'>", (indexRunning + 1)))
                                    {
                                        urlToRetrieveParam += split_Text(wordRunning) + "="; //Item23
                                        stateShowUrlToRetrieveParam = 3;
                                    }
                                    break;

                        case 2.8: //State2.8 : Show URL to RetrieveParam(Continue)
                            if (find_WordIndex("value='1800'>1800:", (indexRunning + 1)))
                            {
                                urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item24
                                stateShowUrlToRetrieveParam = 3;
                            }
                            break;
                        /*
                    case 2.6: //State2.6 : Show URL to RetrieveParam(Continue)
                        if (find_WordIndex("name='process'>", (indexRunning + 2)))
                        {
                            urlToRetrieveParam += split_Text(wordRunning) + "="; //Item23
                            stateShowUrlToRetrieveParam = 2.7;
                        }
                        break;
                    case 2.7: //State2.7 : Show URL to RetrieveParam(Continue)
                        if (find_WordIndex("value='1800'>1800:>", (indexRunning + 1)))
                        {
                            urlToRetrieveParam += split_Text(wordRunning) + "&"; //Item24
                            stateShowUrlToRetrieveParam = 2.8;
                        }
                        break;
                    case 2.8: //State2.8 : Show URL to RetrieveParam(Continue)
                        if (find_WordIndex("name='snlist'", (indexRunning + 1)))
                        {
                            urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item25
                            stateShowUrlToRetrieveParam = 2.9;
                        }
                        break;
                    case 2.9: //State2.9 : Show URL to RetrieveParam(Continue)
                        if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                        {
                            urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item26
                            stateShowUrlToRetrieveParam = 2.11; //Double must use 2.11 than 2.10
                        }
                        break;
                    case 2.11: //State2.11 : Show URL to RetrieveParam(Continue)
                        if (find_WordIndex("name='pfcode'", (indexRunning + 1)))
                        {
                            urlToRetrieveParam += split_Text(wordRunning) + "=" + "&"; //Item27
                            stateShowUrlToRetrieveParam = 3;
                        }
                        break;
                        */


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


        //##### Begin : download_CsvFile
        private void download_CsvFile()  
        {
            if(switchDownloadCsvFile) 
            {
                switch(stateDownloadCsvFile)
                {
                    case 0: //State0 : Initial Variables 
                        statusWebBrowser1DocumentCompleted = false;
                        stateDownloadCsvFile = 1;
                        tabControl1.SelectedTab = tabPage2; //Open tabPage2 to monitor
                        break;
                    case 1: //State1 : Initial Entering Web VnusQ by Logoff
                        if(go_Url("http://dwhweb.prb.hgst.com/dwh/logoff.jsp"))
                        {
                            stateDownloadCsvFile = 2;
                        }
                        break;
                    case 2: //State2 : Go URL, Index Page
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/index.jsp"))
                        {
                            stateDownloadCsvFile = 3;
                        }
                        break;
                    case 3: //State3 : Go URL, Login Page
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/login"))
                        {
                            stateDownloadCsvFile = 4;
                        }
                        break;
                    case 4: //State4 : Go URL, Entering Loging by Send Login UserName + Password
                        if (go_Url("http://dwhweb.prb.hgst.com/dwh/login.jsp/j_security_check?j_username=woravit&j_password=123456&Logon=Log%20On"))
                        {
                            stateDownloadCsvFile = 5;
                        }
                        break;
                    case 5: //State5 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvFile = 6;
                        }
                        break;
                    case 6: //State6 : Show URL to RetrieveProcess
                        if (show_UrlToRetrieveProcess())
                        {
                            stateDownloadCsvFile = 7;
                        }
                        break;
                    case 7: //State7 : Go RetrieveProcess Page
                        if (go_Url("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56)))
                        {
                            stateDownloadCsvFile = 8;
                        }
                        break;
                    case 8: //State8 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvFile = 9;
                        }
                        break;
                    case 9: //State9 : Show URL to RetrieveParam
                        if (show_UrlToRetrieveParam())
                        {
                            //stateDownloadCsvFile = 10;
                            stateDownloadCsvFile = 100;
                        }
                        break;
                    case 10: //State10 : Go RetrieveParam Page
                        if(go_Url(urlToRetrieveParam))
                        {
                            stateDownloadCsvFile = 11;
                        }
                        break;
                    case 11: //State11 : Show WebCode Response String from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvFile = 100;
                        }
                        break;
                    case 100: //State100 : End This Function and Resetting variables
                        switchDownloadCsvFile = false;
                        stateDownloadCsvFile = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : download_CsvFile

        //##### Begin : save_CsvFile
        private void save_CsvFile()
        {
            if (switchSaveCsvFile)
            {
                switch (stateSaveCsvFile)
                {
                    case 0: //Initial Variables
                        statusWebBrowser1DocumentCompleted = false;
                        stateSaveCsvFile = 1;//Temp
                        break;
                    case 1:// State1 : Delay a little bit
                        if (delay_State(1000))
                        {
                            stateSaveCsvFile = 2;
                        }
                        break;
                    case 2:// State2 : Auto mouse move to click Save Button
                        autoHand.mouseMoveAndClick("LEFT", 1014, 546, 1, 1); //Move to Click at Save Button
                        stateSaveCsvFile = 3;
                        break;
                    case 3:// State3 : Delay a little bit
                        if (delay_State(1000))
                        {
                            stateSaveCsvFile = 4;
                        }
                        break;
                    case 4:// State4 : Click at path
                        autoHand.mouseMoveAndClick("LEFT", 1055, 274, 1, 1); //Move to Click at Path to save
                        stateSaveCsvFile = 100;
                        break;
                    case 100:// State End
                        switchSaveCsvFile = false;
                        stateSaveCsvFile = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : save_CsvFile

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
            //save_CsvFile(); //Auto save CSV File
            textBox2.Text = stateDownloadCsvFile.ToString();
            textBoxStateDownloadCsvFile.Text = stateDownloadCsvFile.ToString();
            textBoxStateSaveCsvFile.Text = stateSaveCsvFile.ToString();
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
 *                  
 *                  case 25: //State25 : Set Window to Maximize
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
                        if (delay_State(2000))
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
                        if (delay_State(1000))
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
                        if (delay_State(500))
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
                        if (delay_State(500))
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


    // Before Create function : addword_InRowTable()

    case 0.1: //State0.1 : Initial Entering Web VnusQ by Logoff
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/logoff.jsp");
                        stateDownloadCsvFile = 0.2;
                        break;
                    case 0.2: //State0.2 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 0.3;
                        }
                        break;
                    case 0.3: //State0.3 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 1;
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




    case 25: //State25 : Test RetrieveProcess
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?action=retrieveProcess&location=0&mtype=PCM%25&modelid=PCM-ALL&datekey=test&enddate0=20200720&endtime0=000000&enddate1=20200720&endtime1=235959&scanmode=all&scanmodesub=found&process=1800&snlist=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&pfcode=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hddtrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&hsatrial=&locid=&locid=&locid=&locid=&mfgid=&mfgid=&mfgid=&mfgid=&mfgid=&mfgid=&testerid=&testerid=&testerid=&testerid=&testerid=&testerid=&cellid=&cellid=&cellid=&cellid=&cellid=&cellid=&testertype=&testertype=&testertype=&testertype=&testcode=&testcode=&testcode=&testcode=&partid_spdl=&partid_disk=&partid_hsa=&partid_card=&partid_hgau=&partid_hgad=&partid_sldu=&partid_sldd=&lineid=&lineid=&lineid=&teamid=&teamid=&teamid=&cycle=&disposition=&disposition=&disposition=&disposition=&key1=diskpn&key1val=&key1val=&key1val=&key1val=&key2=hsapn&key2val=&key2val=&key2val=&key2val=&key3=hgapn&key3val=&key3val=&key3val=&key3val=&key4=sliderec&key4val=&key4val=&key4val=&key4val=");
                        stateDownloadCsvFile = 26;
                        break;
                    case 26: //State26 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 27;
                        }
                        break;
                    case 27: //State27 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 28;
                        break;
                    case 28: //State28 : Prepare for Auto Mouse move
                        Location = point; //Assign Form1 Location = point(0, 0)
                        stateDownloadCsvFile = 100;
                        break;
                    case 29: //State29 : Test RetrieveParam
                        //Save to Disk
                        //this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?action=retrieveParam&id=1595180965397&location=0&baseprocess=1800&mtype=PCM%25&device=disk&format=csv&samplerate_pass=100&samplerate_fail=100&maxcount_pass=678&foundcount_pass=678&maxcount_fail=37&foundcount_fail=37&process=1800&param_1800_head=1%3AMR_RES%3A4%3A0&param_1800_head=2%3AREADV%3A4%3A0&param_1800_head=3%3AMR_RES2%3A4%3A0&param_1800_head=4%3AREADV2%3A4%3A0&param_1800_head=5%3ATFC_RES%3A4%3A0&param_1800_head=6%3AECS_RES%3A4%3A0&param_1800_head=7%3APMR_PLS_RES%3A4%3A0&param_1800_head=8%3AWR_RES%3A4%3A0&param_1800_unit=1%3AVCM_RES%3A4%3A0&param_1800_unit=2%3APIEZO%3A4%3A0&param_1800_unit=3%3AHMA_PLS%3A4%3A0&param_1800_unit=4%3AHMA_MNS%3A4%3A0&add_prior=on");
                        //View ON Web
                        this.webBrowser1.Navigate("http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?action=retrieveParam&id=1595180965397&location=0&baseprocess=1800&mtype=PCM%25&device=web&format=csv&samplerate_pass=100&samplerate_fail=100&maxcount_pass=678&foundcount_pass=678&maxcount_fail=37&foundcount_fail=37&process=1800&param_1800_head=1%3AMR_RES%3A4%3A0&param_1800_head=2%3AREADV%3A4%3A0&param_1800_head=3%3AMR_RES2%3A4%3A0&param_1800_head=4%3AREADV2%3A4%3A0&param_1800_head=5%3ATFC_RES%3A4%3A0&param_1800_head=6%3AECS_RES%3A4%3A0&param_1800_head=7%3APMR_PLS_RES%3A4%3A0&param_1800_head=8%3AWR_RES%3A4%3A0&param_1800_unit=1%3AVCM_RES%3A4%3A0&param_1800_unit=2%3APIEZO%3A4%3A0&param_1800_unit=3%3AHMA_PLS%3A4%3A0&param_1800_unit=4%3AHMA_MNS%3A4%3A0&add_prior=on");
                        stateDownloadCsvFile = 29.1;


                        //webClient1.DownloadFileAsync(new Uri("http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?action=retrieveParam&id=1595180965397&location=0&baseprocess=1800&mtype=PCM%25&device=disk&format=csv&samplerate_pass=100&samplerate_fail=100&maxcount_pass=678&foundcount_pass=678&maxcount_fail=37&foundcount_fail=37&process=1800&param_1800_head=1%3AMR_RES%3A4%3A0&param_1800_head=2%3AREADV%3A4%3A0&param_1800_head=3%3AMR_RES2%3A4%3A0&param_1800_head=4%3AREADV2%3A4%3A0&param_1800_head=5%3ATFC_RES%3A4%3A0&param_1800_head=6%3AECS_RES%3A4%3A0&param_1800_head=7%3APMR_PLS_RES%3A4%3A0&param_1800_head=8%3AWR_RES%3A4%3A0&param_1800_unit=1%3AVCM_RES%3A4%3A0&param_1800_unit=2%3APIEZO%3A4%3A0&param_1800_unit=3%3AHMA_PLS%3A4%3A0&param_1800_unit=4%3AHMA_MNS%3A4%3A0&add_prior=on"), @"C\param.csv");
                        //stateDownloadCsvFile = 100;

                        break;
                    case 29.1: //State29.1 : ON function SaveCsvFile
                        //switchSaveCsvFile = true;
                        stateDownloadCsvFile = 30;
                        break;
                    case 30: //State30 : After webBrowser1_DocumentCompleted, Show URL Response from Server of Index Page
                        if (statusWebBrowser1DocumentCompleted)
                        {
                            textBoxUrlResponse.Text = "" + webBrowser1.Url;
                            stateDownloadCsvFile = 31;
                        }
                        break;
                    case 31: //State31 : Show WebCode Response from Server of Index Page
                        textBoxWebCodeResponse.Text = webBrowser1.DocumentText;
                        stateDownloadCsvFile = 100;
                        break;
                    case 100: //State100 : End This Function and Resetting variables
                        switchDownloadCsvFile = false;
                        stateDownloadCsvFile = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        //##### End : download_CsvFile




    // Before Create Function find_WordIndex

    case 1: //State1 : Show URL to RetrieveParam
                        
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1037]) + "="; //Item1
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1038]) + "&"; //Item2
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1151]) + "="; //Item3
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1153]) + "&"; //Item4
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1160]) + "="; //Item5
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1513]) + "25" + "&"; //Item6
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[1632]) + "="; //Item7
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2582]) + "&"; //Item8
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2935]) + "="; //Item9
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2936]) + "&"; //Item10
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2993]) + "="; //Item11
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[2995]) + "&"; //Item12
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[3510]) + "="; //Item13
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[3511]) + "&"; //Item14
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[3517]) + "="; //Item15
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[3520]) + "&"; //Item16
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4035]) + "="; //Item17
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4036]) + "&"; //Item18
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4054]) + "="; //Item19
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4055]) + "&"; //Item20
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4080]) + "="; //Item21
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4081]) + "&"; //Item22
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4161]) + "="; //Item23
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4250]) + "&"; //Item24
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4539]) + "=" + "&"; //Item25
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4551]) + "=" + "&"; //Item26
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4556]) + "=" + "&"; //Item27
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4561]) + "=" + "&"; //Item28
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4566]) + "=" + "&"; //Item29
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4571]) + "=" + "&"; //Item30
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4576]) + "=" + "&"; //Item31
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4581]) + "=" + "&"; //Item32
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4586]) + "=" + "&"; //Item33
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4595]) + "=" + "&"; //Item34
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4600]) + "=" + "&"; //Item35
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4605]) + "=" + "&"; //Item36
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4610]) + "=" + "&"; //Item37
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4615]) + "=" + "&"; //Item38
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4620]) + "=" + "&"; //Item39
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4625]) + "=" + "&"; //Item40
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4630]) + "=" + "&"; //Item41
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4664]) + "=" + "&"; //Item42
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4669]) + "=" + "&"; //Item43
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4674]) + "=" + "&"; //Item44
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4679]) + "=" + "&"; //Item45
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4684]) + "=" + "&"; //Item46
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4689]) + "=" + "&"; //Item47
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4694]) + "=" + "&"; //Item48
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4699]) + "=" + "&"; //Item49
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4708]) + "=" + "&"; //Item50
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4713]) + "=" + "&"; //Item51
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4718]) + "=" + "&"; //Item52
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4723]) + "=" + "&"; //Item53
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4728]) + "=" + "&"; //Item54
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4733]) + "=" + "&"; //Item55
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4738]) + "=" + "&"; //Item56
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4743]) + "=" + "&"; //Item57
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4757]) + "=" + "&"; //Item58
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4762]) + "=" + "&"; //Item59
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4767]) + "=" + "&"; //Item60
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4772]) + "=" + "&"; //Item61
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4777]) + "=" + "&"; //Item62
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4782]) + "=" + "&"; //Item63
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4787]) + "=" + "&"; //Item64
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4792]) + "=" + "&"; //Item65
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4801]) + "=" + "&"; //Item66
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4806]) + "=" + "&"; //Item67
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4811]) + "=" + "&"; //Item68
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4816]) + "=" + "&"; //Item69
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4821]) + "=" + "&"; //Item70
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4826]) + "=" + "&"; //Item71
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4831]) + "=" + "&"; //Item72
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4836]) + "=" + "&"; //Item73
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4929]) + "=" + "&"; //Item74
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4940]) + "=" + "&"; //Item75
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4947]) + "=" + "&"; //Item76
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4954]) + "=" + "&"; //Item77
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4971]) + "=" + "&"; //Item78
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4976]) + "=" + "&"; //Item79
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4981]) + "=" + "&"; //Item80
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4986]) + "=" + "&"; //Item81
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4991]) + "=" + "&"; //Item82
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[4996]) + "=" + "&"; //Item83
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5013]) + "=" + "&"; //Item84
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5018]) + "=" + "&"; //Item85
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5023]) + "=" + "&"; //Item86
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5028]) + "=" + "&"; //Item87
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5033]) + "=" + "&"; //Item88
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5038]) + "=" + "&"; //Item89
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5052]) + "=" + "&"; //Item90
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5057]) + "=" + "&"; //Item91
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5062]) + "=" + "&"; //Item92
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5067]) + "=" + "&"; //Item93
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5072]) + "=" + "&"; //Item94
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5077]) + "=" + "&"; //Item95
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5091]) + "=" + "&"; //Item96
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5096]) + "=" + "&"; //Item97
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5101]) + "=" + "&"; //Item98
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5106]) + "=" + "&"; //Item99
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5120]) + "=" + "&"; //Item100
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5125]) + "=" + "&"; //Item101
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5130]) + "=" + "&"; //Item102
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5135]) + "=" + "&"; //Item103
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5158]) + "=" + "&"; //Item104
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5165]) + "=" + "&"; //Item105
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5172]) + "=" + "&"; //Item106
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5179]) + "=" + "&"; //Item107
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5189]) + "=" + "&"; //Item108
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5196]) + "=" + "&"; //Item109
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5203]) + "=" + "&"; //Item110
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5210]) + "=" + "&"; //Item111
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5222]) + "=" + "&"; //Item112
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5227]) + "=" + "&"; //Item113
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5232]) + "=" + "&"; //Item114
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5239]) + "=" + "&"; //Item115
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5244]) + "=" + "&"; //Item116
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5249]) + "=" + "&"; //Item117
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5258]) + "=" + "&"; //Item118
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5266]) + "=" + "&"; //Item119
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5271]) + "=" + "&"; //Item120
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5276]) + "=" + "&"; //Item121
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5281]) + "=" + "&"; //Item122
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5292]) + "="; //Item123
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5303]) + "&"; //Item124
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5440]) + "=" + "&"; //Item125
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5445]) + "=" + "&"; //Item126
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5450]) + "=" + "&"; //Item127
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5455]) + "=" + "&"; //Item128
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5463]) + "="; //Item129
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5563]) + "&"; //Item130
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5611]) + "=" + "&"; //Item131
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5616]) + "=" + "&"; //Item132
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5621]) + "=" + "&"; //Item133
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5626]) + "=" + "&"; //Item134
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5634]) + "="; //Item135
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5740]) + "&"; //Item136
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5782]) + "=" + "&"; //Item137
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5787]) + "=" + "&"; //Item138
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5792]) + "=" + "&"; //Item139
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5797]) + "=" + "&"; //Item140
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5805]) + "="; //Item141
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5914]) + "&"; //Item142
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5953]) + "=" + "&"; //Item143
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5958]) + "=" + "&"; //Item144
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5963]) + "=" + "&"; //Item145
                    urlToRetrieveParam += split_Text(wordWebCodeResponse[5968]) + "="; //Item146
                    

                    textBoxUrlToRetrieveParam.Text = urlToRetrieveParam;
                        

                    /*
                    indexFirst = textBoxWebCodeResponse.Text.IndexOf("<form method='POST' name='main' action='/dwh/retrieve/comParam'");
                    textBoxFirstIndex.Text = indexFirst.ToString();

                    stringLength = "<form method='POST' name='main' action='/dwh/retrieve/comParam'".Length;
                    textBoxStringLength.Text = stringLength.ToString();

                    //indexLast = textBoxWebCodeResponse.Text.LastIndexOf("<form method='POST' name='main' action='/dwh/retrieve/comParam'");
                    //textBoxLastIndex.Text = indexLast.ToString();

                    //wordFinding = textBoxWordFinding.Text
                    textBoxWordFinding.Text = textBoxWebCodeResponse.Text.Substring(indexFirst, (indexFirst + stringLength));
                    

                    stateShowUrlToRetrieveParam = 2;
                    break;

                    */









//##### End : Backup Code ######

  
