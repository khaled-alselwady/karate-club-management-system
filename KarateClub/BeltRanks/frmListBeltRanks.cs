using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.BeltRanks
{
    public partial class frmListBeltRanks : Form
    {
        private DataTable _dtBeltRanks;

        public frmListBeltRanks()
        {
            InitializeComponent();
        }

        private void _RefreshListBeltRanks()
        {
            _dtBeltRanks = clsBeltRank.GetAllBeltRanks();
            dgvBeltRanksList.DataSource = _dtBeltRanks;

            lblNumberOfRecords.Text = dgvBeltRanksList.Rows.Count.ToString();

            if (dgvBeltRanksList.Rows.Count > 0)
            {
                dgvBeltRanksList.Columns[0].HeaderText = "Belt ID";
                dgvBeltRanksList.Columns[0].Width = 115;

                dgvBeltRanksList.Columns[1].HeaderText = "Belt Name";
                dgvBeltRanksList.Columns[1].Width = 250;

                dgvBeltRanksList.Columns[2].HeaderText = "Fees";
                dgvBeltRanksList.Columns[2].Width = 180;
            }

        }

        private void frmListBeltRanks_Load(object sender, EventArgs e)
        {
            _RefreshListBeltRanks();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditBeltRank EditBeltRank = new frmEditBeltRank((int)dgvBeltRanksList.CurrentRow.Cells["RankID"].Value);
            EditBeltRank.ShowDialog();

            _RefreshListBeltRanks();
        }

        private void dgvBeltRanksList_DoubleClick(object sender, EventArgs e)
        {
            frmEditBeltRank EditBeltRank = new frmEditBeltRank((int)dgvBeltRanksList.CurrentRow.Cells["RankID"].Value);;
            EditBeltRank.ShowDialog();

            _RefreshListBeltRanks();
        }
    }
}
