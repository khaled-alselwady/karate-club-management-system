using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Members
{
    public partial class frmFindMember : Form
    {
        // Declare a Delegate
        public delegate void GetMemberID(object sender, int MemberID);
        // Declare an event
        public event GetMemberID MemberIDBack;

        public frmFindMember()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MemberIDBack?.Invoke(this, ucMemberCardWithFilter1.MemberID);

            this.Close();
        }

        private void frmFindMember_Activated(object sender, EventArgs e)
        {
            ucMemberCardWithFilter1.FilterFocus();
        }
    }
}
