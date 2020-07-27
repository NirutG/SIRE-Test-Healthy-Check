namespace Test_find_WordIndex
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
            this.textBoxWebCodeResponse = new System.Windows.Forms.TextBox();
            this.labelWebCodeResponse = new System.Windows.Forms.Label();
            this.labelWordFinding = new System.Windows.Forms.Label();
            this.textBoxWordFinding = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxWebCodeResponse
            // 
            this.textBoxWebCodeResponse.Location = new System.Drawing.Point(25, 24);
            this.textBoxWebCodeResponse.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxWebCodeResponse.Multiline = true;
            this.textBoxWebCodeResponse.Name = "textBoxWebCodeResponse";
            this.textBoxWebCodeResponse.Size = new System.Drawing.Size(673, 254);
            this.textBoxWebCodeResponse.TabIndex = 5;
            // 
            // labelWebCodeResponse
            // 
            this.labelWebCodeResponse.AutoSize = true;
            this.labelWebCodeResponse.Location = new System.Drawing.Point(22, 9);
            this.labelWebCodeResponse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWebCodeResponse.Name = "labelWebCodeResponse";
            this.labelWebCodeResponse.Size = new System.Drawing.Size(109, 13);
            this.labelWebCodeResponse.TabIndex = 6;
            this.labelWebCodeResponse.Text = "Web Code Response";
            // 
            // labelWordFinding
            // 
            this.labelWordFinding.AutoSize = true;
            this.labelWordFinding.Location = new System.Drawing.Point(25, 319);
            this.labelWordFinding.Name = "labelWordFinding";
            this.labelWordFinding.Size = new System.Drawing.Size(70, 13);
            this.labelWordFinding.TabIndex = 17;
            this.labelWordFinding.Text = "Word Finding";
            // 
            // textBoxWordFinding
            // 
            this.textBoxWordFinding.Location = new System.Drawing.Point(25, 339);
            this.textBoxWordFinding.Multiline = true;
            this.textBoxWordFinding.Name = "textBoxWordFinding";
            this.textBoxWordFinding.Size = new System.Drawing.Size(702, 145);
            this.textBoxWordFinding.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 626);
            this.Controls.Add(this.labelWordFinding);
            this.Controls.Add(this.textBoxWordFinding);
            this.Controls.Add(this.labelWebCodeResponse);
            this.Controls.Add(this.textBoxWebCodeResponse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxWebCodeResponse;
        private System.Windows.Forms.Label labelWebCodeResponse;
        private System.Windows.Forms.Label labelWordFinding;
        private System.Windows.Forms.TextBox textBoxWordFinding;
    }
}

