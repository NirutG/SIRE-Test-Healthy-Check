namespace Test_InputCsvDataTable
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
            this.labelCsvData = new System.Windows.Forms.Label();
            this.textBoxCsvData = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_IndexOfCsvDataRow = new System.Windows.Forms.Label();
            this.textBoxIndexOfCsvDataRow = new System.Windows.Forms.TextBox();
            this.textBoxIndexOfCsvDataColumn = new System.Windows.Forms.TextBox();
            this.label_IndexOfCsvDataColumn = new System.Windows.Forms.Label();
            this.labelDataGridView2Row = new System.Windows.Forms.Label();
            this.textBoxDataGridView2Row = new System.Windows.Forms.TextBox();
            this.labelDataGridView2Column = new System.Windows.Forms.Label();
            this.textBoxDataGridView2Column = new System.Windows.Forms.TextBox();
            this.textBoxDataGridView2Value = new System.Windows.Forms.TextBox();
            this.buttonCheckDataInDataGridView2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(45, 27);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "button1";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelCsvData
            // 
            this.labelCsvData.AutoSize = true;
            this.labelCsvData.Location = new System.Drawing.Point(46, 72);
            this.labelCsvData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCsvData.Name = "labelCsvData";
            this.labelCsvData.Size = new System.Drawing.Size(54, 13);
            this.labelCsvData.TabIndex = 7;
            this.labelCsvData.Text = "CSV Data";
            // 
            // textBoxCsvData
            // 
            this.textBoxCsvData.Location = new System.Drawing.Point(45, 92);
            this.textBoxCsvData.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCsvData.MaxLength = 900000000;
            this.textBoxCsvData.Multiline = true;
            this.textBoxCsvData.Name = "textBoxCsvData";
            this.textBoxCsvData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCsvData.Size = new System.Drawing.Size(739, 603);
            this.textBoxCsvData.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(806, 138);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(669, 489);
            this.dataGridView2.TabIndex = 8;
            // 
            // label_IndexOfCsvDataRow
            // 
            this.label_IndexOfCsvDataRow.AutoSize = true;
            this.label_IndexOfCsvDataRow.Location = new System.Drawing.Point(803, 95);
            this.label_IndexOfCsvDataRow.Name = "label_IndexOfCsvDataRow";
            this.label_IndexOfCsvDataRow.Size = new System.Drawing.Size(129, 13);
            this.label_IndexOfCsvDataRow.TabIndex = 9;
            this.label_IndexOfCsvDataRow.Text = "Index of CSV Data Row =";
            // 
            // textBoxIndexOfCsvDataRow
            // 
            this.textBoxIndexOfCsvDataRow.Location = new System.Drawing.Point(937, 92);
            this.textBoxIndexOfCsvDataRow.Name = "textBoxIndexOfCsvDataRow";
            this.textBoxIndexOfCsvDataRow.Size = new System.Drawing.Size(157, 20);
            this.textBoxIndexOfCsvDataRow.TabIndex = 10;
            // 
            // textBoxIndexOfCsvDataColumn
            // 
            this.textBoxIndexOfCsvDataColumn.Location = new System.Drawing.Point(1262, 92);
            this.textBoxIndexOfCsvDataColumn.Name = "textBoxIndexOfCsvDataColumn";
            this.textBoxIndexOfCsvDataColumn.Size = new System.Drawing.Size(157, 20);
            this.textBoxIndexOfCsvDataColumn.TabIndex = 12;
            // 
            // label_IndexOfCsvDataColumn
            // 
            this.label_IndexOfCsvDataColumn.AutoSize = true;
            this.label_IndexOfCsvDataColumn.Location = new System.Drawing.Point(1114, 95);
            this.label_IndexOfCsvDataColumn.Name = "label_IndexOfCsvDataColumn";
            this.label_IndexOfCsvDataColumn.Size = new System.Drawing.Size(142, 13);
            this.label_IndexOfCsvDataColumn.TabIndex = 11;
            this.label_IndexOfCsvDataColumn.Text = "Index of CSV Data Column =";
            // 
            // labelDataGridView2Row
            // 
            this.labelDataGridView2Row.AutoSize = true;
            this.labelDataGridView2Row.Location = new System.Drawing.Point(803, 647);
            this.labelDataGridView2Row.Name = "labelDataGridView2Row";
            this.labelDataGridView2Row.Size = new System.Drawing.Size(107, 13);
            this.labelDataGridView2Row.TabIndex = 9;
            this.labelDataGridView2Row.Text = "dataGridView2Row =";
            // 
            // textBoxDataGridView2Row
            // 
            this.textBoxDataGridView2Row.Location = new System.Drawing.Point(937, 644);
            this.textBoxDataGridView2Row.Name = "textBoxDataGridView2Row";
            this.textBoxDataGridView2Row.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Row.TabIndex = 10;
            // 
            // labelDataGridView2Column
            // 
            this.labelDataGridView2Column.AutoSize = true;
            this.labelDataGridView2Column.Location = new System.Drawing.Point(1114, 647);
            this.labelDataGridView2Column.Name = "labelDataGridView2Column";
            this.labelDataGridView2Column.Size = new System.Drawing.Size(120, 13);
            this.labelDataGridView2Column.TabIndex = 11;
            this.labelDataGridView2Column.Text = "dataGridView2Column =";
            // 
            // textBoxDataGridView2Column
            // 
            this.textBoxDataGridView2Column.Location = new System.Drawing.Point(1250, 644);
            this.textBoxDataGridView2Column.Name = "textBoxDataGridView2Column";
            this.textBoxDataGridView2Column.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Column.TabIndex = 12;
            // 
            // textBoxDataGridView2Value
            // 
            this.textBoxDataGridView2Value.Location = new System.Drawing.Point(937, 698);
            this.textBoxDataGridView2Value.Name = "textBoxDataGridView2Value";
            this.textBoxDataGridView2Value.Size = new System.Drawing.Size(157, 20);
            this.textBoxDataGridView2Value.TabIndex = 10;
            // 
            // buttonCheckDataInDataGridView2
            // 
            this.buttonCheckDataInDataGridView2.Location = new System.Drawing.Point(806, 684);
            this.buttonCheckDataInDataGridView2.Name = "buttonCheckDataInDataGridView2";
            this.buttonCheckDataInDataGridView2.Size = new System.Drawing.Size(125, 47);
            this.buttonCheckDataInDataGridView2.TabIndex = 13;
            this.buttonCheckDataInDataGridView2.Text = "Check Data in DataGridView2";
            this.buttonCheckDataInDataGridView2.UseVisualStyleBackColor = true;
            this.buttonCheckDataInDataGridView2.Click += new System.EventHandler(this.buttonCheckDataInDataGridView2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 807);
            this.Controls.Add(this.buttonCheckDataInDataGridView2);
            this.Controls.Add(this.textBoxDataGridView2Column);
            this.Controls.Add(this.textBoxIndexOfCsvDataColumn);
            this.Controls.Add(this.labelDataGridView2Column);
            this.Controls.Add(this.label_IndexOfCsvDataColumn);
            this.Controls.Add(this.textBoxDataGridView2Value);
            this.Controls.Add(this.textBoxDataGridView2Row);
            this.Controls.Add(this.textBoxIndexOfCsvDataRow);
            this.Controls.Add(this.labelDataGridView2Row);
            this.Controls.Add(this.label_IndexOfCsvDataRow);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.labelCsvData);
            this.Controls.Add(this.textBoxCsvData);
            this.Controls.Add(this.buttonTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelCsvData;
        private System.Windows.Forms.TextBox textBoxCsvData;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label_IndexOfCsvDataRow;
        private System.Windows.Forms.TextBox textBoxIndexOfCsvDataRow;
        private System.Windows.Forms.TextBox textBoxIndexOfCsvDataColumn;
        private System.Windows.Forms.Label label_IndexOfCsvDataColumn;
        private System.Windows.Forms.Label labelDataGridView2Row;
        private System.Windows.Forms.TextBox textBoxDataGridView2Row;
        private System.Windows.Forms.Label labelDataGridView2Column;
        private System.Windows.Forms.TextBox textBoxDataGridView2Column;
        private System.Windows.Forms.TextBox textBoxDataGridView2Value;
        private System.Windows.Forms.Button buttonCheckDataInDataGridView2;
    }
}

