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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed = new System.Windows.Forms.TextBox();
            this.labelParametricUrl1 = new System.Windows.Forms.Label();
            this.textBoxParametricUrl1 = new System.Windows.Forms.TextBox();
            this.buttonTestGoParametricUrl1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(12, 11);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "TEST";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1049, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(821, 238);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // textBoxUrlToGo
            // 
            this.textBoxUrlToGo.Location = new System.Drawing.Point(12, 64);
            this.textBoxUrlToGo.Multiline = true;
            this.textBoxUrlToGo.Name = "textBoxUrlToGo";
            this.textBoxUrlToGo.Size = new System.Drawing.Size(1020, 22);
            this.textBoxUrlToGo.TabIndex = 2;
            // 
            // textBoxUrlResponse
            // 
            this.textBoxUrlResponse.Location = new System.Drawing.Point(12, 115);
            this.textBoxUrlResponse.Multiline = true;
            this.textBoxUrlResponse.Name = "textBoxUrlResponse";
            this.textBoxUrlResponse.Size = new System.Drawing.Size(1020, 135);
            this.textBoxUrlResponse.TabIndex = 3;
            // 
            // textBoxWebCodeResponse
            // 
            this.textBoxWebCodeResponse.Location = new System.Drawing.Point(12, 280);
            this.textBoxWebCodeResponse.Multiline = true;
            this.textBoxWebCodeResponse.Name = "textBoxWebCodeResponse";
            this.textBoxWebCodeResponse.Size = new System.Drawing.Size(1020, 296);
            this.textBoxWebCodeResponse.TabIndex = 4;
            // 
            // labelUrlToGo
            // 
            this.labelUrlToGo.AutoSize = true;
            this.labelUrlToGo.Location = new System.Drawing.Point(13, 45);
            this.labelUrlToGo.Name = "labelUrlToGo";
            this.labelUrlToGo.Size = new System.Drawing.Size(72, 17);
            this.labelUrlToGo.TabIndex = 5;
            this.labelUrlToGo.Text = "URL to go";
            // 
            // labelUrlResponse
            // 
            this.labelUrlResponse.AutoSize = true;
            this.labelUrlResponse.Location = new System.Drawing.Point(12, 95);
            this.labelUrlResponse.Name = "labelUrlResponse";
            this.labelUrlResponse.Size = new System.Drawing.Size(104, 17);
            this.labelUrlResponse.TabIndex = 5;
            this.labelUrlResponse.Text = "URL Response";
            // 
            // labelWebCodeResponse
            // 
            this.labelWebCodeResponse.AutoSize = true;
            this.labelWebCodeResponse.Location = new System.Drawing.Point(13, 261);
            this.labelWebCodeResponse.Name = "labelWebCodeResponse";
            this.labelWebCodeResponse.Size = new System.Drawing.Size(142, 17);
            this.labelWebCodeResponse.TabIndex = 5;
            this.labelWebCodeResponse.Text = "Web Code Response";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 635);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(748, 316);
            this.dataGridView1.TabIndex = 6;
            // 
            // labelWebCodeResponseStringLength
            // 
            this.labelWebCodeResponseStringLength.AutoSize = true;
            this.labelWebCodeResponseStringLength.Location = new System.Drawing.Point(13, 589);
            this.labelWebCodeResponseStringLength.Name = "labelWebCodeResponseStringLength";
            this.labelWebCodeResponseStringLength.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseStringLength.TabIndex = 5;
            this.labelWebCodeResponseStringLength.Text = "Web Code Response\r\nString Length";
            // 
            // textBoxWebCodeResponseStringLength
            // 
            this.textBoxWebCodeResponseStringLength.Location = new System.Drawing.Point(159, 589);
            this.textBoxWebCodeResponseStringLength.Name = "textBoxWebCodeResponseStringLength";
            this.textBoxWebCodeResponseStringLength.Size = new System.Drawing.Size(66, 22);
            this.textBoxWebCodeResponseStringLength.TabIndex = 7;
            // 
            // textBoxWebCodeResponseSubStringLength
            // 
            this.textBoxWebCodeResponseSubStringLength.Location = new System.Drawing.Point(386, 589);
            this.textBoxWebCodeResponseSubStringLength.Name = "textBoxWebCodeResponseSubStringLength";
            this.textBoxWebCodeResponseSubStringLength.Size = new System.Drawing.Size(66, 22);
            this.textBoxWebCodeResponseSubStringLength.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringLength
            // 
            this.labelWebCodeResponseSubStringLength.AutoSize = true;
            this.labelWebCodeResponseSubStringLength.Location = new System.Drawing.Point(238, 589);
            this.labelWebCodeResponseSubStringLength.Name = "labelWebCodeResponseSubStringLength";
            this.labelWebCodeResponseSubStringLength.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseSubStringLength.TabIndex = 5;
            this.labelWebCodeResponseSubStringLength.Text = "Web Code Response\r\nSubString Length";
            // 
            // labelWebCodeResponseLastSubString
            // 
            this.labelWebCodeResponseLastSubString.AutoSize = true;
            this.labelWebCodeResponseLastSubString.Location = new System.Drawing.Point(471, 589);
            this.labelWebCodeResponseLastSubString.Name = "labelWebCodeResponseLastSubString";
            this.labelWebCodeResponseLastSubString.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseLastSubString.TabIndex = 5;
            this.labelWebCodeResponseLastSubString.Text = "Web Code Response\r\nLast SubString";
            // 
            // textBoxWebCodeResponseLastSubString
            // 
            this.textBoxWebCodeResponseLastSubString.Location = new System.Drawing.Point(619, 589);
            this.textBoxWebCodeResponseLastSubString.Name = "textBoxWebCodeResponseLastSubString";
            this.textBoxWebCodeResponseLastSubString.Size = new System.Drawing.Size(413, 22);
            this.textBoxWebCodeResponseLastSubString.TabIndex = 7;
            // 
            // labelWebCodeResponseSubStringIndex17
            // 
            this.labelWebCodeResponseSubStringIndex17.AutoSize = true;
            this.labelWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(767, 678);
            this.labelWebCodeResponseSubStringIndex17.Name = "labelWebCodeResponseSubStringIndex17";
            this.labelWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(142, 34);
            this.labelWebCodeResponseSubStringIndex17.TabIndex = 5;
            this.labelWebCodeResponseSubStringIndex17.Text = "Web Code Response\r\nSubStringIndex17";
            // 
            // textBoxWebCodeResponseSubStringIndex17
            // 
            this.textBoxWebCodeResponseSubStringIndex17.Location = new System.Drawing.Point(915, 678);
            this.textBoxWebCodeResponseSubStringIndex17.Name = "textBoxWebCodeResponseSubStringIndex17";
            this.textBoxWebCodeResponseSubStringIndex17.Size = new System.Drawing.Size(326, 22);
            this.textBoxWebCodeResponseSubStringIndex17.TabIndex = 7;
            // 
            // buttonTestTrim
            // 
            this.buttonTestTrim.Location = new System.Drawing.Point(915, 635);
            this.buttonTestTrim.Name = "buttonTestTrim";
            this.buttonTestTrim.Size = new System.Drawing.Size(96, 37);
            this.buttonTestTrim.TabIndex = 8;
            this.buttonTestTrim.Text = "Test Trim";
            this.buttonTestTrim.UseVisualStyleBackColor = true;
            this.buttonTestTrim.Click += new System.EventHandler(this.buttonTestTrim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 730);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "Web Code Response\r\nSubStringIndex17\r\nAfterTrim";
            // 
            // textBoxWebCodeResponseSubStringIndex17AfterTrimmed
            // 
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Location = new System.Drawing.Point(915, 730);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Name = "textBoxWebCodeResponseSubStringIndex17AfterTrimmed";
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.Size = new System.Drawing.Size(326, 22);
            this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed.TabIndex = 7;
            // 
            // labelParametricUrl1
            // 
            this.labelParametricUrl1.AutoSize = true;
            this.labelParametricUrl1.Location = new System.Drawing.Point(767, 786);
            this.labelParametricUrl1.Name = "labelParametricUrl1";
            this.labelParametricUrl1.Size = new System.Drawing.Size(120, 17);
            this.labelParametricUrl1.TabIndex = 5;
            this.labelParametricUrl1.Text = "Parametric URL 1";
            // 
            // textBoxParametricUrl1
            // 
            this.textBoxParametricUrl1.Location = new System.Drawing.Point(915, 781);
            this.textBoxParametricUrl1.Name = "textBoxParametricUrl1";
            this.textBoxParametricUrl1.Size = new System.Drawing.Size(326, 22);
            this.textBoxParametricUrl1.TabIndex = 7;
            // 
            // buttonTestGoParametricUrl1
            // 
            this.buttonTestGoParametricUrl1.Location = new System.Drawing.Point(915, 823);
            this.buttonTestGoParametricUrl1.Name = "buttonTestGoParametricUrl1";
            this.buttonTestGoParametricUrl1.Size = new System.Drawing.Size(201, 32);
            this.buttonTestGoParametricUrl1.TabIndex = 9;
            this.buttonTestGoParametricUrl1.Text = "Test Go Parametric URL 1";
            this.buttonTestGoParametricUrl1.UseVisualStyleBackColor = true;
            this.buttonTestGoParametricUrl1.Click += new System.EventHandler(this.buttonTestGoParametricUrl1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1049, 294);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(821, 282);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(813, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(813, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonTestGoParametricUrl1);
            this.Controls.Add(this.buttonTestTrim);
            this.Controls.Add(this.textBoxParametricUrl1);
            this.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17AfterTrimmed);
            this.Controls.Add(this.textBoxWebCodeResponseSubStringIndex17);
            this.Controls.Add(this.textBoxWebCodeResponseLastSubString);
            this.Controls.Add(this.textBoxWebCodeResponseSubStringLength);
            this.Controls.Add(this.textBoxWebCodeResponseStringLength);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelParametricUrl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWebCodeResponseSubStringIndex17);
            this.Controls.Add(this.labelWebCodeResponseLastSubString);
            this.Controls.Add(this.labelWebCodeResponseSubStringLength);
            this.Controls.Add(this.labelWebCodeResponseStringLength);
            this.Controls.Add(this.labelWebCodeResponse);
            this.Controls.Add(this.labelUrlResponse);
            this.Controls.Add(this.labelUrlToGo);
            this.Controls.Add(this.textBoxWebCodeResponse);
            this.Controls.Add(this.textBoxUrlResponse);
            this.Controls.Add(this.textBoxUrlToGo);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.buttonTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWebCodeResponseSubStringIndex17AfterTrimmed;
        private System.Windows.Forms.Label labelParametricUrl1;
        private System.Windows.Forms.TextBox textBoxParametricUrl1;
        private System.Windows.Forms.Button buttonTestGoParametricUrl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

