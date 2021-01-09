using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class DynamicInputParamBox : Form
    {
        private DataTable dt;
        private List<InputField> fields;
        public DynamicInputParamBox(String operType, String tableName, DataTable dataSource)
        {
            InitializeComponent();
            fields = new List<InputField>();
            this.Text = "Operation: " + operType;
            this.actionButton.Text = operType;
            this.dt = dataSource;
            this.columnNameLabel.Text = tableName;
            foreach (DataColumn column in dt.Columns) {
                InputField field = new InputField(column.ColumnName, "", true);
                this.flowLayoutPanel1.Controls.Add(field);
                this.fields.Add(field);
            }
            this.flowLayoutPanel1.Controls.Add(this.actionButton);
        }

        public DynamicInputParamBox(String operType, String tableName, DataTable dataSource, List<String> primaryKeys, DataRow defaultValue) {
            InitializeComponent();
            fields = new List<InputField>();
            this.Text = "Operation: " + operType;
            this.actionButton.Text = operType;
            this.dt = dataSource;
            this.columnNameLabel.Text = tableName;
            foreach (DataColumn column in dt.Columns)
            {
                String value = defaultValue[column].ToString();
                bool isActiveField = primaryKeys.Contains(column.ColumnName) ? false : true;
                InputField field = new InputField(column.ColumnName, value, isActiveField);
                this.flowLayoutPanel1.Controls.Add(field);
                this.fields.Add(field);
            }
            this.flowLayoutPanel1.Controls.Add(this.actionButton);
        }

        public List<String> getFieldsData() {
            var data = new List<String>();
            foreach (InputField field in fields)
                data.Add(field.getTextBoxData());
            return data;
        }

        private bool ParseArgument(String value, Type type) {
            if (type == typeof(int))
            {
                int result;
                return int.TryParse(value, out result);
            }
            else if (type == typeof(double))
            {
                double result;
                return double.TryParse(value, out result);
            }
            else if (type == typeof(DateTime))
            {
                DateTime result;
                return DateTime.TryParse(value, out result);
            }
            else if (type == typeof(short)) {
                short result;
                return short.TryParse(value, out result);
            }
            return true;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataColumn column in dt.Columns) {
                if (fields[i].getTextBoxData() == "") {
                    MessageBox.Show(column.ColumnName + "'s value field can't be empty.",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                bool parseResult = ParseArgument(fields[i].getTextBoxData(), column.DataType);
                if (!parseResult) {
                    MessageBox.Show(column.ColumnName + "'s value field doesn't match with " + column.ColumnName + " type.",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                i++;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    class InputField : GroupBox
    {
        private TextBox textBox;
        public InputField(String label, String value, bool isActive) {
            textBox = new TextBox();
            textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox.Location = new System.Drawing.Point(5, 29);
            textBox.Size = new System.Drawing.Size(310, 49);
            textBox.TabIndex = 1;
            textBox.Text = value;
            textBox.Enabled = isActive;

            this.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Controls.Add(textBox);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Location = new System.Drawing.Point(3, 32);
            this.Size = new System.Drawing.Size(320, 67);
            this.TabIndex = 1;
            this.TabStop = false;
            this.Text = label;
        }

        public String getTextBoxData() {
            return textBox.Text;
        }
    }
}
