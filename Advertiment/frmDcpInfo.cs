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
            db.ExecuteQueries($"InsertDcp '{txtDcpName.Text}','{dtAdvStart.Value.ToString("yyyy-MM-dd")}','{txtDuration.Text}','{Convert.ToInt32(cbComName.SelectedValue)}','{cbStatus.Text}'");
            Clear();     
        }

        private void GetDataGriedView()
        {
            dgDcp.DataSource = db.GetData("GetDcp");
        }
        private void GetCompanyName()
        {
            cbComName.DataSource = db.GetName($"exec SelectCompanyName").Tables[0];
            cbComName.ValueMember = "comId";
            cbComName.DisplayMember = "comName";
            
        }
        private void Clear()
        {
            txtDcpName.Text = string.Empty;
            txtDuration.Text = string.Empty;
            
            cbStatus.Text = string.Empty;
            txtDcpName.Focus();
            GetDataGriedView();
        }

        private void frmDcpInfo_Activated(object sender, EventArgs e)
        {
            GetCompanyName();
            Clear();
            


        }
        int id;
        private void dgDcp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgDcp.CurrentRow;
            id = (int)dr.Cells["dcpId"].Value;
            txtDcpName.Text = dr.Cells["dcpName"].Value.ToString();
            dtAdvStart.Value = Convert.ToDateTime(dr.Cells["screenStart"].Value);
            txtDuration.Text = dr.Cells["duration"].Value.ToString();
            cbComName.SelectedValue = dr.Cells["comId"].Value;
            cbStatus.Text = dr.Cells["status"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            db.ExecuteQueries($"EditDcp '{id}','{txtDcpName.Text}','{dtAdvStart.Value.ToString("yyyy-MMM-dd")}','{txtDuration.Text}','{cbComName.SelectedValue}','{cbStatus.Text}'");
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db.ExecuteQueries($"DeleteDcp {id}");
            }

        }

        private void btnMoreType_Click(object sender, EventArgs e)
        {
            var formPopup = new frmCompanyInfo();
            formPopup.Show(this);
        }
    }
}
