using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIRE_Test_Healthy_Check
{
    public partial class Form1 : Form
    {
        //##### Begin : Decare variable in Form1 #####
        string[] wordWebCodeResponse; //Check Word in textBoxWebCodeResponse
        int indexWordWebCodeResponse = 0; //Index of string array, wordWebCodeResponse
        bool statusDelay = false; //Check Function delay_State is done?
        bool statusAddWordInRowTable = false; //Check Function addword_InRowTable is done?
        bool statusGoUrl = false; //Check Function go_Url is done?
        bool statusShowUrlRetrieveProcess = false; //Check Function show_UrlRetrieveProcess

        byte stateDelay = 0; //Initial State of Function delay at state0
        byte stateAddWordInRowTable = 0; //Initial State of Function addword_InRowTable
        byte stateGoUrl = 0; //Initial State of Function go_Url
        byte stateShowUrlRetrieveProcess = 0; //Initial State of Function show_UrlRetrieveProcess

        double testShow = 10.0;
        int test = 0;
        bool switchStepRun = false; //Decare to test function by STEP Run
        bool switchDownloadCsvFile = false; //Decare for ON function download_CsvFile
        bool switchSaveCsvFile = false; //Decare for ON function save_CsvFile
        bool switchReadCsvFile = false; //Decare for ON function read_CsvFile
        bool switchSearchDataInCsvFile = false; //Decare for ON function search_DataInCsvFile

        double stateDownloadCsvFile = 0; //Initial State of Function download_CsvFile at state0
        double stateSaveCsvFile = 0; //Initial State of Function save_CsvFile at state0

        bool statusWebBrowser1DocumentCompleted = false; //Decare for check when webBrowser1_DocumentCompleted


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

        //##### Begin : show_UrlRetrieveProcess
        private bool show_UrlRetrieveProcess()
        {
            switch (stateShowUrlRetrieveProcess)
            {
                case 0: //Initial Variable
                    statusShowUrlRetrieveProcess = false;
                    stateShowUrlRetrieveProcess = 1;
                    break;
                case 1: //State1 : Show wordWebCodeResponse[17] to textbox
                    textBoxWebCodeResponseSubStringIndex17.Text = wordWebCodeResponse[17];
                    stateShowUrlRetrieveProcess = 2;
                    break;
                case 2: //State2 : Show wordWebCodeResponse[17] after trimmed unneccessary charracters to textbox
                    textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Text = wordWebCodeResponse[17].Substring(7, 56);
                    stateShowUrlRetrieveProcess = 3;
                    break;
                case 3: //State3 : Show ParametricDataRetrieveProductionDB URL to textbox
                    textBoxParametricDataRetrieveProductionDB.Text = "http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56);
                    stateShowUrlRetrieveProcess = 4;
                    break;
                case 4: //State4 : Clear Variable
                    statusShowUrlRetrieveProcess = true;
                    stateShowUrlRetrieveProcess = 0;
                    break;
                default:
                    break;
            }
            return statusShowUrlRetrieveProcess;
        }
        //##### End : show_UrlRetrieveProcess


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
                    case 5: //State5 : Show WebCode Response String Length from Server
                        if (addword_InRowTable())
                        {
                            stateDownloadCsvFile = 6;
                        }
                        break;
                    case 6: //State6 : Show URL of RetrieveProcess
                        if (show_UrlRetrieveProcess())
                        {
                            stateDownloadCsvFile = 7;
                        }
                        break;
                    case 7: //State7 : Go ParametricDataRetrieveProductionDB Page
                        if (go_Url("http://dwhweb.prb.hgst.com/" + wordWebCodeResponse[17].Substring(7, 56)))
                        {
                            stateDownloadCsvFile = 8;
                        }
                        break;
                    case 8: //State8 : Test RetrieveProcess
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











    ##### End : Backup Code ######

    */
