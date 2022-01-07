using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advertiment
{
    public partial class frmAdvertimentLocation : Form
    {
        dbConnection db = new dbConnection();

        public frmAdvertimentLocation()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtLocationName.Text = string.Empty;
            txtDiscription.Text = string.Empty;
            txtLocationName.Focus();
            GetNewID(); 
            GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string LocationName = txtLocationName.Text;
            //string Discription =txtDiscription.Text;
            try
            {              
                db.ExecuteQueries($"exec InsertAvertimentLocation '{txtLocationName.Text}','{txtDiscription.Text}'");
                Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAdvertimentLocation_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void GetNewID()
        {
            txtLocationId.Text = (db.GetLastID("exec selectIdLocation") + 1).ToString();
        }

        private void GetData()
        {
            dgAdvLocation.DataSource = db.GetData("exec GetLocation");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            db.ExecuteQueries($"exec EditLocation {Convert.ToInt32(txtLocationId.Text)},'{txtLocationName.Text}','{txtDiscription.Text}'");
            Clear();
        }

        private void dgAdvLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgAdvLocation.CurrentRow;
            txtLocationId.Text = dr.Cells["locationId"].Value.ToString();
            txtLocationName.Text = dr.Cells["locationName"].Value.ToString();
            txtDiscription.Text = dr.Cells["Discription"].Value.ToString();  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.ExecuteQueries($"exec DeleteLocation {Convert.ToInt32(txtLocationId.Text)}");
            Clear();
        }
    }
}
