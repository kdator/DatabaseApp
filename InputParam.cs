using System;
using System.Windows.Forms;

namespace Lab7
{
    public partial class InputParam : Form
    {
        public InputParam(String param)
        {
            InitializeComponent();
            inputColumnName.Text = param;
        }

        public String GetInputData() {
            return inputDataTextBox.Text;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
