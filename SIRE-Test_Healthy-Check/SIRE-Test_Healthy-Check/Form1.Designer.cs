namespace SIRE_Test_Healthy_Check
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonTest = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBoxUrlToGo = new System.Windows.Forms.TextBox();
            this.textBoxUrlResponse = new System.Windows.Forms.TextBox();
            this.textBoxWebCodeResponse = new System.Windows.Forms.TextBox();
            this.labelUrlToGo = new System.Windows.Forms.Label();
            this.labelUrlResponse = new System.Windows.Forms.Label();
            this.labelWebCodeResponse = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelWebCodeResponseStringLength = new System.Windows.Forms.Label();
            this.textBoxWebCodeResponseStringLength = new System.Windows.Forms.TextBox();
            this.textBoxWebCodeResponseSubStringLength = new System.Windows.Forms.TextBox();
            this.labelWebCodeResponseSubStringLength = new System.Windows.Forms.Label();
            this.labelWebCodeResponseLastSubString = new System.Windows.Forms.Label();
            this.textBoxWebCodeResponseLastSubString = new System.Windows.Forms.TextBox();
            this.labelWebCodeResponseSubStringIndex17 = new System.Windows.Forms.Label();
            this.textBoxWebCodeResponseSubStringIndex17 = new System.Windows.Forms.TextBox();
            this.buttonTestTrim = new System.Windows.Forms.Button();
            this.labelWebCodeResponseAfterTrimmed = new System.Windows.Forms.Label();
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed = new System.Windows.Forms.TextBox();
            this.labelParametricDataRetrieveProductionDB = new System.Windows.Forms.Label();
            this.textBoxParametricDataRetrieveProductionDB = new System.Windows.Forms.TextBox();
            this.buttonTestGoParametricUrl1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelCsvData = new System.Windows.Forms.Label();
            this.textBoxCsvData = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelStateSaveCsvFile = new System.Windows.Forms.Label();
            this.labelStateDownloadCsvFile = new System.Windows.Forms.Label();
            this.textBoxStateSaveCsvFile = new System.Windows.Forms.TextBox();
            this.textBoxStateDownloadCsvFile = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelWordRunning = new System.Windows.Forms.Label();
            this.textBoxWordRunning = new System.Windows.Forms.TextBox();
            this.labelIndexRunning = new System.Windows.Forms.Label();
            this.textBoxIndexRunning = new System.Windows.Forms.TextBox();
            this.textBoxUrlToGetCsvData = new System.Windows.Forms.TextBox();
            this.textBoxUrlToRetrieveParam = new System.Windows.Forms.TextBox();
            this.labelUrlToGetCsvData = new System.Windows.Forms.Label();
            this.labelUrlToRetrieveParam = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonCheckDataInDataGridView2 = new System.Windows.Forms.Button();
            this.textBoxDataGridView2Column = new System.Windows.Forms.TextBox();
            this.labelDataGridView2Column = new System.Windows.Forms.Label();
            this.textBoxDataGridView2Value = new System.Windows.Forms.TextBox();
            this.textBoxDataGridView2Row = new System.Windows.Forms.TextBox();
            this.labelDataGridView2Row = new System.Windows.Forms.Label();
            this.textBoxIndexCsvDataColumn = new System.Windows.Forms.TextBox();
            this.label_IndexOfCsvDataColumn = new System.Windows.Forms.Label();
            this.textBoxIndexCsvDataRow = new System.Windows.Forms.TextBox();
            this.label_IndexOfCsvDataRow = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerStateCyclic = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(27, 14);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(91, 28);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "TEST AGAIN";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(998, 940);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // textBoxUrlToGo
            // 
            this.textBoxUrlToGo.Location = new System.Drawing.Point(27, 66);
            this.textBoxUrlToGo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUrlToGo.Multiline = true;
            this.textBoxUrlToGo.Name = "textBoxUrlToGo";
            this.textBoxUrlToGo.Size = new System.Drawing.Size(1171, 19);
            this.textBoxUrlToGo.TabIndex = 2;
            // 
            // textBoxUrlResponse
            // 
            this.textBoxUrlResponse.Location = new System.Drawing.Point(27, 107);
            this.textBoxUrlResponse.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUrlResponse.Multiline = true;
            this.textBoxUrlResponse.Name = "textBoxUrlResponse";
            this.textBoxUrlResponse.Size = new System.Drawing.Size(1171, 110);
            this.textBoxUrlResponse.TabIndex = 3;
            // 
            // textBoxWebCodeResponse
            // 
            this.textBoxWebCodeResponse.Location = new System.Drawing.Point(27, 241);
            this.textBoxWebCodeResponse.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponse.Multiline = true;
            this.textBoxWebCodeResponse.Name = "textBoxWebCodeResponse";
            this.textBoxWebCodeResponse.Size = new System.Drawing.Size(1171, 317);
            this.textBoxWebCodeResponse.TabIndex = 4;
            // 
            // labelUrlToGo
            // 
            this.labelUrlToGo.AutoSize = true;
            this.labelUrlToGo.Location = new System.Drawing.Point(28, 50);
            this.labelUrlToGo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUrlToGo.Name = "labelUrlToGo";
            this.labelUrlToGo.Size = new System.Drawing.Size(56, 13);
            this.labelUrlToGo.TabIndex = 5;
            this.labelUrlToGo.Text = "URL to go";
            // 
            // labelUrlResponse
            // 
            this.labelUrlResponse.AutoSize = true;
            this.labelUrlResponse.Location = new System.Drawing.Point(27, 91);
            this.labelUrlResponse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUrlResponse.Name = "labelUrlResponse";
            this.labelUrlResponse.Size = new System.Drawing.Size(80, 13);
            this.labelUrlResponse.TabIndex = 5;
            this.labelUrlResponse.Text = "URL Response";
            // 
            // labelWebCodeResponse
            // 
            this.labelWebCodeResponse.AutoSize = true;
            this.labelWebCodeResponse.Location = new System.Drawing.Point(28, 226);
            this.labelWebCodeResponse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponse.Name = "labelWebCodeResponse";
            this.labelWebCodeResponse.Size = new System.Drawing.Size(109, 13);
            this.labelWebCodeResponse.TabIndex = 5;
            this.labelWebCodeResponse.Text = "Web Code Response";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 63);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(511, 726);
            this.dataGridView1.TabIndex = 6;
            // 
            // labelWebCodeResponseStringLength
            // 
            this.labelWebCodeResponseStringLength.AutoSize = true;
            this.labelWebCodeResponseStringLength.Location = new System.Drawing.Point(9, 23);
            this.labelWebCodeResponseStringLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponseStringLength.Name = "labelWebCodeResponseStringLength";
            this.labelWebCodeResponseStringLength.Size = new System.Drawing.Size(109, 26);
            this.labelWebCodeResponseStringLength.TabIndex = 5;
            this.labelWebCodeResponseStringLength.Text = "Web Code Response\r\nString Length";
            // 
            // textBoxWebCodeResponseStringLength
            // 
            this.textBoxWebCodeResponseStringLength.Location = new System.Drawing.Point(118, 23);
            this.textBoxWebCodeResponseStringLength.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponseStringLength.Name = "textBoxWebCodeResponseStringLength";
            this.textBoxWebCodeResponseStringLength.Size = new System.Drawing.Size(50, 20);
            this.textBoxWebCodeResponseStringLength.TabIndex = 7;
            // 
            // textBoxWebCodeResponseSubStringLength
            // 
            this.textBoxWebCodeResponseSubStringLength.Location = new System.Drawing.Point(289, 23);
            this.textBoxWebCodeResponseSubStringLength.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponseSubStringLength.Name = "textBoxWebCodeResponseSubStringLength";
            this.textBoxWebCodeResponseSubStringLength.Size = new System.Drawing.Size(50, 20);
            this.textBoxWebCodeResponseSubStringLength.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringLength
            // 
            this.labelWebCodeResponseSubStringLength.AutoSize = true;
            this.labelWebCodeResponseSubStringLength.Location = new System.Drawing.Point(178, 23);
            this.labelWebCodeResponseSubStringLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponseSubStringLength.Name = "labelWebCodeResponseSubStringLength";
            this.labelWebCodeResponseSubStringLength.Size = new System.Drawing.Size(109, 26);
            this.labelWebCodeResponseSubStringLength.TabIndex = 5;
            this.labelWebCodeResponseSubStringLength.Text = "Web Code Response\r\nSubString Length";
            // 
            // labelWebCodeResponseLastSubString
            // 
            this.labelWebCodeResponseLastSubString.AutoSize = true;
            this.labelWebCodeResponseLastSubString.Location = new System.Drawing.Point(352, 23);
            this.labelWebCodeResponseLastSubString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponseLastSubString.Name = "labelWebCodeResponseLastSubString";
            this.labelWebCodeResponseLastSubString.Size = new System.Drawing.Size(109, 26);
            this.labelWebCodeResponseLastSubString.TabIndex = 5;
            this.labelWebCodeResponseLastSubString.Text = "Web Code Response\r\nLast SubString";
            // 
            // textBoxWebCodeResponseLastSubString
            // 
            this.textBoxWebCodeResponseLastSubString.Location = new System.Drawing.Point(464, 23);
            this.textBoxWebCodeResponseLastSubString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponseLastSubString.Name = "textBoxWebCodeResponseLastSubString";
            this.textBoxWebCodeResponseLastSubString.Size = new System.Drawing.Size(735, 20);
            this.textBoxWebCodeResponseLastSubString.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringIndex17
            // 
            this.labelWebCodeResponseSubStringIndex17.AutoSize = true;
            this.labelWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(536, 109);
            this.labelWebCodeResponseSubStringIndex17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponseSubStringIndex17.Name = "labelWebCodeResponseSubStringIndex17";
            this.labelWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(196, 13);
            this.labelWebCodeResponseSubStringIndex17.TabIndex = 5;
            this.labelWebCodeResponseSubStringIndex17.Text = "Web Code Response SubStringIndex17\r\n";
            // 
            // textBoxWebCodeResponseSubStringIndex17
            // 
            this.textBoxWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(538, 124);
            this.textBoxWebCodeResponseSubStringIndex17.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponseSubStringIndex17.Name = "textBoxWebCodeResponseSubStringIndex17";
            this.textBoxWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(661, 20);
            this.textBoxWebCodeResponseSubStringIndex17.TabIndex = 7;
            // 
            // buttonTestTrim
            // 
            this.buttonTestTrim.Location = new System.Drawing.Point(538, 63);
            this.buttonTestTrim.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestTrim.Name = "buttonTestTrim";
            this.buttonTestTrim.Size = new System.Drawing.Size(72, 30);
            this.buttonTestTrim.TabIndex = 8;
            this.buttonTestTrim.Text = "Test Trim";
            this.buttonTestTrim.UseVisualStyleBackColor = true;
            this.buttonTestTrim.Click += new System.EventHandler(this.buttonTestTrim_Click);
            // 
            // labelWebCodeResponseAfterTrimmed
            // 
            this.labelWebCodeResponseAfterTrimmed.AutoSize = true;
            this.labelWebCodeResponseAfterTrimmed.Location = new System.Drawing.Point(535, 155);
            this.labelWebCodeResponseAfterTrimmed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponseAfterTrimmed.Name = "labelWebCodeResponseAfterTrimmed";
            this.labelWebCodeResponseAfterTrimmed.Size = new System.Drawing.Size(261, 26);
            this.labelWebCodeResponseAfterTrimmed.TabIndex = 5;
            this.labelWebCodeResponseAfterTrimmed.Text = "Web Code Response SubStringIndex17 AfterTrimmed\r\n\r\n";
            // 
            // textBoxWebCodeResponseSubStringIndex17AfterTrimmed
            // 
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Location = new System.Drawing.Point(537, 170);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Name = "textBoxWebCodeResponseSubStringIndex17AfterTrimmed";
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Size = new System.Drawing.Size(662, 20);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.TabIndex = 7;
            // 
            // labelParametricDataRetrieveProductionDB
            // 
            this.labelParametricDataRetrieveProductionDB.AutoSize = true;
            this.labelParametricDataRetrieveProductionDB.Location = new System.Drawing.Point(534, 203);
            this.labelParametricDataRetrieveProductionDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelParametricDataRetrieveProductionDB.Name = "labelParametricDataRetrieveProductionDB";
            this.labelParametricDataRetrieveProductionDB.Size = new System.Drawing.Size(204, 13);
            this.labelParametricDataRetrieveProductionDB.TabIndex = 5;
            this.labelParametricDataRetrieveProductionDB.Text = "Parametric Data Retrieve (Production DB)";
            // 
            // textBoxParametricDataRetrieveProductionDB
            // 
            this.textBoxParametricDataRetrieveProductionDB.Location = new System.Drawing.Point(537, 218);
            this.textBoxParametricDataRetrieveProductionDB.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxParametricDataRetrieveProductionDB.Name = "textBoxParametricDataRetrieveProductionDB";
            this.textBoxParametricDataRetrieveProductionDB.Size = new System.Drawing.Size(662, 20);
            this.textBoxParametricDataRetrieveProductionDB.TabIndex = 7;
            // 
            // buttonTestGoParametricUrl1
            // 
            this.buttonTestGoParametricUrl1.Location = new System.Drawing.Point(537, 254);
            this.buttonTestGoParametricUrl1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestGoParametricUrl1.Name = "buttonTestGoParametricUrl1";
            this.buttonTestGoParametricUrl1.Size = new System.Drawing.Size(151, 26);
            this.buttonTestGoParametricUrl1.TabIndex = 9;
            this.buttonTestGoParametricUrl1.Text = "Test Go Parametric URL 1";
            this.buttonTestGoParametricUrl1.UseVisualStyleBackColor = true;
            this.buttonTestGoParametricUrl1.Click += new System.EventHandler(this.buttonTestGoParametricUrl1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage0);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1280, 980);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage0
            // 
            this.tabPage0.Location = new System.Drawing.Point(4, 22);
            this.tabPage0.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Size = new System.Drawing.Size(1272, 954);
            this.tabPage0.TabIndex = 3;
            this.tabPage0.Text = "tabPage0";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonTest);
            this.tabPage1.Controls.Add(this.labelCsvData);
            this.tabPage1.Controls.Add(this.labelWebCodeResponse);
            this.tabPage1.Controls.Add(this.textBoxUrlToGo);
            this.tabPage1.Controls.Add(this.labelUrlResponse);
            this.tabPage1.Controls.Add(this.textBoxUrlResponse);
            this.tabPage1.Controls.Add(this.labelUrlToGo);
            this.tabPage1.Controls.Add(this.textBoxCsvData);
            this.tabPage1.Controls.Add(this.textBoxWebCodeResponse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1272, 954);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelCsvData
            // 
            this.labelCsvData.AutoSize = true;
            this.labelCsvData.Location = new System.Drawing.Point(28, 592);
            this.labelCsvData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCsvData.Name = "labelCsvData";
            this.labelCsvData.Size = new System.Drawing.Size(54, 13);
            this.labelCsvData.TabIndex = 5;
            this.labelCsvData.Text = "CSV Data";
            // 
            // textBoxCsvData
            // 
            this.textBoxCsvData.Location = new System.Drawing.Point(27, 612);
            this.textBoxCsvData.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCsvData.Multiline = true;
            this.textBoxCsvData.Name = "textBoxCsvData";
            this.textBoxCsvData.Size = new System.Drawing.Size(1171, 320);
            this.textBoxCsvData.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelStateSaveCsvFile);
            this.tabPage2.Controls.Add(this.labelStateDownloadCsvFile);
            this.tabPage2.Controls.Add(this.textBoxStateSaveCsvFile);
            this.tabPage2.Controls.Add(this.textBoxStateDownloadCsvFile);
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1272, 954);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelStateSaveCsvFile
            // 
            this.labelStateSaveCsvFile.AutoSize = true;
            this.labelStateSaveCsvFile.Location = new System.Drawing.Point(1077, 100);
            this.labelStateSaveCsvFile.Name = "labelStateSaveCsvFile";
            this.labelStateSaveCsvFile.Size = new System.Drawing.Size(91, 13);
            this.labelStateSaveCsvFile.TabIndex = 3;
            this.labelStateSaveCsvFile.Text = "StateSaveCsvFile";
            // 
            // labelStateDownloadCsvFile
            // 
            this.labelStateDownloadCsvFile.AutoSize = true;
            this.labelStateDownloadCsvFile.Location = new System.Drawing.Point(1077, 39);
            this.labelStateDownloadCsvFile.Name = "labelStateDownloadCsvFile";
            this.labelStateDownloadCsvFile.Size = new System.Drawing.Size(114, 13);
            this.labelStateDownloadCsvFile.TabIndex = 3;
            this.labelStateDownloadCsvFile.Text = "StateDownloadCsvFile";
            // 
            // textBoxStateSaveCsvFile
            // 
            this.textBoxStateSaveCsvFile.Location = new System.Drawing.Point(1077, 119);
            this.textBoxStateSaveCsvFile.Name = "textBoxStateSaveCsvFile";
            this.textBoxStateSaveCsvFile.Size = new System.Drawing.Size(100, 20);
            this.textBoxStateSaveCsvFile.TabIndex = 2;
            // 
            // textBoxStateDownloadCsvFile
            // 
            this.textBoxStateDownloadCsvFile.Location = new System.Drawing.Point(1077, 58);
            this.textBoxStateDownloadCsvFile.Name = "textBoxStateDownloadCsvFile";
            this.textBoxStateDownloadCsvFile.Size = new System.Drawing.Size(100, 20);
            this.textBoxStateDownloadCsvFile.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelWordRunning);
            this.tabPage3.Controls.Add(this.textBoxWordRunning);
            this.tabPage3.Controls.Add(this.labelIndexRunning);
            this.tabPage3.Controls.Add(this.textBoxIndexRunning);
            this.tabPage3.Controls.Add(this.textBoxUrlToGetCsvData);
            this.tabPage3.Controls.Add(this.textBoxUrlToRetrieveParam);
            this.tabPage3.Controls.Add(this.labelUrlToGetCsvData);
            this.tabPage3.Controls.Add(this.labelUrlToRetrieveParam);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.buttonTestGoParametricUrl1);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseStringLength);
            this.tabPage3.Controls.Add(this.buttonTestTrim);
            this.tabPage3.Controls.Add(this.textBoxParametricDataRetrieveProductionDB);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseSubStringLength);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseLastSubString);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseStringLength);
            this.tabPage3.Controls.Add(this.labelParametricDataRetrieveProductionDB);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringLength);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseAfterTrimmed);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseLastSubString);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseSubStringIndex17);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1272, 954);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // labelWordRunning
            // 
            this.labelWordRunning.AutoSize = true;
            this.labelWordRunning.Location = new System.Drawing.Point(629, 709);
            this.labelWordRunning.Name = "labelWordRunning";
            this.labelWordRunning.Size = new System.Drawing.Size(76, 13);
            this.labelWordRunning.TabIndex = 13;
            this.labelWordRunning.Text = "Word Running";
            // 
            // textBoxWordRunning
            // 
            this.textBoxWordRunning.Location = new System.Drawing.Point(629, 728);
            this.textBoxWordRunning.Name = "textBoxWordRunning";
            this.textBoxWordRunning.Size = new System.Drawing.Size(418, 20);
            this.textBoxWordRunning.TabIndex = 12;
            // 
            // labelIndexRunning
            // 
            this.labelIndexRunning.AutoSize = true;
            this.labelIndexRunning.Location = new System.Drawing.Point(537, 709);
            this.labelIndexRunning.Name = "labelIndexRunning";
            this.labelIndexRunning.Size = new System.Drawing.Size(76, 13);
            this.labelIndexRunning.TabIndex = 13;
            this.labelIndexRunning.Text = "Index Running";
            // 
            // textBoxIndexRunning
            // 
            this.textBoxIndexRunning.Location = new System.Drawing.Point(537, 728);
            this.textBoxIndexRunning.Name = "textBoxIndexRunning";
            this.textBoxIndexRunning.Size = new System.Drawing.Size(67, 20);
            this.textBoxIndexRunning.TabIndex = 12;
            // 
            // textBoxUrlToGetCsvData
            // 
            this.textBoxUrlToGetCsvData.Location = new System.Drawing.Point(538, 539);
            this.textBoxUrlToGetCsvData.Multiline = true;
            this.textBoxUrlToGetCsvData.Name = "textBoxUrlToGetCsvData";
            this.textBoxUrlToGetCsvData.Size = new System.Drawing.Size(709, 167);
            this.textBoxUrlToGetCsvData.TabIndex = 11;
            // 
            // textBoxUrlToRetrieveParam
            // 
            this.textBoxUrlToRetrieveParam.Location = new System.Drawing.Point(539, 324);
            this.textBoxUrlToRetrieveParam.Multiline = true;
            this.textBoxUrlToRetrieveParam.Name = "textBoxUrlToRetrieveParam";
            this.textBoxUrlToRetrieveParam.Size = new System.Drawing.Size(709, 167);
            this.textBoxUrlToRetrieveParam.TabIndex = 11;
            // 
            // labelUrlToGetCsvData
            // 
            this.labelUrlToGetCsvData.AutoSize = true;
            this.labelUrlToGetCsvData.Location = new System.Drawing.Point(537, 523);
            this.labelUrlToGetCsvData.Name = "labelUrlToGetCsvData";
            this.labelUrlToGetCsvData.Size = new System.Drawing.Size(102, 13);
            this.labelUrlToGetCsvData.TabIndex = 10;
            this.labelUrlToGetCsvData.Text = "URL to GetCsvData";
            // 
            // labelUrlToRetrieveParam
            // 
            this.labelUrlToRetrieveParam.AutoSize = true;
            this.labelUrlToRetrieveParam.Location = new System.Drawing.Point(535, 307);
            this.labelUrlToRetrieveParam.Name = "labelUrlToRetrieveParam";
            this.labelUrlToRetrieveParam.Size = new System.Drawing.Size(114, 13);
            this.labelUrlToRetrieveParam.TabIndex = 10;
            this.labelUrlToRetrieveParam.Text = "URL to RetrieveParam";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonCheckDataInDataGridView2);
            this.tabPage4.Controls.Add(this.textBoxDataGridView2Column);
            this.tabPage4.Controls.Add(this.labelDataGridView2Column);
            this.tabPage4.Controls.Add(this.textBoxDataGridView2Value);
            this.tabPage4.Controls.Add(this.textBoxDataGridView2Row);
            this.tabPage4.Controls.Add(this.labelDataGridView2Row);
            this.tabPage4.Controls.Add(this.textBoxIndexCsvDataColumn);
            this.tabPage4.Controls.Add(this.label_IndexOfCsvDataColumn);
            this.tabPage4.Controls.Add(this.textBoxIndexCsvDataRow);
            this.tabPage4.Controls.Add(this.label_IndexOfCsvDataRow);
            this.tabPage4.Controls.Add(this.dataGridView2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1272, 954);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonCheckDataInDataGridView2
            // 
            this.buttonCheckDataInDataGridView2.Location = new System.Drawing.Point(27, 799);
            this.buttonCheckDataInDataGridView2.Name = "buttonCheckDataInDataGridView2";
            this.buttonCheckDataInDataGridView2.Size = new System.Drawing.Size(125, 47);
            this.buttonCheckDataInDataGridView2.TabIndex = 22;
            this.buttonCheckDataInDataGridView2.Text = "Check Data in DataGridView2";
            this.buttonCheckDataInDataGridView2.UseVisualStyleBackColor = true;
            this.buttonCheckDataInDataGridView2.Click += new System.EventHandler(this.buttonCheckDataInDataGridView2_Click);
            // 
            // textBoxDataGridView2Column
            // 
            this.textBoxDataGridView2Column.Location = new System.Drawing.Point(471, 759);
            this.textBoxDataGridView2Column.Name = "textBoxDataGridView2Column";
            this.textBoxDataGridView2Column.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Column.TabIndex = 21;
            // 
            // labelDataGridView2Column
            // 
            this.labelDataGridView2Column.AutoSize = true;
            this.labelDataGridView2Column.Location = new System.Drawing.Point(335, 762);
            this.labelDataGridView2Column.Name = "labelDataGridView2Column";
            this.labelDataGridView2Column.Size = new System.Drawing.Size(120, 13);
            this.labelDataGridView2Column.TabIndex = 20;
            this.labelDataGridView2Column.Text = "dataGridView2Column =";
            // 
            // textBoxDataGridView2Value
            // 
            this.textBoxDataGridView2Value.Location = new System.Drawing.Point(158, 813);
            this.textBoxDataGridView2Value.Name = "textBoxDataGridView2Value";
            this.textBoxDataGridView2Value.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Value.TabIndex = 18;
            // 
            // textBoxDataGridView2Row
            // 
            this.textBoxDataGridView2Row.Location = new System.Drawing.Point(158, 759);
            this.textBoxDataGridView2Row.Name = "textBoxDataGridView2Row";
            this.textBoxDataGridView2Row.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Row.TabIndex = 19;
            // 
            // labelDataGridView2Row
            // 
            this.labelDataGridView2Row.AutoSize = true;
            this.labelDataGridView2Row.Location = new System.Drawing.Point(24, 762);
            this.labelDataGridView2Row.Name = "labelDataGridView2Row";
            this.labelDataGridView2Row.Size = new System.Drawing.Size(107, 13);
            this.labelDataGridView2Row.TabIndex = 17;
            this.labelDataGridView2Row.Text = "dataGridView2Row =";
            // 
            // textBoxIndexCsvDataColumn
            // 
            this.textBoxIndexCsvDataColumn.Location = new System.Drawing.Point(483, 30);
            this.textBoxIndexCsvDataColumn.Name = "textBoxIndexCsvDataColumn";
            this.textBoxIndexCsvDataColumn.Size = new System.Drawing.Size(157, 20);
            this.textBoxIndexCsvDataColumn.TabIndex = 16;
            // 
            // label_IndexOfCsvDataColumn
            // 
            this.label_IndexOfCsvDataColumn.AutoSize = true;
            this.label_IndexOfCsvDataColumn.Location = new System.Drawing.Point(335, 33);
            this.label_IndexOfCsvDataColumn.Name = "label_IndexOfCsvDataColumn";
            this.label_IndexOfCsvDataColumn.Size = new System.Drawing.Size(142, 13);
            this.label_IndexOfCsvDataColumn.TabIndex = 15;
            this.label_IndexOfCsvDataColumn.Text = "Index of CSV Data Column =";
            // 
            // textBoxIndexCsvDataRow
            // 
            this.textBoxIndexCsvDataRow.Location = new System.Drawing.Point(158, 30);
            this.textBoxIndexCsvDataRow.Name = "textBoxIndexCsvDataRow";
            this.textBoxIndexCsvDataRow.Size = new System.Drawing.Size(157, 20);
            this.textBoxIndexCsvDataRow.TabIndex = 14;
            // 
            // label_IndexOfCsvDataRow
            // 
            this.label_IndexOfCsvDataRow.AutoSize = true;
            this.label_IndexOfCsvDataRow.Location = new System.Drawing.Point(24, 33);
            this.label_IndexOfCsvDataRow.Name = "label_IndexOfCsvDataRow";
            this.label_IndexOfCsvDataRow.Size = new System.Drawing.Size(129, 13);
            this.label_IndexOfCsvDataRow.TabIndex = 13;
            this.label_IndexOfCsvDataRow.Text = "Index of CSV Data Row =";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(27, 74);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1171, 649);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1272, 954);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerStateCyclic
            // 
            this.timerStateCyclic.Interval = 1;
            this.timerStateCyclic.Tick += new System.EventHandler(this.timerStateCyclic_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBoxUrlToGo;
        private System.Windows.Forms.TextBox textBoxUrlResponse;
        private System.Windows.Forms.TextBox textBoxWebCodeResponse;
        private System.Windows.Forms.Label labelUrlToGo;
        private System.Windows.Forms.Label labelUrlResponse;
        private System.Windows.Forms.Label labelWebCodeResponse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelWebCodeResponseStringLength;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseStringLength;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseSubStringLength;
        private System.Windows.Forms.Label labelWebCodeResponseSubStringLength;
        private System.Windows.Forms.Label labelWebCodeResponseLastSubString;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseLastSubString;
        private System.Windows.Forms.Label labelWebCodeResponseSubStringIndex17;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseSubStringIndex17;
        private System.Windows.Forms.Button buttonTestTrim;
        private System.Windows.Forms.Label labelWebCodeResponseAfterTrimmed;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseSubStringIndex17AfterTrimmed;
        private System.Windows.Forms.Label labelParametricDataRetrieveProductionDB;
        private System.Windows.Forms.TextBox textBoxParametricDataRetrieveProductionDB;
        private System.Windows.Forms.Button buttonTestGoParametricUrl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage0;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerStateCyclic;
        private System.Windows.Forms.Label labelStateSaveCsvFile;
        private System.Windows.Forms.Label labelStateDownloadCsvFile;
        private System.Windows.Forms.TextBox textBoxStateSaveCsvFile;
        private System.Windows.Forms.TextBox textBoxStateDownloadCsvFile;
        private System.Windows.Forms.Label labelUrlToRetrieveParam;
        private System.Windows.Forms.TextBox textBoxUrlToRetrieveParam;
        private System.Windows.Forms.Label labelWordRunning;
        private System.Windows.Forms.TextBox textBoxWordRunning;
        private System.Windows.Forms.Label labelIndexRunning;
        private System.Windows.Forms.TextBox textBoxIndexRunning;
        private System.Windows.Forms.TextBox textBoxUrlToGetCsvData;
        private System.Windows.Forms.Label labelUrlToGetCsvData;
        private System.Windows.Forms.Label labelCsvData;
        private System.Windows.Forms.TextBox textBoxCsvData;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBoxIndexCsvDataColumn;
        private System.Windows.Forms.Label label_IndexOfCsvDataColumn;
        private System.Windows.Forms.TextBox textBoxIndexCsvDataRow;
        private System.Windows.Forms.Label label_IndexOfCsvDataRow;
        private System.Windows.Forms.Button buttonCheckDataInDataGridView2;
        private System.Windows.Forms.TextBox textBoxDataGridView2Column;
        private System.Windows.Forms.Label labelDataGridView2Column;
        private System.Windows.Forms.TextBox textBoxDataGridView2Value;
        private System.Windows.Forms.TextBox textBoxDataGridView2Row;
        private System.Windows.Forms.Label labelDataGridView2Row;
    }
}

