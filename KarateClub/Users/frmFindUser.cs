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
        public Action<int?> GetUserID;

        public frmFindUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GetUserID?.Invoke(ucUserCardWithFilter1.UserID);

            this.Close();
        }
    }
}
