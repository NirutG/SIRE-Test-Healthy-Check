using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_find_WordIndex
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

        string wordRunning = ""; //Initial to use in Function find_WordIndex
        int indexCheck = 0; //Initial to use in Function find_WordIndex
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
        //AutoHand autoHand = new AutoHand();//Decare to use DLL File of AutoItX3
        //Point point = new Point(0, 0); //Decare point x=0, y=0
        Point point = new Point(0, 0); //Decare point x=0, y=0
        //WebClient webClient1 = new WebClient();



        //##### End : Decare variable in Form1 #####

        public Form1()
        {
            InitializeComponent();
        }

        //##### Begin : split_Text
        private string split_Text(string textInput)
        {
            if (textInput == wordWebCodeResponse[2582])
            {
                wordSplit = textInput.Split('<', '>');
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
                    wordRunning = "";
                    indexCheck = 0;
                    statusFindWordIndex = false;
                    stateFindWordIndex = 1;
                    break;
                case 1: //State1 : Initial wordRunning
                    indexCheck = indexInitial;
                    wordRunning = wordWebCodeResponse[indexCheck];
                    stateFindWordIndex = 2;
                    break;
                case 2: //State2 : Compare Words
                    if (wordWebCodeResponse[indexCheck] != wordToCompare)
                    {
                        indexCheck++;
                    }
                    else
                    {
                        wordRunning = wordWebCodeResponse[indexCheck];
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

    }
}
