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
        // Declare a Delegate
        public delegate void GetUserID(object sender, int UserID);
        // Declare an event
        public event GetUserID RefreshUserInfo;

        public frmShowUserDetails(int UserID, bool ShowPermissions = true)
        {
            InitializeComponent();

            ucUserCard1.LoadUserInfo(UserID, ShowPermissions);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RefreshUserInfo?.Invoke(this, ucUserCard1.UserID);
            this.Close();
        }
    }
}
