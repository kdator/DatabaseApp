using System;
using System.Data;
using System.Windows.Forms;

namespace Lab7
{
    public partial class RequestsResult : Form
    {
        public RequestsResult(String selectedItem, DataTable dt)
        {
            InitializeComponent();
            requestResultLabel.Text = selectedItem;
            requestResultDGV.DataSource = dt;
            this.Text += ": " + selectedItem;
        }
    }
}
