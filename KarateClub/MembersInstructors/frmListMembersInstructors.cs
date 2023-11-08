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
using static KarateClub_Business.clsPerson;

namespace KarateClub.MembersInstructors
{
    public partial class frmListMembersInstructors : Form
    {
        private DataTable _dtAllMembersInstructors;

        public frmListMembersInstructors()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Members-Instructors ID":
                    return "MemberInstructorID";

                case "Member Name":
                    return "MemberName";

                case "Instructor Name":
                    return "InstructorName";

                default:
                    return "None";
            }
        }

        private void _RefreshMembersInstructorsList()
        {
            _dtAllMembersInstructors = clsMemberInstructor.GetAllMemberInstructors();
            dgvMembersInstructorsList.DataSource = _dtAllMembersInstructors;
            lblNumberOfRecords.Text = dgvMembersInstructorsList.Rows.Count.ToString();

            if (dgvMembersInstructorsList.Rows.Count > 0)
            {
                dgvMembersInstructorsList.Columns[0].HeaderText = "Members-Instructors ID";
                dgvMembersInstructorsList.Columns[0].Width = 210;

                dgvMembersInstructorsList.Columns[1].HeaderText = "Member Name";
                dgvMembersInstructorsList.Columns[1].Width = 190;

                dgvMembersInstructorsList.Columns[2].HeaderText = "Instructor Name";
                dgvMembersInstructorsList.Columns[2].Width = 190;

                dgvMembersInstructorsList.Columns[3].HeaderText = "Assign Date";
                dgvMembersInstructorsList.Columns[3].Width = 160;
            }
        }

        private int _GetMembersInstructorsIDFromDGV()
        {
            return (int)dgvMembersInstructorsList.CurrentRow.Cells["MemberInstructorID"].Value;
        }

        private void frmListMembersInstructors_Load(object sender, EventArgs e)
        {
            _RefreshMembersInstructorsList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllMembersInstructors.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllMembersInstructors.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvMembersInstructorsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Members-Instructors ID")
            {
                // search with numbers
                _dtAllMembersInstructors.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllMembersInstructors.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvMembersInstructorsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Members-Instructors ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void ShowDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowMembersInstructorsDetails ShowDetails = new frmShowMembersInstructorsDetails(_GetMembersInstructorsIDFromDGV());
            ShowDetails.ShowDialog();

            _RefreshMembersInstructorsList();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMembersInstructors AddMembersInstructors = new frmAddEditMembersInstructors();
            AddMembersInstructors.MembersInstructorsIDBack += RefreshList;
            AddMembersInstructors.Show();
        }

        private void RefreshList(object sender, int MembersInstructorsID)
        {
            _RefreshMembersInstructorsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMembersInstructors EditMembersInstructors = new frmAddEditMembersInstructors(_GetMembersInstructorsIDFromDGV());
            EditMembersInstructors.MembersInstructorsIDBack += RefreshList;
            EditMembersInstructors.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsMemberInstructor.DeleteMemberInstructor(_GetMembersInstructorsIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshMembersInstructorsList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddEditMembersInstructors AddMembersInstructors = new frmAddEditMembersInstructors();
            AddMembersInstructors.MembersInstructorsIDBack += RefreshList;
            AddMembersInstructors.Show();
        }

        private void dgvMembersInstructorsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowMembersInstructorsDetails ShowDetails = new frmShowMembersInstructorsDetails(_GetMembersInstructorsIDFromDGV());
            ShowDetails.ShowDialog();

            _RefreshMembersInstructorsList();
        }
    }
}
