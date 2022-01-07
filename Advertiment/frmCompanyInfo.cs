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
        public frmCompanyInfo()
        {
            InitializeComponent();
        }


    }
}
