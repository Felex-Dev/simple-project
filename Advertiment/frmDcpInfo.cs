using System;
using System.Windows.Forms;

namespace Advertiment
{
    public partial class frmDcpInfo : Form
    {
        dbConnection db = new dbConnection();
        public frmDcpInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.ExecuteQueries($"");
            Clear();     
        }



        private void Clear()
        {
            txtDcpName.Text = string.Empty;
            txtDuration.Text = string.Empty;
            cbComName.Text = string.Empty;
            cbStatus.Text = string.Empty;
            txtDcpName.Focus();
        }
    }
}
