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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonStepRun = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerStateCyclic = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(27, 14);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(56, 28);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "TEST";
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
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(1216, 950);
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
            this.textBoxWebCodeResponse.Size = new System.Drawing.Size(1171, 539);
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
            this.buttonTestGoParametricUrl1.Location = new System.Drawing.Point(537, 331);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1280, 980);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.textBox3);
            this.tabPage0.Controls.Add(this.textBox2);
            this.tabPage0.Controls.Add(this.buttonStepRun);
            this.tabPage0.Controls.Add(this.textBox1);
            this.tabPage0.Controls.Add(this.button1);
            this.tabPage0.Location = new System.Drawing.Point(4, 22);
            this.tabPage0.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Size = new System.Drawing.Size(1272, 954);
            this.tabPage0.TabIndex = 3;
            this.tabPage0.Text = "tabPage0";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(256, 136);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(256, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 20);
            this.textBox2.TabIndex = 3;
            // 
            // buttonStepRun
            // 
            this.buttonStepRun.Location = new System.Drawing.Point(160, 73);
            this.buttonStepRun.Name = "buttonStepRun";
            this.buttonStepRun.Size = new System.Drawing.Size(75, 40);
            this.buttonStepRun.TabIndex = 2;
            this.buttonStepRun.Text = "stepRun";
            this.buttonStepRun.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonTest);
            this.tabPage1.Controls.Add(this.labelWebCodeResponse);
            this.tabPage1.Controls.Add(this.textBoxUrlToGo);
            this.tabPage1.Controls.Add(this.labelUrlResponse);
            this.tabPage1.Controls.Add(this.textBoxUrlResponse);
            this.tabPage1.Controls.Add(this.labelUrlToGo);
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
            // tabPage2
            // 
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
            // tabPage3
            // 
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerStateCyclic
            // 
            this.timerStateCyclic.Interval = 10;
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
            this.tabPage0.ResumeLayout(false);
            this.tabPage0.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonStepRun;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

