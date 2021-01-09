namespace Lab7
{
    partial class InputParam
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
            this.inputDataTextBox = new System.Windows.Forms.TextBox();
            this.inputColumnName = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputDataTextBox
            // 
            this.inputDataTextBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.inputDataTextBox.Location = new System.Drawing.Point(12, 70);
            this.inputDataTextBox.Multiline = true;
            this.inputDataTextBox.Name = "inputDataTextBox";
            this.inputDataTextBox.Size = new System.Drawing.Size(311, 45);
            this.inputDataTextBox.TabIndex = 0;
            // 
            // inputColumnName
            // 
            this.inputColumnName.AutoSize = true;
            this.inputColumnName.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold);
            this.inputColumnName.Location = new System.Drawing.Point(6, 26);
            this.inputColumnName.Name = "inputColumnName";
            this.inputColumnName.Size = new System.Drawing.Size(105, 32);
            this.inputColumnName.TabIndex = 1;
            this.inputColumnName.Text = "label1";
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.submitButton.Location = new System.Drawing.Point(101, 121);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(118, 51);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // InputParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(335, 180);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.inputColumnName);
            this.Controls.Add(this.inputDataTextBox);
            this.Name = "InputParam";
            this.Text = "Input Parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputDataTextBox;
        private System.Windows.Forms.Label inputColumnName;
        private System.Windows.Forms.Button submitButton;
    }
}