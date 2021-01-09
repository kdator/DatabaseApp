namespace Lab7
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.currentTableName = new System.Windows.Forms.Label();
            this.requestsButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.proceduresButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablesListBox
            // 
            this.tablesListBox.BackColor = System.Drawing.Color.White;
            this.tablesListBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 19;
            this.tablesListBox.Location = new System.Drawing.Point(12, 12);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(234, 422);
            this.tablesListBox.TabIndex = 2;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 69);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(877, 365);
            this.dataGridView1.TabIndex = 4;
            // 
            // currentTableName
            // 
            this.currentTableName.AutoSize = true;
            this.currentTableName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTableName.Location = new System.Drawing.Point(262, 24);
            this.currentTableName.Name = "currentTableName";
            this.currentTableName.Size = new System.Drawing.Size(235, 29);
            this.currentTableName.TabIndex = 5;
            this.currentTableName.Text = "currentTableName";
            // 
            // requestsButton
            // 
            this.requestsButton.BackColor = System.Drawing.Color.White;
            this.requestsButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.requestsButton.Location = new System.Drawing.Point(607, 12);
            this.requestsButton.Name = "requestsButton";
            this.requestsButton.Size = new System.Drawing.Size(118, 51);
            this.requestsButton.TabIndex = 6;
            this.requestsButton.Text = "REQUESTS";
            this.requestsButton.UseVisualStyleBackColor = false;
            this.requestsButton.Click += new System.EventHandler(this.requestsButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.BackColor = System.Drawing.Color.White;
            this.insertButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.insertButton.Location = new System.Drawing.Point(853, 12);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(92, 51);
            this.insertButton.TabIndex = 7;
            this.insertButton.Text = "ADD";
            this.insertButton.UseVisualStyleBackColor = false;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.White;
            this.updateButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.updateButton.Location = new System.Drawing.Point(951, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(92, 51);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "UPDATE";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.White;
            this.deleteButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(1049, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(92, 51);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // proceduresButton
            // 
            this.proceduresButton.BackColor = System.Drawing.Color.White;
            this.proceduresButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.proceduresButton.Location = new System.Drawing.Point(731, 12);
            this.proceduresButton.Name = "proceduresButton";
            this.proceduresButton.Size = new System.Drawing.Size(116, 51);
            this.proceduresButton.TabIndex = 10;
            this.proceduresButton.Text = "PROCEDURES";
            this.proceduresButton.UseVisualStyleBackColor = false;
            this.proceduresButton.Click += new System.EventHandler(this.proceduresButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1153, 450);
            this.Controls.Add(this.proceduresButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.requestsButton);
            this.Controls.Add(this.currentTableName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tablesListBox);
            this.Name = "MainWindow";
            this.Text = "Database";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label currentTableName;
        private System.Windows.Forms.Button requestsButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button proceduresButton;
    }
}

