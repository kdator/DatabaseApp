namespace Lab7
{
    partial class RequestsResult
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
            this.requestResultLabel = new System.Windows.Forms.Label();
            this.requestResultDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.requestResultDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // requestResultLabel
            // 
            this.requestResultLabel.AutoSize = true;
            this.requestResultLabel.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.requestResultLabel.Location = new System.Drawing.Point(6, 9);
            this.requestResultLabel.Name = "requestResultLabel";
            this.requestResultLabel.Size = new System.Drawing.Size(105, 32);
            this.requestResultLabel.TabIndex = 0;
            this.requestResultLabel.Text = "label1";
            // 
            // requestResultDGV
            // 
            this.requestResultDGV.AllowUserToAddRows = false;
            this.requestResultDGV.AllowUserToDeleteRows = false;
            this.requestResultDGV.AllowUserToResizeColumns = false;
            this.requestResultDGV.AllowUserToResizeRows = false;
            this.requestResultDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.requestResultDGV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.requestResultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestResultDGV.Location = new System.Drawing.Point(12, 53);
            this.requestResultDGV.Name = "requestResultDGV";
            this.requestResultDGV.ReadOnly = true;
            this.requestResultDGV.RowHeadersVisible = false;
            this.requestResultDGV.RowHeadersWidth = 80;
            this.requestResultDGV.Size = new System.Drawing.Size(776, 385);
            this.requestResultDGV.TabIndex = 1;
            // 
            // RequestsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.requestResultDGV);
            this.Controls.Add(this.requestResultLabel);
            this.Name = "RequestsResult";
            this.Text = "RequestsResult";
            ((System.ComponentModel.ISupportInitialize)(this.requestResultDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label requestResultLabel;
        private System.Windows.Forms.DataGridView requestResultDGV;
    }
}