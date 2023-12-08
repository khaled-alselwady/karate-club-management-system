using KarateClub.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Users
{
    public partial class frmShowUserDetails : Form
    {
        public frmShowUserDetails(int? UserID, bool ShowPermissions = true)
        {
            InitializeComponent();

            ucUserCard1.LoadUserInfo(UserID, ShowPermissions);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
