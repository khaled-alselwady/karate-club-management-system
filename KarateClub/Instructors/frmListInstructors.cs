using KarateClub.Members;
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

namespace KarateClub.Instructors
{
    public partial class frmListInstructors : Form
    {

        private DataTable _dtAllInstructors;

        public frmListInstructors()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Instructor ID":
                    return "InstructorID";

                case "Name":
                    return "Name";

                case "Gender":
                    return "Gender";

                case "Phone":
                    return "Phone";

                case "Qualification":
                    return "Qualification";

                default:
                    return "None";
            }
        }

        private void _RefreshInstructorList()
        {
            _dtAllInstructors = clsInstructor.GetAllInstructors();
            dgvInstructorsList.DataSource = _dtAllInstructors;
            lblNumberOfRecords.Text = dgvInstructorsList.Rows.Count.ToString();

            if (dgvInstructorsList.Rows.Count > 0)
            {
                dgvInstructorsList.Columns[0].HeaderText = "Instructor ID";
                dgvInstructorsList.Columns[0].Width = 123;

                dgvInstructorsList.Columns[1].HeaderText = "Name";
                dgvInstructorsList.Columns[1].Width = 190;

                dgvInstructorsList.Columns[2].HeaderText = "Gender";
                dgvInstructorsList.Columns[2].Width = 100;

                dgvInstructorsList.Columns[3].HeaderText = "Date Of Birth";
                dgvInstructorsList.Columns[3].Width = 130;

                dgvInstructorsList.Columns[4].HeaderText = "Phone";
                dgvInstructorsList.Columns[4].Width = 110;

                dgvInstructorsList.Columns[5].HeaderText = "Qualification";
                dgvInstructorsList.Columns[5].Width = 300;
            }
        }

        private int _GetInstructorIDFromDGV()
        {
            return (int)dgvInstructorsList.CurrentRow.Cells["InstructorID"].Value;
        }

        private void frmListInstructors_Load(object sender, EventArgs e)
        {
            _RefreshInstructorList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender");

            cbGender.Visible = (cbFilter.Text == "Gender");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
          
            if (cbGender.Visible)
            {
                cbGender.SelectedIndex = 0;
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllInstructors.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllInstructors.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvInstructorsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Instructor ID")
            {
                // search with numbers
                _dtAllInstructors.DefaultView.RowFilter = 
                    string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllInstructors.DefaultView.RowFilter = 
                    string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvInstructorsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Instructor ID" || cbFilter.Text == "Phone")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllInstructors.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtAllInstructors.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvInstructorsList.Rows.Count.ToString();

                return;
            }

            _dtAllInstructors.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);
            lblNumberOfRecords.Text = dgvInstructorsList.Rows.Count.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInstructorDetails ShowInstructorDetails = new frmShowInstructorDetails(_GetInstructorIDFromDGV());
            ShowInstructorDetails.RefreshList += RefreshList;
            ShowInstructorDetails.Show();
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditInstructor AddNewInstructor = new frmAddEditInstructor();
            AddNewInstructor.InstructorIDBack += RefreshList;
            AddNewInstructor.Show();           
        }

        private void RefreshList(object sender, int InstructorID)
        {
            _RefreshInstructorList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditInstructor AddNewInstructor = new frmAddEditInstructor(_GetInstructorIDFromDGV());
            AddNewInstructor.InstructorIDBack += RefreshList;
            AddNewInstructor.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this instructor?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsInstructor.DeleteInstructor(_GetInstructorIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshInstructorList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMembersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowInstructorDetails ShowInstructorDetails = new frmShowInstructorDetails(_GetInstructorIDFromDGV());
            ShowInstructorDetails.Show();

            _RefreshInstructorList();
        }

        private void btnAddNewInstructor_Click(object sender, EventArgs e)
        {
            frmAddEditInstructor AddNewInstructor = new frmAddEditInstructor();
            AddNewInstructor.InstructorIDBack += RefreshList;
            AddNewInstructor.Show();
        }
    }
}
