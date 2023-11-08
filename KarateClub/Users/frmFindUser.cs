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
    public partial class frmFindUser : Form
    {
        // Declare a Delegate
        public delegate void GetUserID(object sender, int UserID);
        // Declare an event
        public event GetUserID UserIDBack;

        public frmFindUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UserIDBack?.Invoke(this, ucUserCardWithFilter1.UserID);

            this.Close();
        }
    }
}
