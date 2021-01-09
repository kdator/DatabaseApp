namespace Lab7
{
    partial class RequestsCall
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
            this.requestsListBox = new System.Windows.Forms.ListBox();
            this.completeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // requestsListBox
            // 
            this.requestsListBox.BackColor = System.Drawing.Color.White;
            this.requestsListBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.requestsListBox.FormattingEnabled = true;
            this.requestsListBox.ItemHeight = 19;
            this.requestsListBox.Location = new System.Drawing.Point(12, 24);
            this.requestsListBox.Name = "requestsListBox";
            this.requestsListBox.Size = new System.Drawing.Size(293, 346);
            this.requestsListBox.TabIndex = 0;
            // 
            // completeButton
            // 
            this.completeButton.BackColor = System.Drawing.Color.White;
            this.completeButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.completeButton.Location = new System.Drawing.Point(92, 388);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(129, 53);
            this.completeButton.TabIndex = 1;
            this.completeButton.Text = "Complete";
            this.completeButton.UseVisualStyleBackColor = false;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // RequestsCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.requestsListBox);
            this.Name = "RequestsCall";
            this.Text = "Requests";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox requestsListBox;
        private System.Windows.Forms.Button completeButton;
    }
}