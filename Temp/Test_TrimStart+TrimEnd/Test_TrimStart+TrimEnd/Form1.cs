using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_TrimStart_TrimEnd
{
    public partial class Form1 : Form
    {
        string[] text = { "name='action'", "value='retrieveProcess'><div", "name='location'>", "value='0'>PRB</option>", "name='snlist'", "name='pfcode'" };
        string[] wordSplit;
        string urlToRetrieveParam = "http://dwhweb.prb.hgst.com/dwh/retrieve/comParam?";

        public Form1()
        {
            InitializeComponent();

            urlToRetrieveParam += split_Text(text[0]) + "=";
            urlToRetrieveParam += split_Text(text[1]) + "&";
            urlToRetrieveParam += split_Text(text[2]) + "=";
            urlToRetrieveParam += split_Text(text[3]) + "&";
            urlToRetrieveParam += split_Text(text[4]) + "=" + "&";
            urlToRetrieveParam += split_Text(text[5]) + "=";

            textBox1.Text = urlToRetrieveParam;
        }

        private string split_Text(string textInput)
        {
            wordSplit = textInput.Split('\'');
            return wordSplit[1];
        }
    }
}

/* Backup
 * 
 * 
 *          wordSplit = text[0].Split('\'');

            wordUrl += (wordSplit[1] + "=");

            wordSplit = text[1].Split('\'');

            wordUrl += (wordSplit[1] + "&");

            textBox4.Text = wordUrl;
 * 
 * */
