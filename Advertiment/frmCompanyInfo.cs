using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Advertiment
{
    public partial class frmCompanyInfo : Form
    {
        dbConnection db = new dbConnection();
        DataTable dtAdvertiseLocation;
        DataTable dtCompanyAdvertiseLocation;

        public frmCompanyInfo()
        {
            InitializeComponent();

        }
        private void btnMoreType_Click(object sender, EventArgs e)
        {
            var formPopup = new frmAdvertimentLocation();
            formPopup.Show(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private void GetAllAdvertiseLocation()
        {
            dtAdvertiseLocation = new DataTable();
            dtAdvertiseLocation = db.GetData("SelectLocatonName");
            for(int i = 0; i< dtAdvertiseLocation.Rows.Count; i++)
            {
                var id = dtAdvertiseLocation.Rows[i][0].ToString();
                bool check = false;
                CheckBox cbAdvertise = new CheckBox
                {
                    Name = "_" + id,
                    Text =dtAdvertiseLocation.Rows[i][1].ToString(),
                    Checked = check,
                };
                flpAdvertimentLocation.Controls.Add(cbAdvertise);
                cbAdvertise.CheckedChanged += checkBox_CheckedChanged;
            }

        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var cbAdvertise = sender as CheckBox;
            MessageBox.Show(cbAdvertise.Name.Replace("_", ""));
        }

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            GetAllAdvertiseLocation();
        }
    }
}
