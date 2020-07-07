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
            this.labelParametricUrl1 = new System.Windows.Forms.Label();
            this.textBoxParametricUrl1 = new System.Windows.Forms.TextBox();
            this.buttonTestGoParametricUrl1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(36, 17);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 34);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "TEST";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(48, 58);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1443, 757);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // textBoxUrlToGo
            // 
            this.textBoxUrlToGo.Location = new System.Drawing.Point(36, 81);
            this.textBoxUrlToGo.Multiline = true;
            this.textBoxUrlToGo.Name = "textBoxUrlToGo";
            this.textBoxUrlToGo.Size = new System.Drawing.Size(1657, 22);
            this.textBoxUrlToGo.TabIndex = 2;
            // 
            // textBoxUrlResponse
            // 
            this.textBoxUrlResponse.Location = new System.Drawing.Point(36, 132);
            this.textBoxUrlResponse.Multiline = true;
            this.textBoxUrlResponse.Name = "textBoxUrlResponse";
            this.textBoxUrlResponse.Size = new System.Drawing.Size(1657, 135);
            this.textBoxUrlResponse.TabIndex = 3;
            // 
            // textBoxWebCodeResponse
            // 
            this.textBoxWebCodeResponse.Location = new System.Drawing.Point(36, 297);
            this.textBoxWebCodeResponse.Multiline = true;
            this.textBoxWebCodeResponse.Name = "textBoxWebCodeResponse";
            this.textBoxWebCodeResponse.Size = new System.Drawing.Size(1657, 542);
            this.textBoxWebCodeResponse.TabIndex = 4;
            // 
            // labelUrlToGo
            // 
            this.labelUrlToGo.AutoSize = true;
            this.labelUrlToGo.Location = new System.Drawing.Point(37, 62);
            this.labelUrlToGo.Name = "labelUrlToGo";
            this.labelUrlToGo.Size = new System.Drawing.Size(72, 17);
            this.labelUrlToGo.TabIndex = 5;
            this.labelUrlToGo.Text = "URL to go";
            // 
            // labelUrlResponse
            // 
            this.labelUrlResponse.AutoSize = true;
            this.labelUrlResponse.Location = new System.Drawing.Point(36, 112);
            this.labelUrlResponse.Name = "labelUrlResponse";
            this.labelUrlResponse.Size = new System.Drawing.Size(104, 17);
            this.labelUrlResponse.TabIndex = 5;
            this.labelUrlResponse.Text = "URL Response";
            // 
            // labelWebCodeResponse
            // 
            this.labelWebCodeResponse.AutoSize = true;
            this.labelWebCodeResponse.Location = new System.Drawing.Point(37, 278);
            this.labelWebCodeResponse.Name = "labelWebCodeResponse";
            this.labelWebCodeResponse.Size = new System.Drawing.Size(142, 17);
            this.labelWebCodeResponse.TabIndex = 5;
            this.labelWebCodeResponse.Text = "Web Code Response";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(869, 775);
            this.dataGridView1.TabIndex = 6;
            // 
            // labelWebCodeResponseStringLength
            // 
            this.labelWebCodeResponseStringLength.AutoSize = true;
            this.labelWebCodeResponseStringLength.Location = new System.Drawing.Point(12, 28);
            this.labelWebCodeResponseStringLength.Name = "labelWebCodeResponseStringLength";
            this.labelWebCodeResponseStringLength.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseStringLength.TabIndex = 5;
            this.labelWebCodeResponseStringLength.Text = "Web Code Response\r\nString Length";
            // 
            // textBoxWebCodeResponseStringLength
            // 
            this.textBoxWebCodeResponseStringLength.Location = new System.Drawing.Point(158, 28);
            this.textBoxWebCodeResponseStringLength.Name = "textBoxWebCodeResponseStringLength";
            this.textBoxWebCodeResponseStringLength.Size = new System.Drawing.Size(66, 22);
            this.textBoxWebCodeResponseStringLength.TabIndex = 7;
            // 
            // textBoxWebCodeResponseSubStringLength
            // 
            this.textBoxWebCodeResponseSubStringLength.Location = new System.Drawing.Point(385, 28);
            this.textBoxWebCodeResponseSubStringLength.Name = "textBoxWebCodeResponseSubStringLength";
            this.textBoxWebCodeResponseSubStringLength.Size = new System.Drawing.Size(66, 22);
            this.textBoxWebCodeResponseSubStringLength.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringLength
            // 
            this.labelWebCodeResponseSubStringLength.AutoSize = true;
            this.labelWebCodeResponseSubStringLength.Location = new System.Drawing.Point(237, 28);
            this.labelWebCodeResponseSubStringLength.Name = "labelWebCodeResponseSubStringLength";
            this.labelWebCodeResponseSubStringLength.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseSubStringLength.TabIndex = 5;
            this.labelWebCodeResponseSubStringLength.Text = "Web Code Response\r\nSubString Length";
            // 
            // labelWebCodeResponseLastSubString
            // 
            this.labelWebCodeResponseLastSubString.AutoSize = true;
            this.labelWebCodeResponseLastSubString.Location = new System.Drawing.Point(470, 28);
            this.labelWebCodeResponseLastSubString.Name = "labelWebCodeResponseLastSubString";
            this.labelWebCodeResponseLastSubString.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseLastSubString.TabIndex = 5;
            this.labelWebCodeResponseLastSubString.Text = "Web Code Response\r\nLast SubString";
            // 
            // textBoxWebCodeResponseLastSubString
            // 
            this.textBoxWebCodeResponseLastSubString.Location = new System.Drawing.Point(618, 28);
            this.textBoxWebCodeResponseLastSubString.Name = "textBoxWebCodeResponseLastSubString";
            this.textBoxWebCodeResponseLastSubString.Size = new System.Drawing.Size(413, 22);
            this.textBoxWebCodeResponseLastSubString.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringIndex17
            // 
            this.labelWebCodeResponseSubStringIndex17.AutoSize = true;
            this.labelWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(906, 134);
            this.labelWebCodeResponseSubStringIndex17.Name = "labelWebCodeResponseSubStringIndex17";
            this.labelWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseSubStringIndex17.TabIndex = 5;
            this.labelWebCodeResponseSubStringIndex17.Text = "Web Code Response\r\nSubStringIndex17";
            // 
            // textBoxWebCodeResponseSubStringIndex17
            // 
            this.textBoxWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(909, 171);
            this.textBoxWebCodeResponseSubStringIndex17.Name = "textBoxWebCodeResponseSubStringIndex17";
            this.textBoxWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(827, 22);
            this.textBoxWebCodeResponseSubStringIndex17.TabIndex = 7;
            // 
            // buttonTestTrim
            // 
            this.buttonTestTrim.Location = new System.Drawing.Point(909, 78);
            this.buttonTestTrim.Name = "buttonTestTrim";
            this.buttonTestTrim.Size = new System.Drawing.Size(96, 37);
            this.buttonTestTrim.TabIndex = 8;
            this.buttonTestTrim.Text = "Test Trim";
            this.buttonTestTrim.UseVisualStyleBackColor = true;
            this.buttonTestTrim.Click += new System.EventHandler(this.buttonTestTrim_Click);
            // 
            // labelWebCodeResponseAfterTrimmed
            // 
            this.labelWebCodeResponseAfterTrimmed.AutoSize = true;
            this.labelWebCodeResponseAfterTrimmed.Location = new System.Drawing.Point(906, 209);
            this.labelWebCodeResponseAfterTrimmed.Name = "labelWebCodeResponseAfterTrimmed";
            this.labelWebCodeResponseAfterTrimmed.Size = new System.Drawing.Size(142, 51);
            this.labelWebCodeResponseAfterTrimmed.TabIndex = 5;
            this.labelWebCodeResponseAfterTrimmed.Text = "Web Code Response\r\nSubStringIndex17\r\nAfterTrimmed";
            // 
            // textBoxWebCodeResponseSubStringIndex17AfterTrimmed
            // 
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Location = new System.Drawing.Point(909, 263);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Name = "textBoxWebCodeResponseSubStringIndex17AfterTrimmed";
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Size = new System.Drawing.Size(827, 22);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.TabIndex = 7;
            // 
            // labelParametricUrl1
            // 
            this.labelParametricUrl1.AutoSize = true;
            this.labelParametricUrl1.Location = new System.Drawing.Point(906, 304);
            this.labelParametricUrl1.Name = "labelParametricUrl1";
            this.labelParametricUrl1.Size = new System.Drawing.Size(120, 17);
            this.labelParametricUrl1.TabIndex = 5;
            this.labelParametricUrl1.Text = "Parametric URL 1";
            // 
            // textBoxParametricUrl1
            // 
            this.textBoxParametricUrl1.Location = new System.Drawing.Point(909, 324);
            this.textBoxParametricUrl1.Name = "textBoxParametricUrl1";
            this.textBoxParametricUrl1.Size = new System.Drawing.Size(827, 22);
            this.textBoxParametricUrl1.TabIndex = 7;
            // 
            // buttonTestGoParametricUrl1
            // 
            this.buttonTestGoParametricUrl1.Location = new System.Drawing.Point(909, 366);
            this.buttonTestGoParametricUrl1.Name = "buttonTestGoParametricUrl1";
            this.buttonTestGoParametricUrl1.Size = new System.Drawing.Size(201, 32);
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
            this.tabControl1.Location = new System.Drawing.Point(33, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1767, 900);
            this.tabControl1.TabIndex = 10;
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
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1759, 871);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1759, 871);
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
            this.tabPage3.Controls.Add(this.textBoxParametricUrl1);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseSubStringLength);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseLastSubString);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseStringLength);
            this.tabPage3.Controls.Add(this.labelParametricUrl1);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseSubStringLength);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseAfterTrimmed);
            this.tabPage3.Controls.Add(this.textBoxWebCodeResponseLastSubString);
            this.tabPage3.Controls.Add(this.labelWebCodeResponseSubStringIndex17);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1759, 871);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage0
            // 
            this.tabPage0.Location = new System.Drawing.Point(4, 25);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Size = new System.Drawing.Size(1759, 752);
            this.tabPage0.TabIndex = 3;
            this.tabPage0.Text = "tabPage0";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelParametricUrl1;
        private System.Windows.Forms.TextBox textBoxParametricUrl1;
        private System.Windows.Forms.Button buttonTestGoParametricUrl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage0;
    }
}

