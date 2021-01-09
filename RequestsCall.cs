using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab7
{
    public partial class RequestsCall : Form
    {
        private String selectedItem;
        public RequestsCall(List<String> requests)
        {
            InitializeComponent();
            requestsListBox.Items.Clear();
            foreach (String request in requests) {
                requestsListBox.Items.Add(request);
            }
        }

        public String GetSelected()
        {
            return selectedItem;
        }
        private void completeButton_Click(object sender, EventArgs e)
        {
            selectedItem = requestsListBox.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
